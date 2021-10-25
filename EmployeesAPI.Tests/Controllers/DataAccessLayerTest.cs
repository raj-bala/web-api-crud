using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryLayer;
using System.Web.Http;
using System.Net.Http;

namespace EmployeesAPI.Tests.Controllers
{
    [TestClass]
    public class DataAccessLayerTest
    {
        [TestMethod]
        public void GetEmployeeTest()
        {
            // Arrange  
            IRepository repo = new Repository();
            // Act
            List < EmployeeDetail > list = new List<EmployeeDetail>();
            try
            {
               list = repo.GetEmployee();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            //Assert
            Assert.AreEqual(27, list.Count);
            Assert.AreNotEqual(0, list.Count);
            

        }
        [TestMethod]
        public void GetAvailableEmployeeByIdTest()
        {
            // Arrange  
            IRepository repo = new Repository();

            // Act
            EmployeeDetail employee = new EmployeeDetail();
            employee = repo.GetEmployee(101);

            //Assert
            
            Assert.AreEqual("Raj", employee.EmployeeName);
            Assert.AreEqual(101, employee.EmployeeID);

        }
        [TestMethod]
        public void GetNotAvailableEmployeeByIdTest()
        {
            // Arrange  
            IRepository repo = new Repository();

            // Act
            EmployeeDetail employee = new EmployeeDetail();
            try
            {           
            employee = repo.GetEmployee(1000);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            //Assert
            Assert.IsNull(employee);

        }
        [TestMethod]
        public void AddEmployeeTest()
        {
            // Arrange  
            IRepository repo = new Repository();
            EmployeeDetail employee = new EmployeeDetail
            {
                // EmployeeID = 108,
                EmployeeName = "Test7",
                MobileNumber = "9875345676",
                Email = "test1@gmail.com",
                Position = "Engineer",
                Salary = 40000,

            };
            // Act  
            try
            {
                repo.PostEmployee(employee);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }                       
        }
        [TestMethod]
        public void DeleteEmployeesTest()
        {
            // Arrange  
            IRepository repo = new Repository();
            // Act  
            try
            {
                repo.DeleteEmployee(151);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Employee details not found ");
            }

        }       

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            // Arrange  
            IRepository repo = new Repository();
            EmployeeDetail employee = new EmployeeDetail
            {
                EmployeeID = 108,
                EmployeeName = "abc1",
                MobileNumber = "9875345676",
                Email = "test1@gmail.com",
                Position = "Engineer",
                Salary = 40000,

            };
            // Act  
            try
            {
                repo.PutEmployee(employee.EmployeeID, employee);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Employee details not found");
            }
            
        }
    }
}
