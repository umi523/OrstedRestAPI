using System.ComponentModel.DataAnnotations;

namespace OrstedBusiness.Models
{
    public class EmployeeModel
    {
        #region Constructors

        public EmployeeModel()
        {
        }

        public EmployeeModel(int id, string firstName, string lastName, EmployeeStatus status)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Status = status;
        }

        #endregion

        #region Properties

        public int? ID { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public EmployeeStatus Status { get; set; }

        #endregion
    }

    public enum EmployeeStatus
    {
        Regular,
        Contracter,
    }
}