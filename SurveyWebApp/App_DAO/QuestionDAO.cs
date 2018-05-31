/* Contains all data access from Question 
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
using System.Data.SqlClient;

using SurveyWebApp.App_Objects;

namespace SurveyWebApp.App_DAO
{
    /// <summary>
    /// Data access from Question.
    /// </summary>
    public class QuestionDAO
    {
        DatabaseConnector databaseConnector;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="Exception">Exception</exception>
        public QuestionDAO()
        {
            try
            {
                //Create and open a database connection. 
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
        /// Returns a Question by Question ID. 
        /// </summary>
        /// <param name="questionId">int questionId</param>
        /// <returns>Question</returns>
        /// <exception cref="Exception">Exception</exception>
        public Question getQuestionById(int questionId)
        {
            try
            {
                Question question = new Question();

                // Fill query parameters
                SqlCommand command = new SqlCommand(AppDAOConstants.getQuestionById, databaseConnector.connection);
                command.Parameters.AddWithValue(AppDAOConstants.questionId, questionId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Fill the Question object with the correspondent values. 
                    question.QuestionDescription = reader[AppDAOConstants.questionDescription].ToString();
                    question.SurveyQuestionDomainId = Convert.ToInt32(reader[AppDAOConstants.questionDomainId].ToString());
                    question.QuestionId = Convert.ToInt32(reader[AppDAOConstants.questionId].ToString());
                }
                databaseConnector.connection.Close();
                return question;
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