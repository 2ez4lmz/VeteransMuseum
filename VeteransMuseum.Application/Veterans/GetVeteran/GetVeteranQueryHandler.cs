using Dapper;
using VeteransMuseum.Application.Abstractions.Data;
using VeteransMuseum.Application.Abstractions.Messaging;
using VeteransMuseum.Application.Veterans.GetVeterans;
using VeteransMuseum.Domain.Abstractions;

namespace VeteransMuseum.Application.Veterans.GetVeteran;

public class GetVeteranQueryHandler : IQueryHandler<GetVeteranQuery, VeteranResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetVeteranQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<VeteranResponse>> Handle(GetVeteranQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = "";

        var veteran = await connection.QueryFirstOrDefaultAsync<VeteranResponse>(
            sql,
            new
            {
                request.VeteranId
            });

        return veteran;
    }
}