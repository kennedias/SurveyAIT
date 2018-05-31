/* Contains all data access from Staff
* 
* Project: AIT Survey
* Developer: Kennedy Oliveira - ID 5399
* Data of release: 14/09/2017
* Version: 1.0 - Release
* 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using SurveyWebApp.App_Objects;
using SurveyWebApp.App_Utils;

namespace SurveyWebApp.App_DAO
{
    /// <summary>
    /// Data access from Staff
    /// </summary>
    public class StaffDAO
    {
        DatabaseConnector databaseConnector;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="Exception">Exception</exception>
        public StaffDAO()
        {
            try
            {
                //Create and open a database connection 
                databaseConnector = new DatabaseConnector();
            }
            catch (Exception ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }            
        }

        /// <summary>
        /// Get a Staff by staffID and staffPassword
        /// </summary>
        /// <param name="staffId">int staffId</param>
        /// <param name="staffPassword">String staffPassword</param>
        /// <returns>Staff</returns>
        /// <exception cref="Exception">Exception</exception>
        public Staff getStaffByIdAndPassword(int staffId, String staffPassword)
        {            
            try
            {
                Staff staff = new Staff();
                if (!string.IsNullOrEmpty(staffPassword) && !string.IsNullOrWhiteSpace(staffPassword))
                {
                    // Fill query parameters
                    SqlCommand command = new SqlCommand(AppDAOConstants.getStaffById, databaseConnector.connection);
                    command.Parameters.AddWithValue(AppDAOConstants.staffId, staffId);
                    command.Parameters.AddWithValue(AppDAOConstants.staffPassword, staffPassword);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        //Fill the Staff object with the correspondent values. 
                        staff.StaffId = Convert.ToInt32(reader[AppDAOConstants.staffId].ToString());
                    }
                    databaseConnector.connection.Close();
                }
                else
                {
                    throw new AppDAOException(AppConstants.errorInvalidDAOParameters + AppDAOConstants.staffPassword);
                }
                
                return staff;
            }
            catch (Exception ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }
    }
}