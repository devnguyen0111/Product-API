using DataAccess.DTO.AuthDTOs;
using DataAccess.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface IAuthService
    {
        Task<UserDTO> RegisterAsync(RegisterRequestDTO dto);

        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO dto);
    }
}
