using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using VeteransMuseum.Application.Abstractions.Authentication;
using VeteransMuseum.Domain.Abstractions;
using VeteransMuseum.Infrastructure.Authentication.Model;

namespace VeteransMuseum.Infrastructure.Authentication;

public sealed class JwtService : IJwtService
{
    private static readonly Error AuthenticationFailed = new(
        "Keycloak.AuthenticationFailed",
        "Failed to acquire access token do to authentication failure");
 
    private readonly HttpClient _httpClient;
    private readonly KeycloakOptions _keycloakOptions;
 
    public JwtService(HttpClient httpClient, IOptions<KeycloakOptions> keycloakOptions)
    {
        _httpClient = httpClient;
        _keycloakOptions = keycloakOptions.Value;
    }
 
    public async Task<Result<string>> GetAccessTokenAsync(
        string email, 
        string password, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var authRequestParameters = new KeyValuePair<string, string>[]
            {
                new("client_id", _keycloakOptions.AuthClientId),
                new("client_secret", _keycloakOptions.AuthClientSecret),
                new("scope", "openid email"),
                new("grant_type", "password"),
                new("username", email),
                new("password", password)
            };
 
            var authorizationRequestContent = new FormUrlEncodedContent(authRequestParameters);
 
            var response = await _httpClient.PostAsync("", authorizationRequestContent, cancellationToken);
 
            response.EnsureSuccessStatusCode();
 
            var authorizationToken = await response.Content.ReadFromJsonAsync<AuthorizationToken>();
 
            if (authorizationToken == null)
            {
                return Result.Failure<string>(AuthenticationFailed);
            }
 
            return authorizationToken.AccessToken;
        }
        catch (HttpRequestException)
        {
            return Result.Failure<string>(AuthenticationFailed);
        }
    }
}