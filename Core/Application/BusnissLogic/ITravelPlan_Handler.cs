using Core.Domain.Entities;

namespace Core.Application.BusnissLogic
{
    public interface ITravelPlan_Handler
    {
        public Task<IEnumerable<TravelPlan>> GetAll();
        public Task<TravelPlan?> Get(int id);
        public Task Create(TravelPlan TravelPlan);
        public Task Delete(int id);
        public Task Update(TravelPlan TravelPlan);
        public Task<IEnumerable<TravelPlan>> Search(TravelPlan travelPlan);

    }
}
