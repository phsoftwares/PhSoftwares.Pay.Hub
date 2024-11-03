using PhSoftwares.Pay.Hub.Application.DTOs;
using PhSoftwares.Pay.Hub.Core.Entities;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Mappings
{
    public interface IUserMapper
    {
        Task<User> MapFromDTO(UserDTO userDTO);
        Task<UserDTO> MapFromEntitie(User user);
    }
}
