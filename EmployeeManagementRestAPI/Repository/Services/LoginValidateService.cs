using EmployeeManagementRestAPI.AppSettingsManager;
using EmployeeManagementRestAPI.Models;
using EmployeeManagementRestAPI.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementRestAPI.Repository.Services
{
    public class LoginValidateService : ILoginValidateService
    {
        private readonly ConnectionStrings _connectionStrings;
        public LoginValidateService(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }
        public OrganizationRecord ValidateCredentails(EmployeePersonal employee)
        {
			OrganizationRecord orgRecord = new OrganizationRecord();
			try
			{
                using MySqlConnection conn = new MySqlConnection(_connectionStrings.DBConnection);
                using (MySqlCommand cmd = new MySqlCommand("ValidateLoginCredentials", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@email", employee.Email);
                    cmd.Parameters.AddWithValue("@pass", employee.Pass);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            orgRecord.Designation = dr[0].ToString();
                        }
                    }
                }
                conn.Close();
            }
			catch
			{
				orgRecord = default;
			}
            return orgRecord;
        }
    }
}
