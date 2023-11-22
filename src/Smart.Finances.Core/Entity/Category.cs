namespace Smart.Finances.Core.Entity
{
    public class Category : BaseEntity
    {
        public string Description { get; private set; }
        public bool IsActive { get; private set; }

        public Category(string description) : base()
        {
            Description = description;
            IsActive = true;
        }

        public void Update(string? description)
        {
            base.Update();
            Description = description!;
        }
    }
}
