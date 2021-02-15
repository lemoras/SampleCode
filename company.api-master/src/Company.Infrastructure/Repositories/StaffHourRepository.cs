using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Company.Domain.Repositories.Define;
using Company.Domain.Request;
using Company.Domain.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Dapper;

namespace Company.Infrastructure.Repositories
{
    public class StaffHourRepository : IStaffHourRepository
    {
        private readonly IOptions<DBSettings> _dBSettings;
        private readonly IDbConnection _db;

        public StaffHourRepository(IOptions<DBSettings> dbSettings)
        {
            _dBSettings = dbSettings;
            _db = new MySqlConnection(_dBSettings.Value.DatabaseConnection);
        }

        public async Task<int> CreateStaffHourAsync(CreateStaffHourRequest request)
        {
            var workHourSplits = String.Join(",", request.WorkHours);

            string sql = @"INSERT INTO StaffWorkingHours(StaffId,Week,WorkHours) VALUES(@staffId,@week,@workHours)";

            var result = await _db.ExecuteAsync(sql, new { request.StaffId, request.Week, workHours = workHourSplits });

            return result;
        }

        public async Task<int> UpdateStaffHourAsync(UpdateStaffHourRequest request)
        {
            var workHourSplits = String.Join(",", request.WorkHours);

            var sql = @"UPDATE StaffHour SET StaffId=@StaffId, Week=@Week, WorkHours=@WorkHours WHERE Id=@Id";

            var result = await _db.ExecuteAsync(sql, new { request.StaffId, request.Week, workHours=workHourSplits, request.Id });

            return result;
        }

        public async Task<StaffWorkHour> GetStaffHourByStaffId(int staffId)
        {
            string query = @"SELECT * FROM StaffWorkingHours Where StaffId=@staffId";

            var result = await _db.QueryAsync<StaffWorkHour>(query, new { staffId });

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<StaffWorkHour>> GetStaffHoursByStaffs(List<int> staffId)
        {
            string query = @"SELECT * FROM StaffWorkingHours Where StaffId IN @key";


            var result = await _db.QueryAsync<StaffWorkHour>(query, new { key = new[] { string.Join(",", staffId) } });

            return result;
        }

        public void Dispose()
        {
            _db.Close();
        }
     
    }
}
