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
                    cmd.Parameters.AddWithValue("@emp_name", employeemodel.emp_name);
                    cmd.Parameters.AddWithValue("@profile_img", employeemodel.profile_img);
                    cmd.Parameters.AddWithValue("@gender", employeemodel.gender);
                    cmd.Parameters.AddWithValue("@department", employeemodel.department);
                    cmd.Parameters.AddWithValue("@salary", employeemodel.salary);
                    cmd.Parameters.AddWithValue("@startDate", employeemodel.startDate);
                    cmd.Parameters.AddWithValue("@notes", employeemodel.notes);

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
                            emp_id = Convert.ToInt32(dr["emp_id"]),
                            emp_name = Convert.ToString(dr["emp_name"]),
                            profile_img = Convert.ToString(dr["profile_img"]),
                            gender = Convert.ToString(dr["gender"]),
                            department = Convert.ToString(dr["department"]),
                            salary = Convert.ToString(dr["salary"]),
                            startDate = Convert.ToDateTime(dr["startDate"]),
                            notes = Convert.ToString(dr["notes"])
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
                    employee.emp_id = Convert.ToInt32(rdr["emp_id"]);
                    employee.emp_name = rdr["emp_name"].ToString();
                    employee.profile_img = rdr["profile_img"].ToString();
                    employee.gender = rdr["gender"].ToString();
                    employee.department = rdr["department"].ToString();
                    employee.salary = rdr["salary"].ToString();
                    employee.startDate = Convert.ToDateTime(rdr["startdate"]);
                    employee.notes = rdr["notes"].ToString();
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
                cmd.Parameters.AddWithValue("@emp_id", employeemodel.emp_id);
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
                cmd.Parameters.AddWithValue("@emp_id", employeeModel.emp_id);
                cmd.Parameters.AddWithValue("@emp_name", employeeModel.emp_name);
                cmd.Parameters.AddWithValue("@profile_img", employeeModel.profile_img);
                cmd.Parameters.AddWithValue("@gender", employeeModel.gender);
                cmd.Parameters.AddWithValue("@department", employeeModel.department);
                cmd.Parameters.AddWithValue("@salary", employeeModel.salary);
                cmd.Parameters.AddWithValue("@startDate", employeeModel.startDate);
                cmd.Parameters.AddWithValue("@notes", employeeModel.notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
