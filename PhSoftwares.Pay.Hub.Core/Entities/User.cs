using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Core.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string EmailAddress { get; private set; }
        public string DocumentNumber { get; set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public User(Guid id, string fullName, string emailAddress, string documentNumber, string password)
        {
            Id = id;
            FullName = fullName;
            EmailAddress = emailAddress;
            DocumentNumber = documentNumber;
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public User(string fullName, string emailAddress)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            EmailAddress = emailAddress;
        }
        public void ChangePassowrd(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
