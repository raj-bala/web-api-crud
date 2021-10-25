using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeesAPI.Controllers;
using System.Net.Http;
using RepositoryLayer;
using System.Web.Http;

namespace EmployeesAPI.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
  

        
        [TestMethod]
        public void GetEmployeeTest()
        {
            EmployeeController controller = new EmployeeController();  //the contoller which you want to test
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetEmployee();

            //Assert
            var request = response.StatusCode;
            var str = request.ToString();
            Assert.AreEqual("OK", request.ToString());
            Assert.AreNotEqual("NotFound", request.ToString());
            Assert.AreNotEqual("BadRequest", request.ToString());

        }

        [TestMethod]
        public void GetAvailableEmployeeByIdTest()
        {
            EmployeeController controller = new EmployeeController();  //the contoller which you want to test
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response1 = controller.GetEmployee(101);

            //Assert
            var request = response1.StatusCode;
            Assert.IsTrue(response1.TryGetContentValue<EmployeeDetail>(out EmployeeDetail employee));
            Assert.AreEqual("Raj", employee.EmployeeName);
            // var str = request.ToString();
            Assert.AreEqual("OK", request.ToString());

        }
        [TestMethod]
        public void GetNotAvailableEmployeeByIdTest()
        {
            EmployeeController controller = new EmployeeController();  //the contoller which you want to test
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response1 = controller.GetEmployee(1000);

            //Assert
            var request = response1.StatusCode;
            var str = request.ToString();
            Assert.AreNotEqual("OK", request.ToString());
            Assert.AreEqual("NotFound", request.ToString());

        }
        [TestMethod]
        public void AddEmployeeTest()
        {
            // Arrange  
            var controller = new EmployeeController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
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
            var actionResult = controller.PostEmployee(employee);

            // Assert  
            Assert.IsNotNull(actionResult.StatusCode.ToString());
            Assert.AreEqual("Created", actionResult.StatusCode.ToString());
        }
        [TestMethod]
        public void DeleteEmployeesTest()
        {
            // Arrange  
            var controller = new EmployeeController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act  
            var actionResult = controller.DeleteEmployee(131);


            // Assert  
            Assert.IsNotNull(actionResult.StatusCode.ToString());
            Assert.AreEqual("OK", actionResult.StatusCode.ToString());
            Assert.AreNotEqual("Created", actionResult.StatusCode.ToString());
            Assert.AreNotEqual("NotFound", actionResult.StatusCode.ToString());
        }
        [TestMethod]
        public void DeleteEmployeesNotFoundTest()
        {
            // Arrange  
            bool check = false;
            var controller = new EmployeeController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act  
            var actionResult = controller.DeleteEmployee(1377);
            var response = actionResult.StatusCode.ToString();
            if (response != null)
            {
                check = true;
            }

            // Assert  
            Assert.IsNotNull(actionResult.StatusCode.ToString());
            Assert.AreNotEqual("OK", actionResult.StatusCode.ToString());
            Assert.AreNotEqual("Created", actionResult.StatusCode.ToString());
            Assert.AreEqual("NotFound", actionResult.StatusCode.ToString());
            Assert.AreNotSame("OK", actionResult.StatusCode.ToString());
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            // Arrange  
            var controller = new EmployeeController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            EmployeeDetail employee = new EmployeeDetail
            {
                EmployeeID = 107,
                EmployeeName = "abc1",
                MobileNumber = "9875345676",
                Email = "test1@gmail.com",
                Position = "Engineer",
                Salary = 40000,

            };
            // Act  
            var actionResult = controller.PutEmployee(employee.EmployeeID, employee);

            // Assert  
            Assert.IsNotNull(actionResult.StatusCode.ToString());
            Assert.AreEqual("OK", actionResult.StatusCode.ToString());
        }
    }
}
