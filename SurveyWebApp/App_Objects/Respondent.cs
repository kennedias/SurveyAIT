/* Object that represents a Respondent
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

namespace SurveyWebApp.App_Objects
{
    /// <summary>
    /// Object that represents a Respondent
    /// </summary>
    ///
    public class Respondent
    {
        private int _respondentId;
        private DateTime? _recordDate;
        private String _ipAddress;
        private DateTime? _dateOfBirth;
        private String _givenNames;
        private String _lastName;
        private String _phoneNumber;

        public Respondent()
        {

        }

        public int RespondentId
        {
            get { return (int)_respondentId; }
            set { _respondentId = value; }
        }

        public DateTime? RecordDate
        {
            get {return _recordDate; }
            set { _recordDate = value; }
        }

        public String IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        public DateTime? DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public String GivenNames
        {
            get { return _givenNames; }
            set { _givenNames = value; }
        }

        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public String PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
    }
}