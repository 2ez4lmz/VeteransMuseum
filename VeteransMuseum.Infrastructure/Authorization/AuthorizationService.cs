using VeteransMuseum.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace VeteransMuseum.Infrastructure.Authorization;

internal sealed class AuthorizationService
{
    private readonly ApplicationDbContext _dbContext;
 
    public AuthorizationService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
 
    public async Task<UserRolesResponse> GetRolesForUserAsync(string identityId)
    {
        var roles = await _dbContext.Set<User>()
            .Where(user => user.IdentityId == identityId)
            .Select(user => new UserRolesResponse
            {
                Id = user.Id,
                Roles = user.Roles.ToList()
            })
            .FirstAsync();
 
        return roles;
    }
}