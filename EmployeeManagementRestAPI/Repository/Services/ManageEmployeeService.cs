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
    public class ManageEmployeeService : IManageEmployeeService
    {
		private readonly ConnectionStrings _connectionStrings;
		public ManageEmployeeService(ConnectionStrings connectionStrings)
		{
			_connectionStrings = connectionStrings;
		}
		public string AddEmployee(EmployeePersonal employeePersonal, OrganizationRecord organizationRecord)
        {
			int rowsAffected = 0;
			try
			{
				using MySqlConnection conn = new MySqlConnection(_connectionStrings.DBConnection);
				using (MySqlCommand cmd = new MySqlCommand("addEmployee", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					conn.Open();
					cmd.Parameters.AddWithValue("@ename", employeePersonal.Name);
					cmd.Parameters.AddWithValue("@fname", employeePersonal.Fname);
					cmd.Parameters.AddWithValue("@address", employeePersonal.Address);
					cmd.Parameters.AddWithValue("@dob", employeePersonal.DOB);
					cmd.Parameters.AddWithValue("@pan", employeePersonal.PAN);
					cmd.Parameters.AddWithValue("@phone", employeePersonal.Phone);
					cmd.Parameters.AddWithValue("@salary", organizationRecord.Salary);
					cmd.Parameters.AddWithValue("@designation", organizationRecord.Designation);
					rowsAffected = cmd.ExecuteNonQuery();
				}
				conn.Close();
			}
			catch
			{
				rowsAffected = 0;
			}
			return "Number of rows affected: "+rowsAffected;
		}

		public string UpdateEmployee(EmployeePersonal employeePersonal, OrganizationRecord organizationRecord)
		{
			int rowsAffected = 0;
			try
			{
				using MySqlConnection conn = new MySqlConnection(_connectionStrings.DBConnection);
				using (MySqlCommand cmd = new MySqlCommand("updateEmployee", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					conn.Open();
					cmd.Parameters.AddWithValue("@vemployeeId", employeePersonal.EmployeeId);
					cmd.Parameters.AddWithValue("@vename", employeePersonal.Name);
					cmd.Parameters.AddWithValue("@vfname", employeePersonal.Fname);
					cmd.Parameters.AddWithValue("@vaddress", employeePersonal.Address);
					cmd.Parameters.AddWithValue("@vdob", employeePersonal.DOB);
					cmd.Parameters.AddWithValue("@vpan", employeePersonal.PAN);
					cmd.Parameters.AddWithValue("@vphone", employeePersonal.Phone);
					cmd.Parameters.AddWithValue("@vsalary", organizationRecord.Salary);
					cmd.Parameters.AddWithValue("@vdesignation", organizationRecord.Designation);
					rowsAffected = cmd.ExecuteNonQuery();
				}
				conn.Close();
			}
			catch
			{
				rowsAffected = 0;
			}
			return "Number of rows affected: " + rowsAffected;
		}

		public List<Employee> FetchEmployee()
		{
			List<Employee> ListEmployee = new List<Employee>();
			try
			{
				using MySqlConnection conn = new MySqlConnection(_connectionStrings.DBConnection);
				using (MySqlCommand cmd = new MySqlCommand("fetchEmployees", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					conn.Open();
					MySqlDataReader dr = cmd.ExecuteReader();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							EmployeePersonal employeePersoal = new EmployeePersonal
							{
								EmployeeId = Convert.ToInt32(dr[7]),
								Name = dr[0].ToString(),
								Fname = dr[1].ToString(),
								Address = dr[2].ToString(),
								DOB = Convert.ToDateTime(dr[3]),
								PAN = dr[4].ToString(),
								Email = dr[5].ToString(),
								Phone = dr[6].ToString()
							};
							OrganizationRecord organizationRecord = new OrganizationRecord
							{
								Salary = Convert.ToDouble(dr[8]),
								Designation = dr[9].ToString(),
								JoiningDate = Convert.ToDateTime(dr[10])
							};
							ListEmployee.Add(new Employee
							{
								EmployeePersonal = employeePersoal,
								OrganizationRecord = organizationRecord
							});
						}
					}
				}
				conn.Close();
			}
			catch
			{
				ListEmployee = default;
			}
			return ListEmployee;
		}

		public string DeleteEmployee(EmployeePersonal employeePersonal)
		{
			int rowsAffected = 0;
			try
			{
				using MySqlConnection conn = new MySqlConnection(_connectionStrings.DBConnection);
				using (MySqlCommand cmd = new MySqlCommand("deleteEmployee", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					conn.Open();
					cmd.Parameters.AddWithValue("@vemployeeId", employeePersonal.EmployeeId);
					rowsAffected = cmd.ExecuteNonQuery();
				}
				conn.Close();
			}
			catch
			{
				rowsAffected = 0;
			}
			return "Number of rows affected: " + rowsAffected;
		}
	}
}
