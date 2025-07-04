using Role = VeteransMuseum.Domain.Users.Role;

namespace VeteransMuseum.Infrastructure.Authorization;

public sealed class UserRolesResponse
{
    public Guid Id { get; init; }
 
    public List<Role> Roles { get; init; } = [];
}