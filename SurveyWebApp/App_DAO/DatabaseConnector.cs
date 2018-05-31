/* The database connector component
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
using System.Configuration;
using System.Data.SqlClient;

namespace SurveyWebApp.App_DAO
{
    public class DatabaseConnector
    {
        public SqlConnection connection;

        /// <summary>
        /// Class constructor as a component that create and open a database connection
        /// </summary>
        /// <remarks>
        /// All DAO classes have to use this component to connect to the database.</remarks>
        /// <exception cref="Exception">Exception</exception>
        public DatabaseConnector()
        {            
            try
            {
                //Setup database string connection
                string connectionString = ConfigurationManager.ConnectionStrings[AppDAOConstants.connectionStringName].ToString();
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
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