namespace Core.Domain.Entities
{
    public class TravelPlan : BasicEntity
    {
        public string Title { get; set; } = string.Empty;
        public int NumberOfPeople { get; set; } = 1;
        public string Destination { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public decimal Budget { get; set; }
    }
}
