using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static ExceptionLayer.UserDefinedException;

namespace RepositoryLayer
{
    public class Repository : IRepository
    {
        public List<EmployeeDetail> GetEmployee()
        {
            using (EmployeesDBEntities Entities = new EmployeesDBEntities())
            {
                List<EmployeeDetail> entity = Entities.EmployeeDetails.ToList();
                try
                {
                    if (entity != null)
                    {
                        return entity;
                    }
                    else
                    {
                        throw new GetListException("No Data found");
     
                    }
                }
                catch (Exception ex)
                {
                    throw new GetListException(ex.Message);
                }
            }
        }
        public EmployeeDetail GetEmployee(int id)
        {
            using (EmployeesDBEntities Entities = new EmployeesDBEntities())
            {
                EmployeeDetail employee = new EmployeeDetail();
               var entity = Entities.EmployeeDetails.SingleOrDefault(p => p.EmployeeID == id);
                try
                {
                    if (entity != null)
                    {
                        employee = entity;
                        return employee;
                    }
                    else
                    {
                        return null;
                    }

                }
                catch (Exception ex)
                {
                    throw new GetListException(ex.Message);
                }
            }
        }
        public void PostEmployee(EmployeeDetail employee)
        {
            using (EmployeesDBEntities Entities = new EmployeesDBEntities())
            {
                try
                {
                    Entities.EmployeeDetails.Add(employee);
                    Entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new DataException(ex.Message);
                }
            }
        }
        public void DeleteEmployee(int id)
        {
            using (EmployeesDBEntities Entities = new EmployeesDBEntities())
            {
                try
                {
                    var employee = Entities.EmployeeDetails.SingleOrDefault(p => p.EmployeeID == id);
                    if (employee == null)
                        throw new GetListException("Employee details not found ");
                    Entities.EmployeeDetails.Remove(employee);
                    Entities.SaveChanges();

                    
                }
                catch (Exception ex)
                {
                    throw new DataException(ex.Message);
                }
            }
        }
        public void PutEmployee(int id, EmployeeDetail employee)
        {
            using (EmployeesDBEntities Entities = new EmployeesDBEntities())
            {
                try
                {
                    var entity = Entities.EmployeeDetails.SingleOrDefault(p => p.EmployeeID == id);
                    if (entity == null)
                        throw new GetListException("Employee details not found"); 
                    entity.EmployeeName = employee.EmployeeName;
                    entity.MobileNumber = employee.MobileNumber;
                    entity.Email = employee.Email;
                    entity.Position = employee.Position;
                    entity.Salary = employee.Salary;
                    Entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new DataException(ex.Message);
                }
            }
        }
    }

    
}
