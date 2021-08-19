﻿using System;

namespace Register.API.Entities
{
    public class UserConfiguration : Entity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double InitialBalance { get; set; }
    }
}