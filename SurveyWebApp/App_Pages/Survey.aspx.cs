/* The dynamic Survey page that contains Question and Answers Options 
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

using System.Configuration;
using System.Collections;

namespace SurveyWebApp.App_Pages
{
    /// <summary>
    /// The dynamic Survey page.
    /// </summary>
    public partial class Survey : System.Web.UI.Page
    {     
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ErrorMessageLabel.Text = "";
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Black;
                SurveyLogicControl surveyLogicControl = new SurveyLogicControl();
                Question question = new Question();
                int currentQuestionSequence = 0;

                if (string.IsNullOrEmpty(SessionControlUtil.getUserIPAddress()))                
                {
                    string userIPAddress = AppUtil.getUserIPAddress();

                    if (!string.IsNullOrEmpty(userIPAddress))
                    {
                        Respondent respondent = new Respondent();
                        respondent.IpAddress = userIPAddress;
                        int userID = surveyLogicControl.insertRespondent(respondent);
                        SessionControlUtil.setUserID(userID);
                        SessionControlUtil.setUserIPAddress(userIPAddress);
                    }

                    // First time.
                    // Get the first question and set the session attributes control                    
                    question = surveyLogicControl.getNextQuestionBySequence(currentQuestionSequence);
                    SessionControlUtil.setCurrentQuestion(question);
                    SessionControlUtil.setCurrentQuestionSequence(question.QuestionSequence);
                    SessionControlUtil.incrementCurrentQuestionLevel();
                    HttpContext.Current.Session[AppConstants.sessionQuestionsAnswerList] = new List<SurveyQuestionAnswer>();
                }
                else
                {
                    question = SessionControlUtil.getCurrentQuestion();
                }

                this.displayQuestion(question);                
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


        protected void NextButton_Click(object sender, EventArgs e)
        {
            // Get the answer from last question and store on session 
            // after pageload and all ui elements re-built dynamically and viewstate copied over
            this.setSurveyQuestionAnswer();

            //Get the next question 
            int currentQuestionSequence = SessionControlUtil.getCurrentQuestionSequence();
            Question question = null;
            SurveyLogicControl surveyLogicControl = new SurveyLogicControl();

            // Verify the level and additional questions to show before continuing 
            // the sequence of the main questions
            if (SessionControlUtil.getCurrentQuestionsLevel() > 1)
            {
                int nextQuestionId = SessionControlUtil.getNexQuestionIdFromAdditionalQuestionCurrentLevelList();
                question = surveyLogicControl.getQuestionAndAnswersByIQuestionID(nextQuestionId);
            }
            else
            {
                question = surveyLogicControl.getNextQuestionBySequence(currentQuestionSequence);

                //If there is not more questions the method surveyLogicControl.getNextQuestionBySequence
                // will return zero that means there are no more questions on sequence. 
                if (question.QuestionSequence == 0)
                {
                    // Get the list of questions answered from session
                    List<SurveyQuestionAnswer> surveyQuestionAnswerList = new List<SurveyQuestionAnswer>();
                    surveyQuestionAnswerList = SessionControlUtil.getSurveyQuestionAnswerList();
                
                    // Call the logic control to record the complete pageSurvey in the database
                    surveyLogicControl.insertAnsweredSurvey(surveyQuestionAnswerList);

                    Response.Redirect(AppConstants.pageSurveyComplete);
                }
                else
                {
                    SessionControlUtil.setCurrentQuestionSequence(question.QuestionSequence);
                }                
            }

            // Store the next question to be showed on the session
            // as current question.
            SessionControlUtil.setCurrentQuestion(question);
            

            // Redirect back to pageSurvey.aspx to continue the pageSurvey 
            // on next question.
            Response.Redirect(AppConstants.pageSurvey);
            
        }

        /// <summary>
        /// Verify the type and show the correspondent control with 
        /// the answers options on the pageSurvey page.
        /// Controls type are:
        ///     TextBox for text answers
        ///     CheckBox for multiple answers between options
        ///     RadioBox for unique answer between options
        ///     DropDownList for unique answer between options
        /// </summary>
        /// <param name="question">Question question</param>
        /// <exception cref="Exception">Exception</exception>
        /// <exception cref="AppPageException">AppPageException</exception>
        private void displayQuestion(Question question)
        {
            try
            {                 
                if (question.SurveyQuestionDomainId == AppConstants.fieldTypeTextId)
                {
                    TextBoxControl textControl = (TextBoxControl)LoadControl(AppConstants.controlTextBoxControl);
                    textControl = (TextBoxControl)LoadControl(AppConstants.controlTextBoxControl);
                    textControl.ID = AppConstants.controlTextBoxControl;
                    textControl.QuestionDescriptionLabel.Text = question.QuestionDescription;
                    textControl.QuestionAnswerTextBox.Text = "";                    

                    SurveyCheckboxPlaceHolder.Controls.Clear();
                    SurveyTextPlaceHolder.Controls.Add(textControl);
                }
                else if (question.SurveyQuestionDomainId == AppConstants.fieldTypeCheckBoxId)
                {
                    CheckBoxControl checkBoxControl = (CheckBoxControl)LoadControl(AppConstants.controlCheckBoxControl);
                    checkBoxControl = (CheckBoxControl)LoadControl(AppConstants.controlCheckBoxControl);
                    checkBoxControl.ID = AppConstants.controlCheckBoxControl;
                    checkBoxControl.QuestionDescriptionLabel.Text = question.QuestionDescription;

                    for (var i = 0; i < question.AnswerOptionsList.Count; i++)
                    {
                        ListItem item = new ListItem(question.AnswerOptionsList[i].AnswerDescription,
                                                     question.AnswerOptionsList[i].SurveyAnswerOptionId.ToString());
                        checkBoxControl.QuestionAnswerCheckBoxList.Items.Add(item);
                    }

                    checkBoxControl.QuestionAnswerCheckBoxList.ClearSelection();

                    SurveyCheckboxPlaceHolder.Controls.Clear();
                    SurveyCheckboxPlaceHolder.Controls.Add(checkBoxControl);
                }
                else if (question.SurveyQuestionDomainId == AppConstants.fieldTypeRadioButtonId)
                {
                    RadioButtonControl radioButtonControl = 
                        (RadioButtonControl)LoadControl(AppConstants.controlRadioButtonControl);
                    radioButtonControl.ID = AppConstants.controlRadioButtonControl;
                    radioButtonControl.QuestionDescriptionLabel.Text = question.QuestionDescription;
                    
                    SurveyRadioButtonPlaceHolder.Controls.Add(radioButtonControl);

                    for (var i = 0; i < question.AnswerOptionsList.Count; i++)
                    {
                        ListItem item = new ListItem(question.AnswerOptionsList[i].AnswerDescription,
                                                     question.AnswerOptionsList[i].SurveyAnswerOptionId.ToString());
                        radioButtonControl.QuestionAnswerRadioButtonList.Items.Add(item);
                    }
                }
                else if (question.SurveyQuestionDomainId == AppConstants.fieldTypeDropDownListId)
                {
                    DropDownListControl dropDownListControl = 
                        (DropDownListControl)LoadControl(AppConstants.controlDropDownListControl);
                    dropDownListControl.ID = AppConstants.controlDropDownListControl;
                    dropDownListControl.QuestionDescriptionLabel.Text = question.QuestionDescription;

                    SurveyDropDownListPlaceHolder.Controls.Add(dropDownListControl);

                    for (var i = 0; i < question.AnswerOptionsList.Count; i++)
                    {
                        ListItem item = new ListItem(question.AnswerOptionsList[i].AnswerDescription, 
                                                     question.AnswerOptionsList[i].SurveyAnswerOptionId.ToString());
                        dropDownListControl.QuestionAnswerDropDownList.Items.Add(item);
                    }
                }
                else
                {
                    throw new AppPageException(AppConstants.errorInvalidQuestionDomain + " " + question.SurveyQuestionDomainId);
                }
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
        /// Read and store the answers of last question and set in the session. 
        /// Get answers options from the pageSurvey page.
        /// Read the controls type:
        ///     TextBox for text answers
        ///     CheckBox for multiple answers between options
        ///     RadioBox for unique answer between options
        ///     DropDownList for unique answer between options
        /// </summary>
        /// <exception cref="Exception">Exception</exception>
        /// <exception cref="AppPageException">AppPageException</exception>
        private void setSurveyQuestionAnswer()
        {
            try
            {
                List<SurveyQuestionAnswer> surveyQuestionAnswerList = SessionControlUtil.getSurveyQuestionAnswerList();
                Question currentQuestion = SessionControlUtil.getCurrentQuestion();
                ArrayList additionalQuestions = new ArrayList();
                List<int> additionalQuestionsList = new List<int>();

                if (currentQuestion.SurveyQuestionDomainId == AppConstants.fieldTypeTextId)
                {
                    TextBoxControl textBoxControl =
                        (TextBoxControl)SurveyCheckboxPlaceHolder.FindControl(AppConstants.controlTextBoxControl);

                    if (textBoxControl != null)
                    {
                        SurveyQuestionAnswer surveyQuestionAnswer = new SurveyQuestionAnswer();
                        surveyQuestionAnswer.RespondentId = SessionControlUtil.getUserID();
                        surveyQuestionAnswer.SurveyQuestionId = currentQuestion.QuestionId;

                        if (textBoxControl.QuestionAnswerTextBox.Text.Trim() != null)
                            surveyQuestionAnswer.AnswerDescription = textBoxControl.QuestionAnswerTextBox.Text.Trim();

                        surveyQuestionAnswerList.Add(surveyQuestionAnswer);
                        SessionControlUtil.setSurveyQuestionAnswerList(surveyQuestionAnswerList);
                    }
                }
                else if (currentQuestion.SurveyQuestionDomainId == AppConstants.fieldTypeCheckBoxId)
                {
                    CheckBoxControl checkBoxControl =
                        (CheckBoxControl)SurveyCheckboxPlaceHolder.FindControl(AppConstants.controlCheckBoxControl);

                    if (checkBoxControl != null)
                    {
                        int optionsSelected = 0;

                        foreach (ListItem item in checkBoxControl.QuestionAnswerCheckBoxList.Items)
                        {
                            if (item.Selected == true)
                            {
                                optionsSelected++;

                                SurveyQuestionAnswer surveyQuestionAnswer = new SurveyQuestionAnswer();
                                surveyQuestionAnswer.RespondentId = SessionControlUtil.getUserID();
                                surveyQuestionAnswer.SurveyQuestionId = currentQuestion.QuestionId;
                                surveyQuestionAnswer.SurveyAnswerOptionId = AppUtil.convertStringToInt(item.Value);
                                surveyQuestionAnswer.AnswerDescription = null;

                                surveyQuestionAnswerList.Add(surveyQuestionAnswer);
                                SessionControlUtil.setSurveyQuestionAnswerList(surveyQuestionAnswerList);

                                QuestionAnswerOptions answerOption = currentQuestion.AnswerOptionsList.Find(
                                    QuestionAnswerOptions => QuestionAnswerOptions.SurveyAnswerOptionId == surveyQuestionAnswer.SurveyAnswerOptionId);

                                if (answerOption.AdditionalQuestion > 0)
                                {
                                    additionalQuestions.Add(answerOption.AdditionalQuestion);

                                   if (additionalQuestionsList.IndexOf(answerOption.AdditionalQuestion) != 0)
                                   {
                                       additionalQuestionsList.Add(answerOption.AdditionalQuestion);
                                   }

                                }
                            }
                        }

                        // If there is not answer for this question, it is recorded the question with answer null.
                        // So it is possible to verify that respondent do not answer this question, 
                        // however it was asked to him
                        if (optionsSelected == 0)
                        {
                            SurveyQuestionAnswer surveyQuestionAnswer = new SurveyQuestionAnswer();
                            surveyQuestionAnswer.RespondentId = SessionControlUtil.getUserID();
                            surveyQuestionAnswer.SurveyQuestionId = currentQuestion.QuestionId;
                            surveyQuestionAnswer.AnswerDescription = null;

                            surveyQuestionAnswerList.Add(surveyQuestionAnswer);
                            SessionControlUtil.setSurveyQuestionAnswerList(surveyQuestionAnswerList);
                        }
                    }
                }
                else if (currentQuestion.SurveyQuestionDomainId == AppConstants.fieldTypeRadioButtonId)
                {
                    RadioButtonControl radioButtonControl =
                        (RadioButtonControl)SurveyCheckboxPlaceHolder.FindControl(AppConstants.controlRadioButtonControl);

                    if (radioButtonControl != null)
                    {
                        SurveyQuestionAnswer surveyQuestionAnswer = new SurveyQuestionAnswer();
                        surveyQuestionAnswer.RespondentId = SessionControlUtil.getUserID();
                        surveyQuestionAnswer.SurveyQuestionId = currentQuestion.QuestionId;
                        surveyQuestionAnswer.SurveyAnswerOptionId =
                            AppUtil.convertStringToInt(radioButtonControl.QuestionAnswerRadioButtonList.SelectedValue);
                        surveyQuestionAnswer.AnswerDescription = null;

                        QuestionAnswerOptions answerOption = currentQuestion.AnswerOptionsList.Find(
                            QuestionAnswerOptions => QuestionAnswerOptions.SurveyAnswerOptionId == surveyQuestionAnswer.SurveyAnswerOptionId);

                        if (answerOption.AdditionalQuestion > 0)
                        {
                            additionalQuestions.Add(answerOption.AdditionalQuestion);
                        }

                        surveyQuestionAnswerList.Add(surveyQuestionAnswer);
                        SessionControlUtil.setSurveyQuestionAnswerList(surveyQuestionAnswerList);
                    }
                }
                else if (currentQuestion.SurveyQuestionDomainId == AppConstants.fieldTypeDropDownListId)
                {
                    DropDownListControl dropDownListControl =
                        (DropDownListControl)SurveyCheckboxPlaceHolder.FindControl(AppConstants.controlDropDownListControl);

                    if (dropDownListControl != null)
                    {
                        SurveyQuestionAnswer surveyQuestionAnswer = new SurveyQuestionAnswer();
                        surveyQuestionAnswer.RespondentId = SessionControlUtil.getUserID();
                        surveyQuestionAnswer.SurveyQuestionId = currentQuestion.QuestionId;
                        surveyQuestionAnswer.SurveyAnswerOptionId =
                            AppUtil.convertStringToInt(dropDownListControl.QuestionAnswerDropDownList.SelectedValue);
                        surveyQuestionAnswer.AnswerDescription = null;

                        QuestionAnswerOptions answerOption = currentQuestion.AnswerOptionsList.Find(
                            QuestionAnswerOptions => QuestionAnswerOptions.SurveyAnswerOptionId == surveyQuestionAnswer.SurveyAnswerOptionId);

                        if (answerOption.AdditionalQuestion > 0)
                        {
                            additionalQuestions.Add(answerOption.AdditionalQuestion);
                        }

                        surveyQuestionAnswerList.Add(surveyQuestionAnswer);
                        SessionControlUtil.setSurveyQuestionAnswerList(surveyQuestionAnswerList);
                    }
                }
                else
                {
                    throw new AppPageException(AppConstants.errorInvalidQuestionDomain
                                                + " "
                                                + currentQuestion.SurveyQuestionDomainId);
                }


                if (additionalQuestionsList.Count > 0)
                {
                    SessionControlUtil.insertAdditionalQuestionsCurrentLevelList(additionalQuestionsList);
                }
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
