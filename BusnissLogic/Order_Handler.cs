using Core.Application.BusnissLogic;
using Core.Application.DB;
using Core.Domain.Entities;

namespace BusnissLogic;

public class Order_Handler : IOrder_Handler
{
    private readonly IGeneric_CRUD _generic_CRUD;

    public Order_Handler(IGeneric_CRUD generic_CRUD)
    {
        _generic_CRUD = generic_CRUD;
    }

    public async Task Create(Order order)
    {
        await _generic_CRUD.CreateAsync(order);
    }

    public async Task Delete(int id)
    {
        await _generic_CRUD.DeleteAsync<Order>(id);
    }

    public async Task<Order?> Get(int id)
    {
        return await _generic_CRUD.GetByIdAsync<Order>(id);
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _generic_CRUD.GetAllAsync<Order>();
    }

    public async Task<IEnumerable<Order>> GetOrdersByClientId(int clientId)
    {
        return await _generic_CRUD.Search<Order>(new { ClientId = clientId });
    }

    public async Task Update(Order order)
    {
        await _generic_CRUD.UpdateAsync(order);
    }
}
