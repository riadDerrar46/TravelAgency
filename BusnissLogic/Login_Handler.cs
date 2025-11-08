using Core.Application.BusnissLogic;
using Core.Domain.Entities;

namespace BusnissLogic;

public class Login_Handler : ILogin_Handler
{
    public Task<User?> Login(string email, string password)
    {
        throw new NotImplementedException();
    }
}
