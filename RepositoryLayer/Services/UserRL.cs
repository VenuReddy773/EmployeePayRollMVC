using ModelLayer.Services;
using RepositoryLayer.Interface;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;
using System;

namespace RepositoryLayer.Services
{
    public class UserRL:IUserRL
    {
        private readonly IConfiguration Configuration;
        public UserRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public void addEmployee(EmployeeModel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                {
                    SqlCommand cmd = new SqlCommand("addEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Emp_name", employeemodel.Emp_name);
                    cmd.Parameters.AddWithValue("@Profile_img", employeemodel.Profile_img);
                    cmd.Parameters.AddWithValue("@Gender", employeemodel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeemodel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeemodel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employeemodel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employeemodel.Notes);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public List<EmployeeModel> getEmployeeList()
        {
            List<EmployeeModel> EmpList = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("allEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    EmpList.Add(
                        new EmployeeModel
                        {
                            Emp_id = Convert.ToInt32(dr["Emp_id"]),
                            Emp_name = Convert.ToString(dr["Emp_name"]),
                            Profile_img = Convert.ToString(dr["Profile_img"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            Department = Convert.ToString(dr["Department"]),
                            Salary = Convert.ToInt32(dr["Salary"]),
                            StartDate = Convert.ToDateTime(dr["StartDate"]),
                            Notes = Convert.ToString(dr["Notes"])
                        }
                        );
                }
            }
            return EmpList;
        }

        public EmployeeModel getEmployeeById(int? id)
        {
            EmployeeModel employee = new EmployeeModel();

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                string sqlQuery = "SELECT * FROM employeeDetails WHERE emp_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                    employee.Emp_name = rdr["Emp_name"].ToString();
                    employee.Profile_img = rdr["Profile_img"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]); 
                    employee.StartDate = Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();
                }
            }
            return employee;
        }

        public void deleteEmployee(EmployeeModel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("deleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_id", employeemodel.Emp_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void editEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("updateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_id", employeeModel.Emp_id);
                cmd.Parameters.AddWithValue("@Emp_name", employeeModel.Emp_name);
                cmd.Parameters.AddWithValue("@Profile_img", employeeModel.Profile_img);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
