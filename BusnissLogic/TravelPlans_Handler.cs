using Core.Application.BusnissLogic;
using Core.Application.DB;
using Core.Domain.Entities;

namespace BusnissLogic;

public class TravelPlans_Handler : ITravelPlans_Handler
{
    private readonly IGeneric_CRUD _generic_CRUD;

    public TravelPlans_Handler(IGeneric_CRUD generic_CRUD)
    {
        _generic_CRUD = generic_CRUD;
    }

    public async Task Create(TravelPlans travelPlan)
    {
        await _generic_CRUD.CreateAsync(travelPlan);
    }

    public async Task Delete(int id)
    {
        await _generic_CRUD.DeleteAsync<TravelPlans>(id);
    }

    public async Task<TravelPlans?> Get(int id)
    {
        return await _generic_CRUD.GetByIdAsync<TravelPlans>(id);
    }

    public async Task<IEnumerable<TravelPlans>> GetAll()
    {
        return await _generic_CRUD.GetAllAsync<TravelPlans>();
    }

    public async Task Update(TravelPlans travelPlan)
    {
        await _generic_CRUD.UpdateAsync(travelPlan);
    }
}
