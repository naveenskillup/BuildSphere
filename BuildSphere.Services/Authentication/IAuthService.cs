
using System.Threading.Tasks;

namespace BuildSphere.Services.Authentication
{
    public interface IAuthService
    {
        Task<string> Authenticate(string userName, string password);
    }
}
