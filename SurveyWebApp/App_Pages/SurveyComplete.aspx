<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyComplete.aspx.cs" Inherits="SurveyWebApp.App_Pages.SurveyComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p><h1>Survey has been completed successfully</h1></p>
        <br />
        <br />
        <p>
            Would you would like to register?&nbsp;</p>
        <p>
            <asp:Button ID="RegisterButton" runat="server" OnClick="RegisterButton_Click" Text="Register" />
        </p>
    </div>
    </form>
</body>
</html>
