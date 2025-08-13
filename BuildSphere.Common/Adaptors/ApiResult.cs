

namespace BuildSphere.Common.Adaptors
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string ErrorMessage {  get; set; }
    }
}
