using BusinessLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeesAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage GetEmployee()
        {
            try
            {
                IBusinessLogic business = new BusinessLogic();

                List<EmployeeDetail> employee = business.GetEmployee();
                if (employee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employee);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage GetEmployee(int id)
        {

            try
            {
                IBusinessLogic business = new BusinessLogic();

                EmployeeDetail employee = business.GetEmployees(id);
                if (employee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employee);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        public HttpResponseMessage PostEmployee([FromBody] EmployeeDetail employee)
        {

            try
            {
                IBusinessLogic business = new BusinessLogic();
                business.PostEmployees(employee);
                return Request.CreateResponse(HttpStatusCode.Created, "Created");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Data not inserted");
            }

        }
        public HttpResponseMessage DeleteEmployee(int id)
        {
            using (EmployeesDBEntities Entities = new EmployeesDBEntities())
            {
                try
                {
                    IBusinessLogic business = new BusinessLogic();
                    
                    EmployeeDetail employee = business.GetEmployees(id);
                    if (employee == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee details not found to delete");
                    business.DeleteEmployees(id);

                    return Request.CreateResponse(HttpStatusCode.OK, "Employee details Deleted Successfully");
                }
                catch (Exception)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Employee details not deleted");
                }
            }
        }
        public HttpResponseMessage PutEmployee(int id, [FromBody] EmployeeDetail employee)
        {
            using (EmployeesDBEntities Entities = new EmployeesDBEntities())
            {
                try
                {
                    IBusinessLogic business = new BusinessLogic();

                    EmployeeDetail employeeDeatil = business.GetEmployees(id);
                    if (employeeDeatil == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee details not found ");
                    business.PutEmployees(id, employee);

                    return Request.CreateResponse(HttpStatusCode.OK, "Employee details Updated Successfully");
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }
    }
}
