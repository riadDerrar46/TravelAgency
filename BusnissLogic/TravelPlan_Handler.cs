using Core.Application.BusnissLogic;
using Core.Application.DB;
using Core.Domain.Entities;

namespace BusnissLogic;

public class TravelPlan_Handler : ITravelPlan_Handler
{
    private readonly IGeneric_CRUD _generic_CRUD;

    public TravelPlan_Handler(IGeneric_CRUD generic_CRUD)
    {
        _generic_CRUD = generic_CRUD;
    }

    public async Task Create(TravelPlan travelPlan)
    {
        await _generic_CRUD.CreateAsync(travelPlan);
    }

    public async Task Delete(int id)
    {
        await _generic_CRUD.DeleteAsync<TravelPlan>(id);
    }

    public async Task<TravelPlan?> Get(int id)
    {
        return await _generic_CRUD.GetByIdAsync<TravelPlan>(id);
    }

    public async Task<IEnumerable<TravelPlan>> GetAll()
    {
        return await _generic_CRUD.GetAllAsync<TravelPlan>();
    }

    public async Task<IEnumerable<TravelPlan>> Search(TravelPlan travelPlan)
    {
        var res = await _generic_CRUD.Search<TravelPlan>(new
        {
            Title = travelPlan.Title,
            NumberOfPeople = travelPlan.NumberOfPeople,
            Destination = travelPlan.Destination,
            Description = travelPlan.Description,
            StartDate = travelPlan.StartDate,
            EndDate = travelPlan.EndDate,
            Budget = travelPlan.Budget
        });
        return res;
    }

    public async Task Update(TravelPlan travelPlan)
    {
        await _generic_CRUD.UpdateAsync(travelPlan);
    }
}
