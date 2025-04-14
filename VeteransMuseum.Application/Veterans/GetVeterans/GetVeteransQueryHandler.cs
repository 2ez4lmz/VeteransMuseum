using Dapper;
using VeteransMuseum.Application.Abstractions.Data;
using VeteransMuseum.Application.Abstractions.Messaging;
using VeteransMuseum.Domain.Abstractions;

namespace VeteransMuseum.Application.Veterans.GetVeterans;

public class GetVeteransQueryHandler : IQueryHandler<GetVeteransQuery, IReadOnlyList<VeteranResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetVeteransQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<VeteranResponse>>> Handle(GetVeteransQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = @"";

        var veterans = await connection.QueryAsync<VeteranResponse>(sql);

        return veterans.ToList();
    }
}