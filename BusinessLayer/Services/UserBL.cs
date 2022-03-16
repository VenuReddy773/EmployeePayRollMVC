using BusinessLayer.Interface;
using ModelLayer.Services;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL:IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void addEmployee(EmployeeModel employee)
        {
            try
            {
                this.userRL.addEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteEmployee(EmployeeModel employee)
        {
            try
            {
                this.userRL.deleteEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void editEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.userRL.editEmployee(employeeModel);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public EmployeeModel getEmployeeById(int? id)
        {
            try
            {
               return this. userRL.getEmployeeById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<EmployeeModel> getEmployeeList()
        {
            try
            {
                return this.userRL.getEmployeeList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
