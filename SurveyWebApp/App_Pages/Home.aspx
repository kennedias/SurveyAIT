<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SurveyWebApp.App_Pages.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Survey</title>
</head>
<body>
    <h1>Survey</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="UserLabel" runat="server" Text="User ID: "></asp:Label>
        <asp:TextBox ID="UserIdTextBox" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="UserRequiredFieldValidator" runat="server" ControlToValidate="UserIdTextBox" ErrorMessage="* Field Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="PasswordLabel" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ControlToValidate="PasswordTextBox" ErrorMessage="* Field Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />

        <br />
    
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
        <br />
        <br />
        <asp:Label ID="ErrorMessageLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="StartSurveyLinkButton" runat="server" OnClick="StartSurveyLinkButton_Click">Start Survey</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
