using VeteransMuseum.Application.Abstractions.Messaging;

namespace VeteransMuseum.Application.Users.GetLoggedInUser;

public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;