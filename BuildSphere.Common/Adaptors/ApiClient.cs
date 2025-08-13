
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BuildSphere.Common.Adaptors
{
    public class ApiClient
    {

        public ApiClient(HttpClient httpClient) : this(httpClient, null)
        { }

        public ApiClient(HttpClient httpClient, string? authToken)
        {
            _httpClient = httpClient;
            _authToken = authToken;
        }

        public void SetAuthToken(string token)
        {
            _authToken = token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
        }

        public void ClearAuthToken()
        {
            _authToken = null;
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<ApiResult<T>> SendAsync<T>(HttpMethod method, string endpoint, object? data = null)
        {
            var request = new HttpRequestMessage(method, endpoint);

            if (method == HttpMethod.Post || method == HttpMethod.Put || method == HttpMethod.Patch)
            {
                var serializedData = JsonSerializer.Serialize(data) ;
                request.Content = new StringContent(serializedData, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);
            return await HandleResponse<T>(response);
        }

        private async Task<ApiResult<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return new ApiResult<T> { Success = true, Data = result };
            }

            return new ApiResult<T>
            {
                Success = false,
                ErrorMessage = $"{response.StatusCode}: {response.ReasonPhrase}"
            };
        }

        private readonly HttpClient _httpClient;
        private string? _authToken;
    }
}
