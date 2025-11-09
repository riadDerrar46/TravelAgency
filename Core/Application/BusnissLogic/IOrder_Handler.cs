using Core.Domain.Entities;

namespace Core.Application.BusnissLogic
{
    public interface IOrder_Handler
    {
        public Task<IEnumerable<Order>> GetAll();
        public Task<Order?> Get(int id);
        public Task Create(Order Order);
        public Task Delete(int id);
        public Task Update(Order Order);

        public Task<IEnumerable<Order>> GetOrdersByClientId(int clientId);


    }
}
