using Core.Domain.Entities;

namespace Core.Application.BusnissLogic
{
    public interface ITravelPlans_Handler
    {
        public Task<IEnumerable<TravelPlans>> GetAll();
        public Task<TravelPlans?> Get(int id);
        public Task Create(TravelPlans TravelPlan);
        public Task Delete(int id);
        public Task Update(TravelPlans TravelPlan);

    }
}
