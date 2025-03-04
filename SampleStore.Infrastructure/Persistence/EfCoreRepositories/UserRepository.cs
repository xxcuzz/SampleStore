using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.Entities;

namespace SampleStore.Infrastructure.Persistence.EfCoreRepositories;

public class UserRepository : IUserRepository
{
    public User? GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public void AddUser(User user)
    {
        throw new NotImplementedException();
    }
}