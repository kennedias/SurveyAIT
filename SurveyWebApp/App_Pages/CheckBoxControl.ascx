<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckBoxControl.ascx.cs" Inherits="SurveyWebApp.App_Pages.CheckBoxControl" %>
<asp:Label ID="questionDescriptionLabel" runat="server" Text="Label"></asp:Label>
<p>
    <asp:CheckBoxList ID="questionAnswerCheckBoxList" runat="server">
    </asp:CheckBoxList>
</p>