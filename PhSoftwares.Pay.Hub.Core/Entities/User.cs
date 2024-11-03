﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Core.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string EmailAddress { get; private set; }
        public required string DocumentNumber { get; set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

        public User(Guid id, string fullName, string emailAddress)
        {
            Id = id;
            FullName = fullName;
            EmailAddress = emailAddress;
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