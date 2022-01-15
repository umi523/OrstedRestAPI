using AutoMapper;
using ExcelDataReader;
using OrstedBusiness.Models;
using OrstedData;
using OrstedData.Entities;
using System.Text;

namespace OrstedBusiness
{
    /// <summary>
    /// Business service for employee.
    /// </summary>
    public class EmployeeBusinessService : IEmployeeBusinessService
    {
        #region Properties

        public readonly IMapper _mapper;
        private readonly IEmployeeDataService _dataService;

        #endregion

        #region Constructor

        public EmployeeBusinessService(IMapper mapper, IEmployeeDataService dataService)
        {
            _mapper = mapper;
            _dataService = dataService;
        }

        #endregion

        #region Service Functions

        /// <summary>
        /// Business service function used to fetch all employees.
        /// </summary>
        /// <returns></returns>
        public ServiceResult<IEnumerable<EmployeeModel>> GetEmployees()
        {
            var employees = _dataService.GetAll();
            var employeeModels = _mapper.Map<IEnumerable<EmployeeModel>>(employees);
            return new ServiceResult<IEnumerable<EmployeeModel>>(employeeModels);
        }

        /// <summary>
        /// Business service function used to create single employee.
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public ServiceResult<EmployeeModel> InsertEmployee(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<Employee>(employeeModel);
            _dataService.CreateEmployee(employee);
            return new ServiceResult<EmployeeModel>(employeeModel);
        }

        /// <summary>
        /// Busines service function used to read excel file and create employees.
        /// </summary>
        /// <param name="fileModel"></param>
        /// <returns></returns>
        public ServiceResult<IEnumerable<EmployeeModel>> HandleFile(FileModel fileModel)
        {
            if (fileModel.File == null)
            {
                return new ServiceResult<IEnumerable<EmployeeModel>>(false, "File Doesnt exists");
            }
            try
            {
                List<EmployeeModel> employeeModels = new();
                using (Stream fileStream = fileModel.File.OpenReadStream())
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    var reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                    int index = 0;
                    while (reader.Read())
                    {
                        if (index != 0)
                        {
                            EmployeeStatus status = reader.GetString(3).Equals("Regular") ? EmployeeStatus.Regular : EmployeeStatus.Contracter;
                            employeeModels.Add(new EmployeeModel((int)reader.GetDouble(0), reader.GetString(1), reader.GetString(2), status));
                        }
                        index++;
                    }
                }

                var employees = _mapper.Map<IEnumerable<Employee>>(employeeModels);
                _dataService.InsertBulkEmployees(employees);
                return new ServiceResult<IEnumerable<EmployeeModel>>(employeeModels);

            }
            catch (Exception ex)
            {
                return new ServiceResult<IEnumerable<EmployeeModel>>(false, ex.Message);
            }
        }

        #endregion

    }
}