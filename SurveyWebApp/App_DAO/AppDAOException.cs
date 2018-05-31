/* Exceptions from App_DAO layer
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

namespace SurveyWebApp.App_DAO
{
    /// <summary>
    /// Exceptions from App_DAO layer.
    /// </summary>
    public class AppDAOException: Exception
    {
        /// <summary>
        /// Exception from App_DAO layer.
        /// </summary>
        /// <param name="message">string message</param>
        public AppDAOException(string message)
            : base(message)
        {
        }

    }
}