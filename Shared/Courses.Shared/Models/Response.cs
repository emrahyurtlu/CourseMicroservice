using System.Text.Json.Serialization;

namespace Courses.Shared.Models
{
    public class Response<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; set; }

        public static Response<T> Success(T data, int statusCode) => new() { Data = data, StatusCode = statusCode, IsSuccessful = true };

        public static Response<T> Success(int statusCode) => new() { Data = default, StatusCode = statusCode, IsSuccessful = true };

        public static Response<T> Fail(List<string> errors, int statusCode) => new() { Errors = errors, StatusCode = statusCode, IsSuccessful = false };

        public static Response<T> Fail(string error, int statusCode) => new() { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccessful = false };

        public static Response<T> NotFound(string error) => new() { Errors = new List<string> { error }, StatusCode = 404, IsSuccessful = false };

        public static Response<T> Found(T data) => new() { Data = data, StatusCode = 200, IsSuccessful = true };

        public static Response<T> Created(T data) => new() { Data = data, StatusCode = 201, IsSuccessful = true };

        public static Response<T> Updated() => new() { Data = default, StatusCode = 204, IsSuccessful = true };

        public static Response<T> Deleted() => new() { Data = default, StatusCode = 204, IsSuccessful = true };
    }
}
