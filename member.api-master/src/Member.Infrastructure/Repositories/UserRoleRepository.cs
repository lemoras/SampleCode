using Dapper;
using Member.Domain.Repositories;
using Member.Domain.Models;
using Member.Domain.Request;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Member.Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IOptions<DBSettings> _dBSettings;
        private readonly IDbConnection _db;

        public UserRoleRepository(IOptions<DBSettings> dbSettings)
        {
            _dBSettings = dbSettings;
            _db = new MySqlConnection(_dBSettings.Value.DatabaseConnection);
        }

        public async Task<int> CreateUserRolehAsync(UserRole entity)
        {
            string sql = @"INSERT INTO UserRole(UserId,RoleId,Active,CreatedDate,CreatedBy) VALUES(@UserId,@RoleId,@Active,@CreatedDate,@CreatedBy)";

            var result = await _db.ExecuteAsync(sql, new { entity.UserId, entity.RoleId, entity.Active, CreatedDate = DateTime.Now, CreatedBy = entity.UserId });

            return entity.UserId;
        }

        public async Task<UserRole> GetUserRoleByUserIdAysnc(int userId)
        {
            string query = @"  SELECT * FROM UserRole Where UserId=@userId";

            var result = await _db.QueryAsync<UserRole>(query, new { userId });

            return result.FirstOrDefault();
        }
    }
}
