/* Contains all data access from Question Order 
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
    /// Data access from Question Order.
    /// </summary>
    public class QuestionOrderDAO
    {
        DatabaseConnector databaseConnector;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="Exception">Exception</exception>
        public QuestionOrderDAO()
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
        /// Returns the Question Order by Question Sequence. 
        /// </summary>
        /// <param name="questionId">int questionId</param>
        /// <returns>QuestionOrder</returns>
        /// <exception cref="Exception">Exception</exception>
        public QuestionOrder getNextQuestionOrder(int currentQuestionSequence)
        {
            try
            {
                QuestionOrder nextQuestionOrder = new QuestionOrder();

                // Fill query parameters
                SqlCommand command = new SqlCommand(AppDAOConstants.getNextQuestionOrder, databaseConnector.connection);
                command.Parameters.AddWithValue(AppDAOConstants.questionOrderSequence, currentQuestionSequence);
                
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Fill Question object with the correspondent values
                    nextQuestionOrder.SurveyQuestionId = Convert.ToInt32(reader[AppDAOConstants.questionId].ToString());
                    nextQuestionOrder.QuestionOrderSequence = Convert.ToInt32(reader[AppDAOConstants.questionOrderSequence].ToString());
                }
                databaseConnector.connection.Close();
                return nextQuestionOrder;
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