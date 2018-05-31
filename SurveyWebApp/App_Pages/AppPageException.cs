/* Exceptions from App_Pages layer
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

namespace SurveyWebApp.App_Pages
{
    /// <summary>
    /// Exceptions from App_Pages layer.
    /// </summary>
    public class AppPageException : Exception
    {
        /// <summary>
        /// Exception from App_Pages layer.
        /// </summary>
        /// <param name="message">string message</param>
        public AppPageException(string message)
            : base(message)
        {
        }
    }
}