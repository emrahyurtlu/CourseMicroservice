using Courses.Services.Order.Application.Dtos;
using Courses.Shared.Models;
using MediatR;

namespace Courses.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
