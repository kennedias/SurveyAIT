/* The main page: Home Page 
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
using System.Web.UI;
using System.Web.UI.WebControls;

using SurveyWebApp.App_Utils;
using SurveyWebApp.App_Control;

namespace SurveyWebApp.App_Pages
{
    /// <summary>
    /// The Home page.
    /// </summary>
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessageLabel.Text = "";
            ErrorMessageLabel.ForeColor = System.Drawing.Color.Black;
        }

        protected void StartSurveyLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(AppConstants.pageSurvey, false);          
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                int staffId = AppUtil.convertStringToInt(UserIdTextBox.Text);
                String staffPassword = PasswordTextBox.Text;

                SurveyLogicControl surveyLogicControl = new SurveyLogicControl();
                if (surveyLogicControl.staffLoginValidation(staffId, staffPassword))
                {
                    SessionControlUtil.setUserID(staffId);
                    Response.Redirect(AppConstants.pageSearch, false);
                }
                else
                {
                    ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
                    ErrorMessageLabel.Text = AppConstants.errorInvalidLogin;
                }

            }
            catch (Exception ex)
            {
                /* IMPORTANT !!
                // No matter what was the error, user can not start, continue or 
                // finalize the pageSurvey. So:
                // - A log (simulation) with the exception was done on the place that have occurred
                // - The exception comes till the final layer, shows a generic error to the user
                // - Insert more information on the log (simulation)
                 * */
                ErrorMessageLabel.Text = AppConstants.errorSystemError;
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;

                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());  
            } 
        }
    }
}