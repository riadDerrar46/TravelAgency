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

        public Task<IEnumerable<User>> Search(string firstName, string lastName, string email, string password, string phone , 
            string idCard_Number, string passport_Number);

    }
}
