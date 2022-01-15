using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrstedBusiness;
using OrstedBusiness.Models;
using OrstedRestAPI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Orsted.Test.ControllerTests
{
    [TestClass]
    public class EmployeeControllerTest
    {
        #region Properties

        private readonly Mock<IEmployeeBusinessService> _mockIEmployeeBusinessService;
        private readonly EmployeeController? _employeeController;
        private readonly List<EmployeeModel> _testRecords = new List<EmployeeModel>()
        {
           new EmployeeModel(1, "Umair", "Hassan", EmployeeStatus.Contracter),
           new EmployeeModel(2, "John", "Doe", EmployeeStatus.Contracter),
           new EmployeeModel(3, "Jane", "Hassan", EmployeeStatus.Contracter),
           new EmployeeModel(4, "Robert", "Lewandoski", EmployeeStatus.Contracter),
           new EmployeeModel(5, "Chris", "Cairns", EmployeeStatus.Contracter),
           new EmployeeModel(6, "Tamoor", "Khalid", EmployeeStatus.Contracter),
           new EmployeeModel(7, "Fatemah", "Shahbaz", EmployeeStatus.Contracter),
           new EmployeeModel(8, "Julian", "Ker", EmployeeStatus.Contracter),
        };

        #endregion

        #region Constructor
        public EmployeeControllerTest()
        {
            _mockIEmployeeBusinessService = new Mock<IEmployeeBusinessService>();
            _mockIEmployeeBusinessService.Setup(x => x.GetEmployees()).Returns(new ServiceResult<IEnumerable<EmployeeModel>>(_testRecords));
            _mockIEmployeeBusinessService.Setup(x => x.InsertEmployee(It.IsAny<EmployeeModel>())).Returns(new ServiceResult<EmployeeModel>(_testRecords.First()));
            _mockIEmployeeBusinessService.Setup(x => x.HandleFile(It.IsAny<FileModel>())).Returns(new ServiceResult<IEnumerable<EmployeeModel>>(_testRecords));
            _employeeController = new EmployeeController(_mockIEmployeeBusinessService.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void Test_GetEmployeesMethod()
        {
            //Act
            var result = (_employeeController.GetEmployees() as OkObjectResult).Value as ServiceResult<IEnumerable<EmployeeModel>>;

            //Assert
            Assert.IsTrue(result?.Success);
        }

        [TestMethod]
        public void Test_PostExcelMethod()
        {
            var file = new FileModel();
            //Act
            var result = (_employeeController.PostExcel(file) as OkObjectResult).Value as ServiceResult<IEnumerable<EmployeeModel>>;

            //Assert
            Assert.IsTrue(result?.Success);
        }

        [TestMethod]
        public void Test_InsertMethod()
        {
            //Arrange
            var employeeModel = new EmployeeModel(99, "Temp", "Record", EmployeeStatus.Contracter);

            //Act
            var result = (_employeeController.Post(employeeModel) as OkObjectResult).Value as ServiceResult<EmployeeModel>;

            //Assert
            Assert.IsTrue(result?.Success);
        }

        #endregion
    }
}