using VeteransMuseum.Domain.Users;

namespace VeteransMuseum.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) 
        : base(dbContext)
    {
    }
}