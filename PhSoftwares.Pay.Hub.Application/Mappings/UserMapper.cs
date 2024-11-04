using Microsoft.AspNetCore.Mvc.RazorPages;
using PhSoftwares.Pay.Hub.Application.DTOs;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Core.Entities;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System.Net.Mail;

namespace PhSoftwares.Pay.Hub.Application.Mappings
{
    public class UserMapper : IUserMapper
    {
        public Task<User> MapFromDTO(UserDTO userDTO)
        {
            return Task.FromResult(new User(Guid.NewGuid(), userDTO.FullName, userDTO.EmailAddress, userDTO.DocumentNumber, userDTO.Password));
        }

        public Task<UserDTO> MapFromEntitie(User user)
        {
            return Task.FromResult(new UserDTO()
            {
                Id = user.Id,
                FullName = user.FullName,
                EmailAddress = user.EmailAddress,
                DocumentNumber = user.DocumentNumber
            });
        }
    }
}
