using Web.data.DTO;

namespace avtosalon.Services.Identity
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto dto);

        Task<string> CreateToken();
    }
}
