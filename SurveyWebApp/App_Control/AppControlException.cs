/* Exceptions from App_Control layer
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

namespace SurveyWebApp.App_Control
{
    /// <summary>
    /// Exceptions from App_Control layer.
    /// </summary>
    public class AppControlException: Exception 
    {
        /// <summary>
        /// Exception from App_Control layer.
        /// </summary>
        /// <param name="message">string message</param>
        public AppControlException(string message)
            : base(message)
        {
        }
    }
}
