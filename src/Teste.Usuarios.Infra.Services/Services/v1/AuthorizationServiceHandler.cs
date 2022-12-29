using Teste.Usuarios.Domain.Contracts.v1.Services;
using Teste.Usuarios.Domain.Dtos.v1;
using Teste.Usuarios.Domain.Models;
using Teste.Usuarios.Infra.Services.Clients.v1;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Teste.Usuarios.Infra.Services.Services.v1;

public class AuthorizationServiceHandler : IAuthorizationService
{
    private readonly ILoyClient _client;
    private readonly IMemoryCache _memoryCache;
    private readonly LoySettings _loySettings;
    private readonly ILogger _logger;
    private const string Token = "LoyToken";

    public AuthorizationServiceHandler(ILoyClient client, IMemoryCache memoryCache
        , LoySettings loySettings, ILogger logger)
    {
        _client = client;
        _memoryCache = memoryCache;
        _loySettings = loySettings;
        _logger = logger;
    }

    public async Task<string> AuthorizeAsync(CancellationToken cancellationToken, bool expiredToken = false)
    {
        if (expiredToken)
        {
            _memoryCache.Remove(Token);
        }

        var token = _memoryCache.Get<string>(Token);

        if (string.IsNullOrEmpty(token))
        {
            var authHeader = Convert.ToBase64String(Encoding.GetEncoding("UTF-8").GetBytes(_loySettings.Usuario + ":" + _loySettings.Senha));
            var response = await _client.GetAuthorizationTokenAsync($"Basic {authHeader}");
            var contentString = await response.Content.ReadAsStringAsync(cancellationToken);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.Error($"Erro ao obter token da api do backoffice. {contentString}");

                return string.Empty;
            }

            var responseAuthorizationDto = JsonSerializer.Deserialize<ResponseAuthorizationDto>(contentString);

            token = responseAuthorizationDto.access_token;
            _logger.Information($"Token bearer obtido: {token}");

            _memoryCache.Set(Token, token);
        }

        ArgumentNullException.ThrowIfNull(token);

        return $"Bearer {token}";
    }
}