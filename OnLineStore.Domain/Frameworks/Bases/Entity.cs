using System;

namespace OnLineStore.Domain.Frameworks.Bases
{
    public class Entity : Abstracts.IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}