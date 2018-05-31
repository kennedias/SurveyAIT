/* Contains all session control used on pages
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

using SurveyWebApp.App_Utils;
using SurveyWebApp.App_Objects;
using System.Collections;

namespace SurveyWebApp.App_Pages
{
    /// <summary>
    /// Session control 
    /// </summary>
    public class SessionControlUtil
    {

        /// <summary>
        /// Set the user ID in a valid session
        /// </summary>
        /// <param name="sessionUserID">int sessionUserID</param>
        /// <exception cref="Exception">Exception</exception>
        public static void setUserID(int userID)
        {
            try
            {
                HttpContext.Current.Session[AppConstants.sessionUserID] = userID;
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
        /// Get the user ID from a valid session
        /// </summary>
        /// <returns>string</returns>
        /// <exception cref="Exception">Exception</exception>
        public static int getUserID()
        {
            try
            {
                return Convert.ToInt32(HttpContext.Current.Session[AppConstants.sessionUserID]);
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
        /// Set the user IP Address in a valid session
        /// </summary>
        /// <param name="sessionUserIPAddress">string sessionUserIPAddress</param>
        /// <exception cref="Exception">Exception</exception>
        public static void setUserIPAddress(string userIPAddress)
        {
            try
            {
                HttpContext.Current.Session[AppConstants.sessionUserIPAddress] = userIPAddress;
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
        /// Get the user IP Address from a valid session
        /// </summary>
        /// <returns>string</returns>
        /// <exception cref="Exception">Exception</exception>
        public static string getUserIPAddress()
        {
            try
            {
                return (string)HttpContext.Current.Session[AppConstants.sessionUserIPAddress];
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
        /// Verify if exists a session with the user IP value.
        /// </summary>
        /// <returns>bool</returns>
        /// <exception cref="Exception">Exception</exception>
        public static bool IsLoggedIn()
        {
            try
            {
                int userIp = getUserID();
                if (userIp > 0)
                    return true;
                else
                    return false;
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
        /// Verify if the pageSurvey is already started and has a current question sequence.
        /// If its the first time it starts with zero.
        /// </summary>
        /// <returns>int</returns>
        /// <exception cref="Exception">Exception</exception>
        public static int getCurrentQuestionSequence()
        {
            try
            {
                int currentQuestionSequence = 0;

                if (HttpContext.Current.Session[AppConstants.sessionCurrentQuestionSequence] == null)
                {
                    HttpContext.Current.Session[AppConstants.sessionCurrentQuestionSequence] = 0; //set for first time
                    List<SurveyQuestionAnswer> surveyQuestionAnswerList = new List<SurveyQuestionAnswer>();
                    HttpContext.Current.Session[AppConstants.sessionQuestionsAnswerList] = surveyQuestionAnswerList;
                }
                else
                {
                    currentQuestionSequence = Convert.ToInt32(HttpContext.Current.Session[AppConstants.sessionCurrentQuestionSequence]);
                }

                return currentQuestionSequence;
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
        /// Set the current question on the session.
        /// </summary>
        /// <param name="sessionCurrentQuestionSequence">string sessionCurrentQuestionSequence</param>
        /// <exception cref="Exception">Exception</exception>
        public static void setCurrentQuestionSequence(int currentQuestionSequence)
        {
            try
            {
                //Store the actual question sequence on the session.
                HttpContext.Current.Session[AppConstants.sessionCurrentQuestionSequence] = currentQuestionSequence;
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
        /// Set the surveyQuestionAnswerList in a valid session
        /// </summary>
        /// <param name="surveyQuestionAnswerList">List<SurveyQuestionAnswer> surveyQuestionAnswerList</param>
        /// <exception cref="Exception">Exception</exception>
        public static void setSurveyQuestionAnswerList(List<SurveyQuestionAnswer> surveyQuestionAnswerList)
        {
            try
            {
                if (HttpContext.Current.Session[AppConstants.sessionQuestionsAnswerList] == null)
                {
                    HttpContext.Current.Session[AppConstants.sessionQuestionsAnswerList] = new List<SurveyQuestionAnswer>();
                }
                HttpContext.Current.Session[AppConstants.sessionQuestionsAnswerList] = surveyQuestionAnswerList;
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
        /// Get the Survey Question Answer List from a valid session
        /// </summary>
        /// <returns>List<SurveyQuestionAnswer></returns>
        /// <exception cref="Exception">Exception</exception>
        public static List<SurveyQuestionAnswer> getSurveyQuestionAnswerList()
        {
            try
            {
                List<SurveyQuestionAnswer> surveyQuestionAnswerList = new List<SurveyQuestionAnswer>();
                surveyQuestionAnswerList = (List<SurveyQuestionAnswer>)HttpContext.Current.Session[AppConstants.sessionQuestionsAnswerList];
                return surveyQuestionAnswerList;
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
        /// Set the current question in a valid session
        /// </summary>
        /// <param name="sessionCurrentQuestion">Question sessionCurrentQuestion</param>
        /// <exception cref="Exception">Exception</exception>
        public static void setCurrentQuestion(Question currentQuestion)
        {
            try
            {
                HttpContext.Current.Session[AppConstants.sessionCurrentQuestion] = currentQuestion;
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
        /// Get the current question from valid session
        /// </summary>
        /// <returns>Question</returns>
        /// <exception cref="Exception">Exception</exception>
        public static Question getCurrentQuestion()
        {
            try
            {
                return (Question) HttpContext.Current.Session[AppConstants.sessionCurrentQuestion];
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
        /// Get the current questions level from valid session
        /// </summary>
        /// <returns>int</returns>
        /// <exception cref="Exception">Exception</exception>
        /// /// <exception cref="Exception">Exception</exception>
        public static int getCurrentQuestionsLevel()
        {
            try
            {
                if (HttpContext.Current.Session[AppConstants.sessionCurrentQuestionsLevel] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session[AppConstants.sessionCurrentQuestionsLevel]);
                }
                else
                {
                    throw new AppPageException(AppConstants.errorInvalidSessionKey + AppConstants.sessionCurrentQuestionsLevel);
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


        ///////
        /// <summary>
        /// Incremet the current question level.
        /// </summary>
        /// <exception cref="AppPageException">AppPageException</exception>
        /// <exception cref="Exception">Exception</exception>
        public static void incrementCurrentQuestionLevel()
        {
            try
            {
                if (HttpContext.Current.Session[AppConstants.sessionCurrentQuestionsLevel] != null)
                {
                    int sessionCurrentQuestionsLevel = Convert.ToInt32(HttpContext.Current.Session[AppConstants.sessionCurrentQuestionsLevel]);
                    sessionCurrentQuestionsLevel++;
                    HttpContext.Current.Session[AppConstants.sessionCurrentQuestionsLevel] = sessionCurrentQuestionsLevel;
                }
                else
                {
                    HttpContext.Current.Session[AppConstants.sessionCurrentQuestionsLevel] = 1;
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

        ///////
        /// <summary>
        /// Decremet the current question level.
        /// Level can not be less than 1.
        /// </summary>
        /// <exception cref="AppPageException">AppPageException</exception>
        /// <exception cref="Exception">Exception</exception>
        public static void decrementCurrentQuestionLevel()
        {
            try
            {
                if (HttpContext.Current.Session[AppConstants.sessionCurrentQuestionsLevel] != null)
                {
                    int sessionCurrentQuestionsLevel = Convert.ToInt32(HttpContext.Current.Session[AppConstants.sessionCurrentQuestionsLevel]);
                    if (sessionCurrentQuestionsLevel > 1)
                    {
                        sessionCurrentQuestionsLevel--;
                        HttpContext.Current.Session[AppConstants.sessionCurrentQuestionsLevel] = sessionCurrentQuestionsLevel;
                    }
                    else
                    {
                        throw new AppPageException(AppConstants.errorInvalidOperationForDecrement);
                    }                        
                }
                else
                {
                    throw new AppPageException(AppConstants.errorInvalidSessionKey + AppConstants.sessionCurrentQuestionsLevel);
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
        /// Get the Current Questions Level List Key identifier
        /// </summary>
        /// <returns>string</returns>
        /// <exception cref="Exception">Exception</exception>
        /// /// <exception cref="Exception">Exception</exception>
        public static string getCurrentQuestionsLevelKey()
        {
            try
            {
                int currentQuestionsLevel = getCurrentQuestionsLevel();
                string currentQuestionsLevelKey = 
                    AppConstants.sessionAdditionalQuestionsCurrentLevelList + currentQuestionsLevel;
                return currentQuestionsLevelKey;
            }
            catch (Exception ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }
        

        ///////
        /// <summary>
        /// Insert an question ID List on Additional Questions Current Level List.
        /// </summary>
        /// <param name="questionIDList">List<int> questionIDList</param>
        /// <exception cref="AppPageException">AppPageException</exception>
        /// <exception cref="Exception">Exception</exception>  
        public static void insertAdditionalQuestionsCurrentLevelList(List<int> questionIDList)
        {
            try
            {
                SessionControlUtil.incrementCurrentQuestionLevel();
                string currentQuestionsLevelKey = getCurrentQuestionsLevelKey();

                if (HttpContext.Current.Session[currentQuestionsLevelKey] == null)
                {
                    HttpContext.Current.Session[currentQuestionsLevelKey] = new ArrayList();
                }

                HttpContext.Current.Session[currentQuestionsLevelKey] = questionIDList;
            }
            catch (Exception ex)
            {
                //Error log simulated
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        ///////
        /// <summary>
        /// Remove question ID on Additional Questions Current Level List.
        /// </summary>
        /// <param name="questionID">int questionID</param>
        /// <exception cref="AppPageException">AppPageException</exception>
        /// <exception cref="Exception">Exception</exception>
        public static void removeQuestionIdFromAdditionalQuestionCurrentLevelList(int questionID)
        {
            try
            {
                string currentQuestionsLevelKey = getCurrentQuestionsLevelKey();
                List<int> additionlQuestionsList = new List<int>();

                if (HttpContext.Current.Session[currentQuestionsLevelKey] != null)
                {
                    additionlQuestionsList = (List<int>)HttpContext.Current.Session[currentQuestionsLevelKey];
                    additionlQuestionsList.Remove(questionID);

                    if (additionlQuestionsList.Count == 0)
                    {
                        SessionControlUtil.decrementCurrentQuestionLevel();
                        HttpContext.Current.Session[currentQuestionsLevelKey] = null;
                    }
                    else
                    {
                        HttpContext.Current.Session[currentQuestionsLevelKey] = additionlQuestionsList;
                    }                        
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

        ///////
        /// <summary>
        /// Get the next question ID from Additional Questions Current Level List.
        /// </summary>
        /// <returns>int</returns>
        /// <exception cref="AppPageException">AppPageException</exception>
        /// <exception cref="Exception">Exception</exception>
        public static int getNexQuestionIdFromAdditionalQuestionCurrentLevelList()
        {
            try
            {
                string currentQuestionsLevelKey = getCurrentQuestionsLevelKey();
                List<int> additionalQuestionsList = new List<int>();
                int nextQuestion = 0;

                if (HttpContext.Current.Session[currentQuestionsLevelKey] != null)
                {
                    additionalQuestionsList = (List<int>)HttpContext.Current.Session[currentQuestionsLevelKey];
                    if (additionalQuestionsList.Count > 0)
                    {
                        nextQuestion = AppUtil.convertStringToInt(additionalQuestionsList[0].ToString());
                        SessionControlUtil.removeQuestionIdFromAdditionalQuestionCurrentLevelList(nextQuestion);           
                    }
                }

                return nextQuestion;
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