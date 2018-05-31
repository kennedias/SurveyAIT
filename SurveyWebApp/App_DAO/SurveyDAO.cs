/* Contains all data access from Survey
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
using System.Data.SqlClient;

using SurveyWebApp.App_Objects;
using SurveyWebApp.App_Utils;

namespace SurveyWebApp.App_DAO
{
    /// <summary>
    /// Data access from Survey
    /// </summary>
    public class SurveyDAO
    {
        DatabaseConnector databaseConnector;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="Exception">Exception</exception>
        public SurveyDAO()
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
        /// Insert a Survey Question Answer 
        /// </summary>
        /// <param name="surveyQuestionAnswer">SurveyQuestionAnswer surveyQuestionAnswer</param>
        /// <exception cref="Exception">Exception</exception>
        public void insertSurveyQuestionAnswer(SurveyQuestionAnswer surveyQuestionAnswer)
        {
            try
            {
                // Fill query parameters
                SqlCommand command = new SqlCommand(AppDAOConstants.insertSurveyQuestionAnswer, databaseConnector.connection);
                command.Parameters.AddWithValue(AppDAOConstants.respondentId, surveyQuestionAnswer.RespondentId);
                command.Parameters.AddWithValue(AppDAOConstants.questionId, surveyQuestionAnswer.SurveyQuestionId);
                

                if (surveyQuestionAnswer.SurveyAnswerOptionId == 0)
                {
                    command.Parameters.AddWithValue(AppDAOConstants.answerOptionId, DBNull.Value);  
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.answerOptionId, surveyQuestionAnswer.SurveyAnswerOptionId);                
                }

                if (surveyQuestionAnswer.AnswerDescription == null || surveyQuestionAnswer.AnswerDescription == "")
                {
                    command.Parameters.AddWithValue(AppDAOConstants.answerDescription, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.answerDescription, surveyQuestionAnswer.AnswerDescription);
                }

                command.ExecuteScalar();  
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
        /// <exception cref="AppDAOException">AppDAOException</exception>
        /// <exception cref="Exception">Exception</exception>
        public DataTable searchSurveyByAnswerIDLastNameOrGivenNames(List<int> answerOptionIdList, String lastName, String givenNames)
        {
            try
            {
                if (answerOptionIdList.Count == 0)
                {
                    throw new AppDAOException(AppConstants.errorInvalidDAOParameters + "answerOptionIdList");
                }
                
                DataTable searchResult = new DataTable();
                SqlCommand command = new SqlCommand();
                command.Connection = databaseConnector.connection;                

                List<string> answerOptionIdParamList = new List<string>();

                for (int i = 0; i < answerOptionIdList.Count(); i++)
                {
                    string answerOptionIdParam = AppDAOConstants.answerOptionIdParam + i;
                    command.Parameters.AddWithValue(answerOptionIdParam, answerOptionIdList[i]);
                    answerOptionIdParamList.Add(answerOptionIdParam);
                }

                command.Parameters.AddWithValue(AppDAOConstants.lastName, lastName);
                command.Parameters.AddWithValue(AppDAOConstants.givenNames, givenNames);
                command.CommandText = String.Format(AppDAOConstants.searchSurveyByAnswerIDLastNameOrGivenNames, string.Join(",", answerOptionIdParamList));

                using (SqlDataReader sqldataReader = command.ExecuteReader())
                {                    
                    searchResult.Load(sqldataReader);
                }

                return searchResult;
                
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