using PhSoftwares.Pay.Hub.Application.DTOs;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDTO> Insert(UserDTO userDTO);
        Task<UserDTO> Delete(Guid id);
        Task<UserDTO> Update(UserDTO userDTO);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(Guid id);
        Task<UserDTO> GetByEmailAddress(String emailAddress);
    }
}
