
using Core.Domain.Entities;

namespace Core.Application.BusnissLogic;

public interface ILogin_Handler
{
    Task<User?> Login(string email, string password);
}
