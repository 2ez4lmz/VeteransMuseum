namespace VeteransMuseum.WebApi.Controllers.Users;

public sealed record RegisterUserRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password);