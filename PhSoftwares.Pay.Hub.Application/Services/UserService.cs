using PhSoftwares.Pay.Hub.Application.DTOs;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserService(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public Task<UserDTO> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var payer = await _userRepository.GetById(id);
            return await _userMapper.MapFromEntitie(payer);
        }

        public async Task<UserDTO> Insert(UserDTO userDTO)
        {
            var user = await _userMapper.MapFromDTO(userDTO);
            var userInserted = await _userRepository.Insert(user);
            return await _userMapper.MapFromEntitie(userInserted);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var user = await _userMapper.MapFromDTO(userDTO);
            var userUpdate = await _userRepository.Update(user);
            return await _userMapper.MapFromEntitie(userUpdate);
        }

        public async Task<UserDTO> GetByEmailAddress(string emailAddress)
        {
            var user = await _userRepository.GetByEmailAddress(emailAddress);
            return await _userMapper.MapFromEntitie(user);
        }
    }
}
