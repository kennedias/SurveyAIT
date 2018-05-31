/* Object that represents a Staff
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

using SurveyWebApp.App_DAO;

namespace SurveyWebApp.App_Objects
{
    /// <summary>
    /// Object that represents a Staff.
    /// </summary>
    ///
    public class Staff
    {
        private int _staffId;
        private String _password;

        public int StaffId
        {
            get { return (int)_staffId; }
            set { _staffId = value; }
        }

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// Get a Staff by staffID and staffPassword
        /// </summary>
        /// <param name="staffId">int staffId</param>
        /// <param name="staffPassword">String staffPassword</param>
        /// <returns>Staff</returns>
        /// <exception cref="Exception">Exception</exception>
        public Staff getStaffByIdPassword(int staffId, String staffPassword)
        {
            try
            {
                Staff staff = new Staff();
                StaffDAO staffDAO = new StaffDAO();

                staff = staffDAO.getStaffByIdAndPassword(staffId, staffPassword);

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