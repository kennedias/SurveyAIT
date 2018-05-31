/* Contains DAO layer constants
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

namespace SurveyWebApp.App_DAO
{
    /// <summary>
    /// DAO layer constants
    /// </summary>
    public static class AppDAOConstants
    {
        #region Database
        public const string connectionStringName = "SurveyDatabase";
        #endregion

        #region Questions
        //Columns
        public const string questionId = "surveyQuestionId";
        public const string questionDescription = "questionDescription";
        public const string questionDomainId ="surveyQuestionDomainId";

        //Queries
        public const string 
            getQuestionById = "Select surveyQuestionId, questionDescription, surveyQuestionDomainId"
                                 + " from SurveyQuestion Where surveyQuestionId = @" + questionId;
        #endregion
        
        #region QuestionsAnswerOptions
        //Columns
        public const string answerOptionId = "surveyAnswerOptionId";
        public const string answerDescription = "answerDescription";
        public const string additionalQuestion = "additionalQuestion";

        //Queries
        public const string
             getAnswerOptions = "Select surveyAnswerOptionId, answerDescription, additionalQuestion"
                                 + " from SurveyAnswerOption WHERE surveyQuestionId = @"+ questionId +" Order by answerDescription";
        #endregion

        #region QuestionsOrder
        //Columns
        public const string questionOrderSequence = "questionOrder";

        //Queries
        public const string
            getQuestionsSequence = "Select questionOrder, surveyQuestionId"
                                 + " from SurveyQuestionOrder Order by questionOrder";
        public const string
            getNextQuestionOrder = "Select top 1 surveyQuestionId, questionOrder from SurveyQuestionOrder "
                                 + " where questionOrder > @" + questionOrderSequence + " order by questionOrder";
        #endregion

        #region Respondent
        //Columns
        public const string respondentId = "respondentId";
        public const string recordDate = "recordDate";
        public const string ipAddress = "ipAddress";
        public const string dateOfBirth = "dateOfBirth";
        public const string givenNames = "givenNames";
        public const string lastName = "lastName";
        public const string phoneNumber = "phoneNumber";
        public const string anonymous = "Anonymous";

        //Queries
        public const string
            insertRespondent = "Insert into Respondent (recordDate, ipAddress, dateOfBirth, givenNames, lastName, phoneNumber)"
                                 + " values(CURRENT_TIMESTAMP,@" + ipAddress + ",@" + dateOfBirth + ",@" + givenNames + ",@" + lastName + ",@" + phoneNumber + ");"
                                 + " SELECT CAST(scope_identity() AS int)";
        
        public const string
            updateRespondent ="Update Respondent set dateOfBirth=@" + dateOfBirth + ", givenNames=@" + givenNames + ",lastName=@" + lastName + ",phoneNumber=@" + phoneNumber
                                + " where respondentId=@" + respondentId;
        #endregion

        #region Survey
        //Columns
        public const string surveyId = "surveyId";

        //Queries
        public const string
            insertSurveyQuestionAnswer = "Insert into Survey (respondentId, surveyQuestionId, surveyAnswerOptionId, answerDescription)"
                                 + " values(@" + respondentId + ",@" + questionId + ",@" + answerOptionId + ",@" + answerDescription + ")";

        #endregion

        #region Staff
        //Columns
        public const string staffId = "staffid";
        public const string staffPassword = "password";

        //Queries
        public const string
             getStaffById = "Select staffId "
                                 + " from Staff WHERE staffid = @" + staffId + " and password = @" + staffPassword;
        #endregion

        #region Search

        //Columns
        public const string surveyAnswerOptionIdInParameters = "surveyAnswerOptionIdInParameters";
        public const string answerOptionIdParam = "@answerOptionIdParam";

        //Queries
        public const string
             searchSurveyByAnswerIDLastNameOrGivenNames = "select b.lastname as 'Last Name', b.givenNames as 'Given Names', b.recordDate as Completed, b.phoneNumber Phone, "
                             + " c.questionDescription as 'Question', d.answerDescription as 'Answer' "
                             + " from survey a, respondent b, SurveyQuestion c, SurveyAnswerOption d "
                             + " where a.respondentId = b.respondentId  "
                             + " and a.surveyQuestionId = c.surveyQuestionId "
                             + " and a.surveyAnswerOptionId = d.surveyAnswerOptionId "
                             + " and a.surveyAnswerOptionId in ({0}) "
                             + " and a.respondentId in (select respondentid from respondent where lastname = @" + lastName + " or givennames = @" + givenNames + ")"
                             + " order by b.lastname";
        #endregion



    }
}