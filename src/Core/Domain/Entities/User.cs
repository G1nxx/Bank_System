using Domain.Abstractions;
using Domain.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IUser
    {
        public User(uint id, string login, string name, RoleType role, DateTime dateOfBirth, string email, string passportSeries, string phoneNumber, string passwordHash)
        {
            Id = id;
            Login = login;
            Name = name;
            Role = role;
            DateOfBirth = dateOfBirth;
            Email = email;
            PassportSeries = passportSeries;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
        }

        public uint Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public RoleType Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PassportSeries { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
    }
}
