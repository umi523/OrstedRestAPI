using OrstedBusiness.Models;

namespace OrstedBusiness
{
    public interface IEmployeeBusinessService
    {
        public ServiceResult<IEnumerable<EmployeeModel>> GetEmployees();
        public ServiceResult<EmployeeModel> InsertEmployee(EmployeeModel employeeModel);
        public ServiceResult<IEnumerable<EmployeeModel>> HandleFile(FileModel fileModel);
    }
}
