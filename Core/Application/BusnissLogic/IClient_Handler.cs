using Core.Domain.Entities;

namespace Core.Application.BusnissLogic;

public interface IClient_Handler
{
    public Task<IEnumerable<Client>> GetAll();
    public Task<Client?> Get(int id);
    public Task Create(Client client);
    public Task Delete(int id);
    public Task Update(Client client);

    public Task<IEnumerable<Client>> Search(string firstName, string lastName,string job, string email, string phone, string idCard_Number, string passport_Number);
    
}
