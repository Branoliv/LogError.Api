using System;

namespace LogError.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
    }
}
