using System.Text.Json.Serialization;

namespace Course.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; set; }

        public static ResponseDto<T> Success(T data, int statusCode) => new() { Data = data, StatusCode = statusCode, IsSuccessful = true };

        public static ResponseDto<T> Success(int statusCode) => new() { Data = default, StatusCode = statusCode, IsSuccessful = true };

        public static ResponseDto<T> Fail(List<string> errors, int statusCode) => new() { Errors = errors, StatusCode = statusCode, IsSuccessful = false };

        public static ResponseDto<T> Fail(string error, int statusCode) => new() { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccessful = false };
    }
}
