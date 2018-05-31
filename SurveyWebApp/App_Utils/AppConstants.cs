/* Contains application constants
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
    /// Application's constants.
    /// </summary>
    public static class AppConstants
    {

        #region SessionControl
        public const string sessionUserIPAddress = "sessionUserIPAddress";
        public const string sessionUserID = "sessionUserID";
        public const string sessionCurrentQuestionSequence = "sessionCurrentQuestionSequence";
        public const string sessionCurrentQuestion = "sessionCurrentQuestion";
        public const string sessionQuestionsAnswerList = "sessionQuestionsAnswerList";
        public const string sessionAnswerOptionId = "sessionAnswerOptionId";
        public const string sessionCurrentQuestionsLevel = "sessionCurrentQuestionsLevel";
        public const string sessionAdditionalQuestionsCurrentLevelList = "sessionAdditionalQuestionsCurrentLevelList";
        #endregion

        #region QuestionDomain
        public const int fieldTypeTextId = 1;
        public const int fieldTypeRadioButtonId = 2;
        public const int fieldTypeCheckBoxId = 3;
        public const int fieldTypeDropDownListId = 4;
        #endregion

        #region Question
        public const int questionBank = 8;
        public const int questionBankServices = 9;
        #endregion

        #region Control
        public const string controlCheckBoxControl = "~/App_Pages/CheckBoxControl.ascx";
        public const string controlDropDownListControl = "~/App_Pages/DropDownListControl.ascx";
        public const string controlRadioButtonControl = "~/App_Pages/RadioButtonControl.ascx";
        public const string controlTextBoxControl = "~/App_Pages/TextBoxControl.ascx";
        #endregion

        #region Pages
        public const string pageSurveyComplete = "SurveyComplete.aspx";
        public const string pageSurvey = "Survey.aspx";
        public const string pageRegister = "Register.aspx";
        public const string pageRegisterComplete = "RegisterComplete.aspx";
        public const string pageHome = "Home.aspx";
        public const string pageSearch = "Search.aspx";
        #endregion

        #region SystemMessages
        public const string messageCommandSuccess = "Command executed with success.";
        #endregion

        #region ErrorMessages
        public const string errorSystemError = "System Error. Please, try again later.";
        public const string errorInvalidQuestionDomain = "Invalid question domain type.";
        public const string errorInsertingData = "Error inserting data.";
        public const string errorUpdatingData = "Error updating data.";
        public const string errorInvalidId = "Invalid ID to execute action.";
        public const string errorInvalidSessionKey = "There is no attribute on session for the key: ";
        public const string errorInvalidOperationForDecrement = "The value can not be decremented for less than 1.";
        public const string errorInvalidDAOParameters = "Invalid parameteres to execute DAO: ";
        public const string errorInvalidLogin = "Invalid user ID or password.";
        public const string errorSearchParamBankAndService = "A Bank or Bank Service need to be informed to execute search.";
        public const string errorNoRecordsFound = "No records found.";


        #endregion

        #region AppUtil
        public const string HTTP_X_FORWARDED_FOR = "HTTP_X_FORWARDED_FOR";
        #endregion
    }
}