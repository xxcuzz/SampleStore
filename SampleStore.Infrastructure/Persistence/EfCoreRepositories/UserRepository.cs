using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.Entities;

namespace SampleStore.Infrastructure.Persistence.EfCoreRepositories;

public class UserRepository : IUserRepository
{
    public User? GetUserByEmail(string email)
    {
        return null;
        //return new User { FirstName = "John", LastName = "Doe", Email = "email", Password = "123456" };
    }

    public void AddUser(User user)
    {
        return;
    }
}