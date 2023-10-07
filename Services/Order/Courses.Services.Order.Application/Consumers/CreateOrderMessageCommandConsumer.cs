using Courses.Shared.Messages;
using FreeCourse.Services.Order.Infrastructure;
using MassTransit;

namespace Courses.Services.Order.Application.Consumers
{
    public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderMessageCommandConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            var newAddress = new Domain.OrderAggregate.Address(province: context.Message.Province, district: context.Message.District, street: context.Message.Street, zipCode: context.Message.ZipCode, line: context.Message.Line);

            Domain.OrderAggregate.Order order = new Domain.OrderAggregate.Order(context.Message.BuyerId, newAddress);

            context.Message.OrderItems.ForEach(x =>
            {
                order.AddOrderItem(productId: x.ProductId, productName: x.ProductName, price: x.Price, pictureUrl: x.PictureUrl);
            });

            await _orderDbContext.Orders.AddAsync(order);

            await _orderDbContext.SaveChangesAsync();
        }
    }
}
