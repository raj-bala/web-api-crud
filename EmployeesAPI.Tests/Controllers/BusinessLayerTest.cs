using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using RepositoryLayer;

namespace EmployeesAPI.Tests.Controllers
{
    
    [TestClass]
    public class BusinessLayerTest
    {
        [TestMethod]
        public void GetEmployeeTest()
        {
            // Arrange  
            IBusinessLogic business = new BusinessLogic();
            // Act
            List<EmployeeDetail> list = new List<EmployeeDetail>();
            try
            {
                list = business.GetEmployee();
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
            IBusinessLogic business = new BusinessLogic();

            // Act
            EmployeeDetail employee = new EmployeeDetail();
            employee = business.GetEmployees(101);

            //Assert

            Assert.AreEqual("Raj", employee.EmployeeName);
            Assert.AreEqual(101, employee.EmployeeID);

        }
        [TestMethod]
        public void GetNotAvailableEmployeeByIdTest()
        {
            // Arrange  
            IBusinessLogic business = new BusinessLogic();

            // Act
            EmployeeDetail employee = new EmployeeDetail();
            try
            {
                employee = business.GetEmployees(1000);
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
            IBusinessLogic business = new BusinessLogic();
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
                business.PostEmployees(employee);
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
            IBusinessLogic business = new BusinessLogic();
            // Act  
            try
            {
                business.DeleteEmployees(150);
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
            IBusinessLogic business = new BusinessLogic();
            EmployeeDetail employee = new EmployeeDetail
            {
                EmployeeID = 111,
                EmployeeName = "abc1",
                MobileNumber = "9875345676",
                Email = "test1@gmail.com",
                Position = "Engineer",
                Salary = 40000,

            };
            // Act  
            try
            {
                business.PutEmployees(employee.EmployeeID, employee);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Employee details not found");
            }

        }


    }
}
