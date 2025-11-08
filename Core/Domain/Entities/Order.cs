using Core.Domain.Enum;

namespace Core.Domain.Entities
{
    public class Order : BasicEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.En_Attente;
        public string Status_Reason { get; set; } = "";

        public int TravelPlan_Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }


    }
}
