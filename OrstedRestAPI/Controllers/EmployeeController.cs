using Microsoft.AspNetCore.Mvc;
using OrstedBusiness;
using OrstedBusiness.Models;

namespace OrstedRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        #region Properties

        private readonly IEmployeeBusinessService _employeeService;

        #endregion

        #region Constructor

        public EmployeeController(IEmployeeBusinessService employeeService)
        {
            _employeeService = employeeService;
        }

        #endregion

        #region Get Methods

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetEmployees()
        {
            return Ok(_employeeService.GetEmployees());
        }

        #endregion

        #region Post Methods

        [HttpPost]
        [Route("Create")]
        public ActionResult Post([FromBody] EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ServiceResult<EmployeeModel>(false, ""));
            }

            return Ok(_employeeService.InsertEmployee(employeeModel));
        }

        [HttpPost]
        [Route("ImportExcel")]
        public ActionResult PostExcel()
        {
            var file = Request.Form.Files.Count == 1 ? Request.Form.Files[0] : null;

            if (file == null || !new List<string>()
            {
                "xlsx",
                "xls",
            }.Contains(file.FileName.Split(".")[1]))
            {
                return BadRequest();
            }

            return Ok(_employeeService.HandleFile(new FileModel() { File = file, FileName = file.FileName }));
        }

        #endregion
    }
}