using Teste.Usuarios.Domain.Contracts.v1.Services;
using Teste.Usuarios.Domain.Dtos.v1;
using Teste.Usuarios.Infra.Services.Clients.v1;
using Newtonsoft.Json;
using Serilog;
using System.Net.Http.Json;

namespace Teste.Usuarios.Infra.Services.Services.v1;

public class ProcessoServiceHandler : IProcessoService
{
    private readonly ILoyClient _client;
    private readonly IAuthorizationService _authorizationService;
    private readonly ILogger _logger;

    public ProcessoServiceHandler(ILoyClient client, IAuthorizationService authorizationService, ILogger logger)
    {
        _client = client;
        _authorizationService = authorizationService;
        _logger = logger;
    }

    public async Task<ResponseProcessoDto> GetCapaProcessoAsync(string token, string cnj, CancellationToken cancellationToken)
    {
        var request = new
        {
            cnj
        };

        var responseBuscarProcesso = await _client.BuscarProcessoAsync(token, JsonConvert.SerializeObject(request));

        if (responseBuscarProcesso.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            token = await _authorizationService.AuthorizeAsync(cancellationToken, true);
            responseBuscarProcesso = await _client.BuscarProcessoAsync(token, request);
        }

        var contentStringBuscarProcesso = await responseBuscarProcesso.Content.ReadAsStringAsync(cancellationToken);

        if (!responseBuscarProcesso.IsSuccessStatusCode)
        {
            _logger.Error($"Erro ao obter a capa do processo: {contentStringBuscarProcesso}");

            return new ResponseProcessoDto();
        }

        var responseProcessoDto = JsonConvert.DeserializeObject<ResponseProcessoDto>(contentStringBuscarProcesso);

        if (!string.IsNullOrEmpty(responseProcessoDto.Msg))
        {
            var responseEnviarProcesso = await _client.EnviarProcessoAsync(token, JsonConvert.SerializeObject(request));

            if (responseEnviarProcesso.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                token = await _authorizationService.AuthorizeAsync(cancellationToken, true);
                responseEnviarProcesso = await _client.EnviarProcessoAsync(token, JsonConvert.SerializeObject(request));
            }

            var contentStringEnviarProcesso = await responseEnviarProcesso.Content.ReadAsStringAsync(cancellationToken);

            if (!responseEnviarProcesso.IsSuccessStatusCode)
            {
                _logger.Error($"Erro ao obter a capa do processo: {contentStringEnviarProcesso}");
            }

            responseProcessoDto.Msg = contentStringEnviarProcesso;
        }

        return responseProcessoDto!;
    }
}