using SharedClassLibrary.Dtos;
using static SharedClassLibrary.Dtos.ServiceResponses;

namespace JWTAuthProject.Contracts
{
    public interface IUserAccount 
    {
        Task<GeneralResponse> CreateAccount(UserDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}
