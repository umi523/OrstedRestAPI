using OrstedData.Entities;

namespace OrstedData
{
    public interface IEmployeeDataService
    {
        public IEnumerable<Employee> GetAll();
        public void CreateEmployee(Employee employeeModel);
        void InsertBulkEmployees(IEnumerable<Employee> employees);
    }
}