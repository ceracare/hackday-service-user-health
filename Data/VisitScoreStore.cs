using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using serviceUserHealth.Models;

namespace serviceUserHealth.Data
{
    public class VisitScoreStore : VisitScore
    {
        private readonly string _connectionString;

        public VisitScoreStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public async Task<VisitScore> FindByIdAsync(string visitId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                return await connection.QuerySingleOrDefaultAsync<VisitScore>($@"SELECT * FROM [VisitScore]
                WHERE [VisitId] = @{nameof(visitId)}", new { visitId });
            }
        }
    }
}
