/* Object that represents a Survey with question and respective answer
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
    /// Object that represents a Survey with question and respective answer
    /// </summary>
    ///
    public class SurveyQuestionAnswer
    {
        private int _surveyAnswerOptionId;
        private String _answerDescription;
        private int _surveyQuestionId;
        private int _respondentId;
        private int _surveyQuestionDomainId;

        public int SurveyAnswerOptionId
        {
            get { return (int)_surveyAnswerOptionId; }
            set { _surveyAnswerOptionId = value; }
        }

        public String AnswerDescription
        {
            get { return _answerDescription; }
            set { _answerDescription = value; }
        }

        public int SurveyQuestionId
        {
            get { return (int)_surveyQuestionId; }
            set { _surveyQuestionId = value; }
        }

        public int RespondentId
        {
            get { return (int)_respondentId; }
            set { _respondentId = value; }
        }

        public int SurveyQuestionDomainId
        {
            get { return (int)_surveyQuestionDomainId; }
            set { _surveyQuestionDomainId = value; }
        }
    }
}