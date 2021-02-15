using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Company.Domain.Repositories;
using Company.Domain.Request;

namespace Company.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IOptions<DBSettings> _dBSettings;
        private readonly IDbConnection _db;

        public CompanyRepository(IOptions<DBSettings> dbSettings)
        {
            _dBSettings = dbSettings;
            _db = new MySqlConnection(_dBSettings.Value.DatabaseConnection);
        }

        public async Task<int> CreateCompanyAsync(CreateCompanyRequest request)
        {
            string sql = @"INSERT INTO Company(Name,Logo,TradeRegisterNo,CreatedDate,CreatedBy) VALUES(@Name,@Logo,@TradeRegisterNo,@CreatedDate,@CreatedBy)";

            var except = await _db.ExecuteAsync(sql, new { request.Name, request.Logo, request.TradeRegisterNo,CreatedDate=DateTime.Now, request.CreatedBy });

            sql = @"SELECT max(id) FROM Company";

            var result =  await _db.QueryAsync<int>(sql);

            return result.FirstOrDefault();
        }

        public void Dispose()
        {
            _db.Close();
        }
    }
}
