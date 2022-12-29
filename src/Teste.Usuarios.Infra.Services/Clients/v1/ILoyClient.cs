using Refit;

namespace Teste.Usuarios.Infra.Services.Clients.v1
{
    public interface ILoyClient
    {
        [Post("/plataforma/auth/oauth/token?grant_type=client_credentials")]
        Task<HttpResponseMessage> GetAuthorizationTokenAsync([Header("Authorization")] string basicAuthParameters);

        [Headers("Content-Type: application/json")]
        [Get("/plataforma/backoffice/v1/processo")]
        Task<HttpResponseMessage> BuscarProcessoAsync([Header("Authorization")] string token, [Body] object request);

        [Headers("Content-Type: application/json")]
        [Post("/plataforma/backoffice/v1/processo")]
        Task<HttpResponseMessage> EnviarProcessoAsync([Header("Authorization")] string token, [Body] object request);
    }
}