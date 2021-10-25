using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBusinessLogic
    {
        List<EmployeeDetail> GetEmployee();
        EmployeeDetail GetEmployees(int id);
        void PostEmployees(EmployeeDetail employee);
        void DeleteEmployees(int id);
        void PutEmployees(int id, EmployeeDetail employee);

    }
}
