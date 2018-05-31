using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SurveyWebApp.App_Objects;
using SurveyWebApp.App_Control;
using SurveyWebApp.App_Utils;

namespace SurveyWebApp.App_Pages
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionControlUtil.IsLoggedIn() == false)
            {
               Response.Redirect(AppConstants.pageHome, false);
            }

            ErrorMessageLabel.Text = "";
            ErrorMessageLabel.ForeColor = System.Drawing.Color.Black;

            if (!IsPostBack)
            {
                this.createCheckBoxes();
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            SurveyLogicControl surveyLogicControl = new SurveyLogicControl();

            List<int> answerOptionIdList = new List<int>();


            foreach (ListItem item in BankCheckBoxList.Items)
            {
                if (item.Selected == true)
                {
                    answerOptionIdList.Add(AppUtil.convertStringToInt(item.Value));
                }
            }


            foreach (ListItem item in ServicesCheckBoxList.Items)
            {
                if (item.Selected == true)
                {
                    answerOptionIdList.Add(AppUtil.convertStringToInt(item.Value));
                }
            }
            try
            {
                SearchGridView.DataSource =
                    surveyLogicControl.searchSurveyByAnswerIDLastNameOrGivenNames(answerOptionIdList, LastNameTextBox.Text, GivenNamesTextBox.Text);
                SearchGridView.DataBind();

                if (SearchGridView.Rows.Count == 0)
                {
                    ErrorMessageLabel.Text = AppConstants.errorNoRecordsFound;
                    ErrorMessageLabel.ForeColor = System.Drawing.Color.Blue;
                }
            }
            catch (AppControlException ex)
            {
                ErrorMessageLabel.Text = ex.Message;
                ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
            }
            this.clearSearchFields();
        }

        private void clearSearchFields() 
        {
            LastNameTextBox.Text = "";
            GivenNamesTextBox.Text = "";
            BankCheckBoxList.ClearSelection();
            ServicesCheckBoxList.ClearSelection();

        }

        private void createCheckBoxes()
        {
            SurveyLogicControl surveyLogicControl = new SurveyLogicControl();

            /* Bank check box list */
            List<QuestionAnswerOptions> bankQuestionAnswerOptionsList =
                surveyLogicControl.getListOfQuestionAnswerOptionByQuestionId(AppConstants.questionBank);

            for (var i = 0; i < bankQuestionAnswerOptionsList.Count; i++)
            {
                ListItem item = new ListItem(bankQuestionAnswerOptionsList[i].AnswerDescription,
                                             bankQuestionAnswerOptionsList[i].SurveyAnswerOptionId.ToString());
                BankCheckBoxList.Items.Add(item);
            }

            /* Bank Services check box list */
            List<QuestionAnswerOptions> bankServiceQuestionAnswerOptionsList =
                surveyLogicControl.getListOfQuestionAnswerOptionByQuestionId(AppConstants.questionBankServices);

            for (var i = 0; i < bankServiceQuestionAnswerOptionsList.Count; i++)
            {
                ListItem item = new ListItem(bankServiceQuestionAnswerOptionsList[i].AnswerDescription,
                                             bankServiceQuestionAnswerOptionsList[i].SurveyAnswerOptionId.ToString());
                ServicesCheckBoxList.Items.Add(item);
            }

        }
    }
}