using Microsoft.EntityFrameworkCore;
using OrstedData.Entities;

namespace OrstedData.DataContext
{
    /// <summary>
    /// Data context class.
    /// </summary>
    public class OrstedDataContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public OrstedDataContext(DbContextOptions<OrstedDataContext> options)
               : base(options)
        {
        }

        #endregion

        #region Entities

        public DbSet<Employee> Employees { get; set; }

        #endregion

    }
}