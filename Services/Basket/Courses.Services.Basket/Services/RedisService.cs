using StackExchange.Redis;

namespace Courses.Services.Basket.Services
{
    public class RedisService
    {
        private readonly string _host;

        private readonly int _port;

        // Redis connection helper
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        // COnnected to Redis
        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        // Selected database, default bd is db1
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(db);

    }
}
