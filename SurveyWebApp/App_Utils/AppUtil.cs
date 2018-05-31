
/* Contains app utilitys methods 
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

namespace SurveyWebApp.App_Utils
{
    /// <summary>
    /// App Utility Methods.
    /// </summary>
    public static class AppUtil
    {
        /// <summary>
        /// Convert String in Int32.
        /// </summary>
        /// <returns>string</returns>
        public static int convertStringToInt(string stringValue)
        {
            try
            {
                int intValue = 0;
                if (stringValue != null && stringValue.Trim() != "")
                {
                    intValue = Convert.ToInt32(stringValue);
                }
                return intValue;
            }
            catch (FormatException)
            {
                
              //  throw;
                return 0;
            }           
               
        }

        /// <summary>
        /// Get the user IP address.
        /// </summary>
        /// <returns>string</returns>
        public static string getUserIPAddress (){
            //get IP through PROXY
            //====================
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables[AppConstants.HTTP_X_FORWARDED_FOR];

            //should break ipAddress down, but here is what it looks like:
           // return ipAddress;
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] address = ipAddress.Split(',');
                if (address.Length != 0)
                {
                    return address[0];
                }
            }
            //if not proxy, get nice ip, give that back :(
            //ACROSS WEB HTTP REQUEST
            //=======================
            ipAddress = context.Request.UserHostAddress;//ServerVariables["REMOTE_ADDR"];

            if (ipAddress.Trim() == "::1")//ITS LOCAL(either lan or on same machine), CHECK LAN IP INSTEAD
            {
                //This is for Local(LAN) Connected ID Address
                string stringHostName = System.Net.Dns.GetHostName();
                //Get Ip Host Entry
                System.Net.IPHostEntry ipHostEntries = System.Net.Dns.GetHostEntry(stringHostName);
                //Get Ip Address From The Ip Host Entry Address List
                System.Net.IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                try
                {
                    ipAddress = arrIpAddress[1].ToString();
                }
                catch
                {
                    try
                    {
                        ipAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            arrIpAddress = System.Net.Dns.GetHostAddresses(stringHostName);
                            ipAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            ipAddress = "127.0.0.1";
                        }
                    }
                }
            }
            return ipAddress;
        }
            
    }
}