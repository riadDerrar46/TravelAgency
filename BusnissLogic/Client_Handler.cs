using Core.Application.BusnissLogic;
using Core.Application.DB;
using Core.Domain.Entities;

namespace BusnissLogic
{
    public class Client_Handler : IClient_Handler
    {
        private readonly IGeneric_CRUD _generic_CRUD;
        public Client_Handler(IGeneric_CRUD generic_CRUD)
        {
            _generic_CRUD = generic_CRUD;
        }
        public async Task Create(Client client)
        {
            await _generic_CRUD.CreateAsync(client);
        }

        public async Task Delete(int id)
        {
           await _generic_CRUD.DeleteAsync<Client>(id);
        }

        public async Task<Client?> Get(int id)
        {
            return await _generic_CRUD.GetByIdAsync<Client>(id);
        }

        public async Task<IEnumerable<Client>> Search(string firstName, string lastName, string job,string email, string phone, string idCard_Number, string passport_Number)
        {
            return await _generic_CRUD.Search<Client>(new { FirstName = firstName,LastName = lastName,PhoneNumber = phone ,
                                                            Job = job, Email = email,        
                                                            IdCard_Number = idCard_Number, Passport_Number = passport_Number });
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _generic_CRUD.GetAllAsync<Client>();
        }

        public async Task Update(Client client)
        {
            await _generic_CRUD.UpdateAsync(client);
        }
    }
}
