/* Object that represents a Question Order
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
    /// Object that represents a Question Order.
    /// </summary>
    ///
    public class QuestionOrder
    {
        private int _questionOrder;        
        private int _surveyQuestionId;

        public int SurveyQuestionId
        {
            get { return (int)_surveyQuestionId; }
            set { _surveyQuestionId = value; }
        }

        public int QuestionOrderSequence
        {
            get { return (int) _questionOrder; }
            set { _questionOrder = value; }
        }

    }
}