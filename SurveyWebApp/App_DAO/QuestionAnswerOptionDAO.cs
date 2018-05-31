/* Contains all data access from Question Answer Option
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
    /// Data access from Question Answer Option
    /// </summary>
    public class QuestionAnswerOptionDAO
    {
        DatabaseConnector databaseConnector;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="Exception">Exception</exception>
        public QuestionAnswerOptionDAO()
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
        /// Returns the Answers Options from Question by Question ID. 
        /// </summary>
        /// <param name="questionId">int questionId</param>
        /// <returns>List<QuestionAnswerOptions></returns>
        /// <exception cref="Exception">Exception</exception>
        public List<QuestionAnswerOptions> getListOfQuestionAnswerOptionByQuestionId(int questionId)
        {
            try
            {
                List<QuestionAnswerOptions> answersOptions = new List<QuestionAnswerOptions>();

                // Fill query parameters              
                SqlCommand command = new SqlCommand(AppDAOConstants.getAnswerOptions, databaseConnector.connection);
                command.Parameters.AddWithValue(AppDAOConstants.questionId, questionId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Fill the Question object with the correspondent values.
                    QuestionAnswerOptions questionAnswerOptions = new QuestionAnswerOptions();
                    questionAnswerOptions.SurveyQuestionId = questionId;
                    questionAnswerOptions.AnswerDescription = reader[AppDAOConstants.answerDescription].ToString();
                    questionAnswerOptions.SurveyAnswerOptionId = Convert.ToInt32(reader[AppDAOConstants.answerOptionId].ToString());
                    String value = reader[AppDAOConstants.additionalQuestion].ToString();
                    if (reader[AppDAOConstants.additionalQuestion].ToString() != "")
                        questionAnswerOptions.AdditionalQuestion = Convert.ToInt32(reader[AppDAOConstants.additionalQuestion].ToString());

                    answersOptions.Add(questionAnswerOptions);
                }
                databaseConnector.connection.Close();
                return answersOptions;
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