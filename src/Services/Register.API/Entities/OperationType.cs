using System;

namespace Register.API.Entities
{
    public class OperationType
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        protected OperationType()
        {
            Id = Guid.NewGuid();
        }
    }
}