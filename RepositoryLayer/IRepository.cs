using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRepository
    {
        List<EmployeeDetail> GetEmployee();
        EmployeeDetail GetEmployee(int id);
        void PostEmployee(EmployeeDetail employee);
        void DeleteEmployee(int id);
        void PutEmployee(int id, EmployeeDetail employee);
    }
}
