/* The Register page 
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

using SurveyWebApp.App_Objects;
using SurveyWebApp.App_Control;
using SurveyWebApp.App_Utils;

namespace SurveyWebApp.App_Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Black;
                int userId = SessionControlUtil.getUserID();

                if (userId == 0)
                {
                    // To pageRegister is necessary to complete a pageSurvey
                    Response.Redirect(AppConstants.pageSurvey);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = AppConstants.errorSystemError;
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;

               //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }

        }

        /// <summary>
        /// Custom validation for date of birth, invalid if:
        ///  - date greater than today;
        ///  - date less than than 01/01/1910
        /// </summary>
        /// <exception cref="Exception">Exception</exception>
        protected void validateDateOfBirth(object source, ServerValidateEventArgs args)
        {
            try
            {
                DateTime minDate = DateTime.Parse("1910/01/01");
                DateTime maxDate = DateTime.Today;
                DateTime dateTime;

                args.IsValid = (DateTime.TryParse(args.Value, out dateTime)
                                && dateTime < maxDate
                                && dateTime >= minDate);
            }
            catch (Exception ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
            
        }

        protected void ConfirmRegistrationButton_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = SessionControlUtil.getUserID();

                Respondent respondent = new Respondent();
                respondent.RespondentId = userId;
                respondent.GivenNames = GivenNameTextBox.Text;
                respondent.LastName = LastNameTextBox.Text;
                respondent.PhoneNumber = PhoneNumberTextBox.Text;

                if (DateOfBirthCustomValidator.IsValid)
                {
                    DateTime dateOfBirth = DateTime.Parse(DateOfBirthTextBox.Text);
                    respondent.DateOfBirth = dateOfBirth;
                }
                else
                {
                    return;
                }
                
                SurveyLogicControl surveyLogicControl = new SurveyLogicControl();
                surveyLogicControl.updateRespondent(respondent);
                Response.Redirect(AppConstants.pageRegisterComplete);
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = AppConstants.errorSystemError;
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;

               //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }
    }
}