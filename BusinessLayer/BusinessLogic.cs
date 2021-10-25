using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessLogic: IBusinessLogic
    {
        public List<EmployeeDetail> GetEmployee()
        {
            try
            {
                IRepository repo = new Repository();
                List<EmployeeDetail> employee = repo.GetEmployee();
                return employee;
            }
            catch
            {
                throw;
            }
        }
        public EmployeeDetail GetEmployees(int id)
        {
            try
            {
                IRepository repo = new Repository();
                EmployeeDetail employee = repo.GetEmployee(id);
                if (employee != null)
                    return employee;
                else
                    return null;
            }
            catch
            {
                throw;
            }
        }
        public void PostEmployees(EmployeeDetail employee)
        {
            try
            {
                IRepository repo = new Repository();
                repo.PostEmployee(employee);
               
            }
            catch
            {
                throw;
            }
        }
        public void DeleteEmployees(int id)
        {
            try
            {
                IRepository repo = new Repository();
                repo.DeleteEmployee(id);
            }
            catch
            {
                throw;
            }
        }
        public void PutEmployees(int id, EmployeeDetail employee)
        {
            try
            {
                IRepository repo = new Repository();
                repo.PutEmployee(id, employee);
            }
            catch
            {
                throw;
            }
        }
    }
}
