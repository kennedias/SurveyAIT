/* Contains all logic control  from Survey 
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
using System.Data;

using SurveyWebApp.App_Objects;
using SurveyWebApp.App_DAO;
using SurveyWebApp.App_Utils;

namespace SurveyWebApp.App_Control
{
    /// <summary>
    /// Logic Control from pageSurvey.
    /// </summary>
    public class SurveyLogicControl
    {
        /// <summary>
        /// Return the Question object and his Answer Options by question ID. 
        /// </summary>
        /// <param name="questionID">int questionID</param>
        /// <returns>Question</returns>
        /// <exception cref="AppControlException">AppControlException</exception>
        public Question getQuestionAndAnswersByIQuestionID(int questionID)
        {
            try
            {
                QuestionOrderDAO questionOrderDAO = new QuestionOrderDAO();

                QuestionDAO questionDAO = new QuestionDAO();

                //Get the Question record by questionId.
                Question question = questionDAO.getQuestionById(questionID);

                //Get the Answer Options from the Question.
                question.AnswerOptionsList = this.getListOfQuestionAnswerOptionByQuestionId(questionID);

                return question;
            }
            catch (AppDAOException ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());

                throw new AppControlException(ex.Message);
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
        /// Returns the list of Answer Options for a Question. 
        /// </summary>
        /// <param name="questionId">int questionId</param>
        /// <returns>List<QuestionAnswerOptions></returns>
        /// <exception cref="AppControlException">AppControlException</exception>
        public List<QuestionAnswerOptions> getListOfQuestionAnswerOptionByQuestionId(int questionId)
        {
            try
            {
                List<QuestionAnswerOptions> answersOptions = null;

                QuestionAnswerOptionDAO questionAnswerOptionDAO = new QuestionAnswerOptionDAO();
                answersOptions = questionAnswerOptionDAO.getListOfQuestionAnswerOptionByQuestionId(questionId);

                return answersOptions;
            }
            catch (AppDAOException ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());

                throw new AppControlException(ex.Message);
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
        /// Return the next Question object and his Answer Options based on the actual question sequence. 
        /// Get the next questionId from Question Order after the question sequence provided.
        /// </summary>
        /// <param name="sessionCurrentQuestionSequence">int sessionCurrentQuestionSequence</param>
        /// <returns>Question</returns>
        /// <exception cref="AppControlException">AppControlException</exception>
        public Question getNextQuestionBySequence(int currentQuestionSequence)
        {
            try
            {
                QuestionOrderDAO questionOrderDAO = new QuestionOrderDAO();

                //Get the next questionId from Question Order after the question sequence provided.
                QuestionOrder nextQuestionOrder = questionOrderDAO.getNextQuestionOrder(currentQuestionSequence);

                QuestionDAO questionDAO = new QuestionDAO();

                //Get the Question record by questionId.
                Question nextQuestion = getQuestionAndAnswersByIQuestionID(nextQuestionOrder.SurveyQuestionId);
                nextQuestion.QuestionSequence = nextQuestionOrder.QuestionOrderSequence;

                return nextQuestion;
            }
            catch (AppDAOException ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());

                throw new AppControlException(ex.Message);
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
        /// Insert a respondent entry. 
        /// </summary>
        /// <param name="Respondet">Respondent respondent</param>
        /// <returns>int</returns>
        /// <exception cref="AppControlException">AppControlException</exception>
        public int insertRespondent(Respondent respondent)
        {
            try
            {
                RespondentDAO respondentDAO = new RespondentDAO();
                return respondentDAO.insertRespondent(respondent);
            }
            catch (AppDAOException ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());

                throw new AppControlException(ex.Message);
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
        /// Update a respondent entry. 
        /// </summary>
        /// <param name="Respondent">Respondent respondent</param>
        /// <exception cref="AppControlException">AppControlException</exception>
        public void updateRespondent(Respondent respondent)
        {
            try
            {
                RespondentDAO respondentDAO = new RespondentDAO();
                respondentDAO.updateRespondent(respondent);
            }
            catch (AppControlException ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());

                throw new AppControlException(ex.Message);
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
        /// Insert a answered pageSurvey. 
        /// </summary>
        /// <param name="surveyQuestionAnswerList">List<SurveyQuestionAnswer> surveyQuestionAnswerList</param>
        /// <returns>int</returns>
        /// <exception cref="AppControlException">AppControlException</exception>
        public void insertAnsweredSurvey(List<SurveyQuestionAnswer> surveyQuestionAnswerList)
        {
            try
            {
                SurveyDAO surveyDAO = new SurveyDAO();

                foreach (SurveyQuestionAnswer surveyQuestionAnswer in surveyQuestionAnswerList)
                {
                    surveyDAO.insertSurveyQuestionAnswer(surveyQuestionAnswer);
                }
            }
            catch (AppControlException ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());

                throw new AppControlException(ex.Message);
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
        /// Staff login validation. 
        /// Returns true if the login verification is valid
        /// </summary>
        /// <param name="staffId">int staffId</param>
        /// <param name="staffPassword">String staffPassword</param>
        /// <returns>bool</returns>
        public bool staffLoginValidation(int staffId, String staffPassword)
        {
            try
            {
                Staff staff = new Staff();
                staff = staff.getStaffByIdPassword(staffId, staffPassword);

                if (staff.StaffId > 0)
                {
                    //The combination of staffId and password is a valid record on database;
                    return true;
                }
                else
                {
                    //The combination of staffId and password is not valid record on database;
                    return false;
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
        /// Survey search by answer option id and last name or given Names
        /// </summary>
        /// <param name="answerOptionIdList">List<int> answerOptionIdList</param>
        /// <param name="lastName">String lastName</param>
        /// <param name="givenNames">String givenNames</param>
        /// <returns>DataTable</returns>
        /// <exception cref="AppControlException">AppControlException</exception>
        public DataTable searchSurveyByAnswerIDLastNameOrGivenNames(List<int> answerOptionIdList, String lastName, String givenNames)
        {
            try
            {
                if (answerOptionIdList.Count == 0)
                {
                    throw new AppControlException(AppConstants.errorSearchParamBankAndService);
                }

                DataTable searchResult = new DataTable();
                SurveyDAO surveyDAO = new SurveyDAO();

                searchResult = surveyDAO.searchSurveyByAnswerIDLastNameOrGivenNames(answerOptionIdList, lastName, givenNames);

                return searchResult;
            }
            catch (AppDAOException ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());

                throw new AppControlException(ex.Message);
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