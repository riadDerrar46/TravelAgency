using Core.Domain.Entities;

namespace Core.Application.BusnissLogic
{
    public interface IUsers_Handler
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User?> Get(int id);
        public Task Create(User User);
        public Task Delete(int id);
        public Task Update(User User);

        public Task<IEnumerable<User?>> Search(string? firstName = null, string? lastName = null, string? email = null, string? password = null, string? phone = null, 
            string? idCard_Number = null, string? passport_Number = null);

    }
}
