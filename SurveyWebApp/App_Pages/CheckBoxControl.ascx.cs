using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveyWebApp.App_Pages
{
    public partial class CheckBoxControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.questionAnswerCheckBoxList.ClearSelection();
        }

        public Label QuestionDescriptionLabel
        {
            get {return questionDescriptionLabel;}
            set {questionDescriptionLabel = value;}
        }

        public CheckBoxList QuestionAnswerCheckBoxList
        {
            get{return questionAnswerCheckBoxList;}
            set{questionAnswerCheckBoxList = value;}
        }
    }
}