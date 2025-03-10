﻿namespace Domain.Abstractions
{
    internal interface IUser
    {
        public string Name { get;}
        public DateTime DateOfBirth { get; }
        public string Email { get; }
        public string PassportSeries { get; }
        public string PhoneNumber { get; }
    }
}
