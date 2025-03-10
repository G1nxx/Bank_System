using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Client : Primitives.Entity, Abstractions.IUser
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string PassportSeries { get; private set; }
    }
}
