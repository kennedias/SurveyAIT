/* Contains all data access from Respondent
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
using SurveyWebApp.App_Utils;

namespace SurveyWebApp.App_DAO
{
    /// <summary>
    /// Data access from Respondent
    /// </summary>
    public class RespondentDAO
    {
        DatabaseConnector databaseConnector;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="Exception">Exception</exception>
        public RespondentDAO()
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
        /// Insert a Respondent 
        /// </summary>
        /// <param name="respondent">Respondent respondent</param>
        /// <returns>int respondentId</returns>
        /// <exception cref="AppDAOException">AppDAOException</exception>
        /// <exception cref="Exception">Exception</exception>
        public int insertRespondent (Respondent respondent)
        {
            try
            {
                // Fill query parameters
                SqlCommand command = new SqlCommand(AppDAOConstants.insertRespondent, databaseConnector.connection);

                if (respondent.IpAddress == null || respondent.IpAddress == "")
                {
                    command.Parameters.AddWithValue(AppDAOConstants.ipAddress, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.ipAddress, respondent.IpAddress);
                }

                if (respondent.DateOfBirth.HasValue)
                {
                    command.Parameters.AddWithValue(AppDAOConstants.dateOfBirth, respondent.DateOfBirth);   
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.dateOfBirth, DBNull.Value);
                }

                if (respondent.GivenNames == null || respondent.GivenNames == "")
                {
                    command.Parameters.AddWithValue(AppDAOConstants.givenNames, AppDAOConstants.anonymous);
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.givenNames, respondent.GivenNames);
                }

                if (respondent.LastName == null || respondent.LastName == "")
                {
                    command.Parameters.AddWithValue(AppDAOConstants.lastName, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.lastName, respondent.LastName);
                }

                if (respondent.PhoneNumber == null || respondent.PhoneNumber == "")
                {
                    command.Parameters.AddWithValue(AppDAOConstants.phoneNumber, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.phoneNumber, respondent.PhoneNumber);
                }

                
                int? respondentId = (int?)command.ExecuteScalar();
                databaseConnector.connection.Close();

                if (respondentId.HasValue)
                {
                    return (int)respondentId;
                }
                else
                {
                    throw new AppDAOException(AppConstants.errorInsertingData);
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
        /// Update a Respondent 
        /// </summary>
        /// <param name="respondent">Respondent respondent</param>
        /// <exception cref="AppDAOException">AppDAOException</exception>
        /// <exception cref="Exception">Exception</exception>
        public void updateRespondent(Respondent respondent)
        {
            try
            {
                // Fill query parameters
                SqlCommand command = new SqlCommand(AppDAOConstants.updateRespondent, databaseConnector.connection);

                if (respondent.DateOfBirth.HasValue)
                {
                    command.Parameters.AddWithValue(AppDAOConstants.dateOfBirth, respondent.DateOfBirth);
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.dateOfBirth, DBNull.Value);
                }

                if (respondent.GivenNames == null || respondent.GivenNames == "")
                {
                    command.Parameters.AddWithValue(AppDAOConstants.givenNames, AppDAOConstants.anonymous);
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.givenNames, respondent.GivenNames);
                }

                if (respondent.LastName == null || respondent.LastName == "")
                {
                    command.Parameters.AddWithValue(AppDAOConstants.lastName, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.lastName, respondent.LastName);
                }

                if (respondent.PhoneNumber == null || respondent.PhoneNumber == "")
                {
                    command.Parameters.AddWithValue(AppDAOConstants.phoneNumber, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue(AppDAOConstants.phoneNumber, respondent.PhoneNumber);
                }

                if (respondent.RespondentId > 0)
                {
                    command.Parameters.AddWithValue(AppDAOConstants.respondentId, respondent.RespondentId);
                }
                else
                {
                    throw new AppDAOException(AppConstants.errorInvalidId);
                }
                

                int recordsAffected = command.ExecuteNonQuery();
                databaseConnector.connection.Close();

                if (recordsAffected == 0)
                {
                    throw new AppDAOException(AppConstants.errorUpdatingData);
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