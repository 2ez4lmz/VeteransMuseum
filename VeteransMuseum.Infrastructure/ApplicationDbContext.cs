using Microsoft.EntityFrameworkCore;
using VeteransMuseum.Application.Abstractions.Clock;

namespace VeteransMuseum.Infrastructure;

public sealed class ApplicationDbContext : DbContext
{
    private readonly IDateTimeProvider _dateTimeProvider;
    
    public ApplicationDbContext(DbContextOptions options, IDateTimeProvider dateTimeProvider)
        : base(options)
    {
        _dateTimeProvider = dateTimeProvider;
    }
}