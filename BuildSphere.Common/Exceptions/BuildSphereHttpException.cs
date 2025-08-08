
namespace BuildSphere.Common.Exceptions
{
    public class BuildSphereHttpException : Exception
    {
        public BuildSphereHttpException(int statusCode, string errorMessage) : base(errorMessage) 
        {
            StatusCode = statusCode;
            Error = errorMessage;
        }

        public int StatusCode { get; set; }
        public string Error { get; set; }
    }
}
