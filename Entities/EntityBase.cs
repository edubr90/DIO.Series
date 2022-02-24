using System;

namespace DIO.Series.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set;}
        public bool Deleted { get; protected set; }

        public void SetId(Guid id)
        {
            this.Id = id;
        }

        public void SetDeleted()
        {
            Deleted = true;
        }
    }
}