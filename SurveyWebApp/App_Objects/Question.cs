/* Object that represents a Question
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
    /// Object that represents a Question.
    /// </summary>
    ///
    public class Question
    {
        private int _questionId;
        private String _questionDescription;
        private int _surveyQuestionDomainId;
        private int _questionSequence;
        private List<QuestionAnswerOptions> _answerOptionsList;

        public List<QuestionAnswerOptions> AnswerOptionsList
        {
            get { return _answerOptionsList; }
            set { _answerOptionsList = value; }
        }

        public int QuestionId
        {
            get { return (int)_questionId; }
            set { _questionId = value; }
        }

        public String QuestionDescription
        {
            get { return _questionDescription; }
            set { _questionDescription = value; }
        }

        public int SurveyQuestionDomainId
        {
            get { return (int)_surveyQuestionDomainId; }
            set { _surveyQuestionDomainId = value; }
        }

        public int QuestionSequence
        {
            get { return (int)_questionSequence; }
            set { _questionSequence = value; }
        }
    }
}