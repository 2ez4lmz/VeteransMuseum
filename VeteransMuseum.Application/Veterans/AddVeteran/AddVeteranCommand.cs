using VeteransMuseum.Application.Abstractions.Messaging;
using VeteransMuseum.Domain.Veterans;

namespace VeteransMuseum.Application.Veterans.AddVeteran;

public record AddVeteranCommand(
    string FirstName,
    string LastName,
    string MiddleName) : ICommand<Guid>;