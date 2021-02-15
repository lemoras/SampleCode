using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Company.Domain.Repositories;
using Company.Domain.Request;
using Company.Domain.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Dapper;

namespace Company.Infrastructure.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly IOptions<DBSettings> _dBSettings;
        private readonly IDbConnection _db;

        public StaffRepository(IOptions<DBSettings> dbSettings)
        {
            _dBSettings = dbSettings;
            _db = new MySqlConnection(_dBSettings.Value.DatabaseConnection);
        }

        public async Task<int> CreateStaffAsync(CreateStaffRequest request)
        {
            string sql = @"INSERT INTO Staff(UserId,BranchId,Name,Surname,PhotoUrl) VALUES(@UserId,@BranchId,@Name,@Surname,@PhotoUrl)";

            var except = await _db.ExecuteAsync(sql, new { request.UserId, request.BranchId, request.Name, request.Surname,request.PhotoUrl });

            sql = @"SELECT max(id) FROM Staff";

            var result = await _db.QueryAsync<int>(sql);

            return result.FirstOrDefault();
        }

        public async Task<int> UpdateStaffAsync(UpdateStaffRequest request)
        {
            var sql = @"UPDATE Claim SET ClaimEnum=@UserId, BranchId=@BranchId, Name=@Name, Surname=@Surname, PhotoUrl=@PhotoUrl WHERE Id=@Id";

            var result = await _db.ExecuteAsync(sql, new { request.UserId, request.BranchId, request.Name, request.Surname, request.PhotoUrl, request.Id });

            return result;
        }

        public async Task<IEnumerable<Staff>> GetStaffByBranchIdAsync(int branchId)
        {
            string query = @"SELECT * FROM Staff Where BranchId=@branchId";

            var result = await _db.QueryAsync<Staff>(query, new { branchId });

            return result;
        }

        public void Dispose()
        {
            _db.Close();
        }

    
    }
}
