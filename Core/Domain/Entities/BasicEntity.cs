namespace Core.Domain.Entities
{
    public class BasicEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; } = null;

    }
}
