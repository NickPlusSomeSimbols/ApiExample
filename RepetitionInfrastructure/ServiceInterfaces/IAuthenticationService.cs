using RepetitionCore.Authentication;

namespace RepetitionInfrastructure.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<object> LoginAsync(LoginModel model);
        Task<string> RegisterAdminAsync(RegisterModel model);
        Task<string> RegisterAsync(RegisterModel model);
    }
}