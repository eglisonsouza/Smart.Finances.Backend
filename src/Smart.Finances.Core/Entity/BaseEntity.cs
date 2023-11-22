namespace Smart.Finances.Core.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public void Update()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
