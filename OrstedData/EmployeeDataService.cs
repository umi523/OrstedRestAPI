using OrstedData.DataContext;
using OrstedData.Entities;

namespace OrstedData
{
    /// <summary>
    /// Data service for employee.
    /// </summary>
    public class EmployeeDataService : IEmployeeDataService
    {
        #region Properties

        private readonly OrstedDataContext _dataContext;

        #endregion

        #region Constructor

        public EmployeeDataService(OrstedDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion

        #region Service Functions

        /// <summary>
        /// Data service function to create single employee in database.
        /// </summary>
        /// <param name="employee"></param>
        public void CreateEmployee(Employee employee)
        {
            _dataContext.Add(employee);
            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Data service function to fetch all employee from database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAll()
        {
            return _dataContext.Employees.ToList();
        }

        /// <summary>
        /// Data service function to insert bulk employees in database.
        /// </summary>
        /// <param name="employees"></param>
        public void InsertBulkEmployees(IEnumerable<Employee> employees)
        {
            _dataContext.Employees.AddRange(employees);
            _dataContext.SaveChanges();
        }

        #endregion
    }
}