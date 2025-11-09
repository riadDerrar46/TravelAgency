using Core.Application.BusnissLogic;
using Core.Application.DB;
using Core.Domain.Entities;

namespace BusnissLogic;

public class User_Handler : IUsers_Handler
{
    private readonly IGeneric_CRUD _generic_CRUD;

    public User_Handler(IGeneric_CRUD generic_CRUD)
    {
        _generic_CRUD = generic_CRUD;
    }


    public async Task Create(User user)
    {
        await _generic_CRUD.CreateAsync(user);
    }

    public async Task Delete(int id)
    {
        var user = await _generic_CRUD.GetByIdAsync<User>(id);
        if (user != null)
            await _generic_CRUD.DeleteAsync<User>(id);
    }

    public async Task<User?> Get(int id)
    {
        return await _generic_CRUD.GetByIdAsync<User>(id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _generic_CRUD.GetAllAsync<User>();
    }

    public async Task Update(User user)
    {

        var res = await _generic_CRUD.GetByIdAsync<User>(user.Id);
        if (res != null)
            await _generic_CRUD.UpdateAsync(user);
    }

    public async Task<IEnumerable<User?>> Search(string firstName, string lastName, string email, string password, string phone, string idCard_Number, string passport_Number)
    {
        return await _generic_CRUD.Search<User>(new
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phone,
            Password = password,
            Email = email,
            IdCard_Number = idCard_Number,
            Passport_Number = passport_Number
        });
    }
    public async Task<User?> Login(string email, string password)
    {
        var users = await _generic_CRUD.Search<User>(new { Email = email, Password = password });
        return users.FirstOrDefault();
    }


}
