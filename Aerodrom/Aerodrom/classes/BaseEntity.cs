namespace Aerodrom.classes
{
    public class BaseEntity
    {
        public Guid Id { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        protected void Touch()
        {
            UpdatedAt = DateTime.Now;
        }

    }
}