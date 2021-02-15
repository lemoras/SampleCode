using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Company.Domain.Repositories;
using Company.Domain.Models;
using Company.Domain.Request;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Dapper;

namespace Company.Infrastructure.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly IOptions<DBSettings> _dBSettings;
        private readonly IDbConnection _db;


        public BranchRepository(IOptions<DBSettings> dbSettings)
        {
            _dBSettings = dbSettings;
            _db = new MySqlConnection(_dBSettings.Value.DatabaseConnection);
        }

        public async Task<int> CreateBranchAsync(CreateBranchRequest request)
        {
            string sql = @"INSERT INTO Branch(Name,CompanyId,CityId,DistrictId,Adress,`Order`,Active,CreatedDate,CreatedBy) VALUES(@Name,@CompanyId,@CityId,@DistrictId,@Adress,@Order,@Active,@CreatedDate,@CreatedBy)";

            var result = await _db.ExecuteAsync(sql, new { request.Name, request.CompanyId, request.CityId, request.DistrictId, request.Adress, request.Order, request.Active, CreatedDate = DateTime.Now, request.CreatedBy });

            return result;
        }


        public async Task<IEnumerable<Branch>> GetAllBranchByCompanyAsync(int companyId)
        {
            string query = @"  SELECT * FROM Branch Where CompanyId=@companyId";

            var result = await _db.QueryAsync<Branch>(query, new { companyId});

            return result;
        }

        public async Task<Branch> GetBranchByIdAsync(int Id)
        {
            string query = @"  SELECT * FROM Branch Where Id=@Id";

            var result = await _db.QueryAsync<Branch>(query, new { Id });

            return result.FirstOrDefault();
        }


        public void Dispose()
        {
            _db.Close();
        }
    }
}
