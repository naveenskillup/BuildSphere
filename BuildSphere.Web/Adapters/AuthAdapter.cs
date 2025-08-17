using BuildSphere.Common.Adaptors;
using BuildSphere.Common.Requests;
using NuGet.Protocol.Plugins;

namespace BuildSphere.Web.Adapters
{
    public class AuthAdapter
    {

        public AuthAdapter(ApiClient apiClient)
            => _apiClient = apiClient;

        public async Task<ApiResult<string>> Login(LoginRequest request)
            => await _apiClient.SendAsync<string>(HttpMethod.Post, "api/auth/login", request);

        public void SetAuthToken(string token) => _apiClient.SetAuthToken(token);

        private readonly ApiClient _apiClient;
    }

}
