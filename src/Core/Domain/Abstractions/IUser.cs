﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    internal interface IUser
    {
        string Name { get;}
        DateTime DateOfBirth { get; }
        string Email { get; }
        string PhoneNumber { get; }
    }
}
