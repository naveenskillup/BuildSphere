namespace BuildSphere.Services.Authentication
{
    public interface IAuthService
    {
        public bool Authenticate(string userName, string password);
    }
}
