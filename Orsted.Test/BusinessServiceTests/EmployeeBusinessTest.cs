using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrstedBusiness;
using OrstedBusiness.Models;
using OrstedData;
using OrstedData.Entities;
using OrstedRestAPI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Orsted.Test.BusinessServiceTests
{
    [TestClass]
    public class EmployeeBusinessTest
    {
        #region Properties

        private readonly Mock<IEmployeeDataService> _mockIEmployeeDataService;
        private readonly EmployeeBusinessService _employeeBusinessService;
        private readonly List<Employee> _testRecords = new List<Employee>()
        {
           new Employee(){ID= 1, FirstName="Umair", LastName="Hassan", Status = (int)EmployeeStatus.Contracter },
           new Employee(){ID= 2, FirstName="John", LastName="Doe", Status = (int)EmployeeStatus.Contracter },
           new Employee(){ID= 3, FirstName="Jane", LastName="Hassan", Status = (int)EmployeeStatus.Contracter },
           new Employee(){ID= 4, FirstName="Robert", LastName="Lewandoski", Status = (int)EmployeeStatus.Contracter },
           new Employee(){ID= 5, FirstName="Chris", LastName="Cairns", Status = (int)EmployeeStatus.Contracter },
           new Employee(){ID= 6, FirstName="Tamoor", LastName="Khalid", Status = (int)EmployeeStatus.Contracter },
           new Employee(){ID= 7, FirstName="Fatemah", LastName="Shahbaz", Status = (int)EmployeeStatus.Contracter },
           new Employee(){ID= 8, FirstName="Julian", LastName="Ker", Status = (int)EmployeeStatus.Contracter },
        };

        #endregion

        #region Constructor

        public EmployeeBusinessTest()
        {
            _mockIEmployeeDataService = new Mock<IEmployeeDataService>();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<EmployeeModel>(It.IsAny<Employee>()))
            .Returns((EmployeeModel source) =>
            {
                return source;
            });
            _mockIEmployeeDataService.Setup(x => x.GetAll()).Returns(_testRecords);
            _mockIEmployeeDataService.Setup(x => x.CreateEmployee(It.IsAny<Employee>()));
            _mockIEmployeeDataService.Setup(x => x.InsertBulkEmployees(It.IsAny<IEnumerable<Employee>>()));
            _employeeBusinessService = new EmployeeBusinessService(mockMapper.Object, _mockIEmployeeDataService.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void Test_GetEmployeesMethod()
        {
            //Act
            var result = _employeeBusinessService.GetEmployees();

            //Assert
            Assert.IsTrue(result?.Success);
        }

        [TestMethod]
        public void Test_PostExcelMethod()
        {
            //Arrange
            var file = new FileModel();

            //Act
            var result = _employeeBusinessService.HandleFile(file);

            //Assert
            Assert.IsFalse(result?.Success);
        }

        [TestMethod]
        public void Test_InsertMethod()
        {
            //Arrange
            var employeeModel = new EmployeeModel(99, "Temp", "Record", EmployeeStatus.Contracter);

            //Act
            var result = _employeeBusinessService.InsertEmployee(employeeModel);

            //Assert
            Assert.IsTrue(result?.Success);
        }

        #endregion
    }
}