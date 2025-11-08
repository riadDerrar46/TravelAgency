namespace Core.Domain.Entities
{
    public class TravelPlans
    {
        public int NumberOfPeople { get; set; } = 1;
        public string Destination { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
    }
}
