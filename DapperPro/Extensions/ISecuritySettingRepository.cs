using Dapper;
using DapperPro.Models.IdentityOption;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPro.Extensions
{
    public interface ISecuritySettingRepository
    {
        LockoutOption GetSecuritySetting();
        LockoutOption UpdateSecuritySetting(LockoutOption lockoutOption);
    }
    public class SecuritySettingRepository : ISecuritySettingRepository
    {
        private readonly DbConnection _dapperWrapper;
        private readonly IConfiguration _configuration;

        public SecuritySettingRepository(DbConnection dapperWrapper
            , IConfiguration configuration)
        {
            _dapperWrapper = dapperWrapper;
            _configuration = configuration;
        }
        public LockoutOption GetSecuritySetting()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string sQuery = "SELECT top 1 * From LockoutOption Where Id = 1";
                var response = connection.QueryFirstOrDefault<LockoutOption>(sQuery);
                return response;
            }
        }

        public LockoutOption UpdateSecuritySetting(LockoutOption lockoutOption)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string sQuery = $"Update LockoutOption Set MaxFailedAccessAttempts = {lockoutOption.MaxFailedAccessAttempts} Where Id = {lockoutOption.Id}";
                var result = connection.Execute(sQuery);
                string sQuery1 = "SELECT top 1 * From LockoutOption Where Id = 1";
                var response = connection.QueryFirstOrDefault<LockoutOption>(sQuery1);

                return response;
            }
        }
    }
}
