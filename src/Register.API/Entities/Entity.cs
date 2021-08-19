﻿using System;

namespace Register.API.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}