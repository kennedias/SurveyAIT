<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SurveyWebApp.App_Pages.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p><h1>Register</h1></p>
    
        Given Names :
        <asp:TextBox ID="GivenNameTextBox" runat="server" MaxLength="20" Width="244px"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="GivenNamesRequiredFieldValidator" runat="server" ControlToValidate="GivenNameTextBox" Display="Dynamic" ErrorMessage="* field required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <br />
        Last Name:
        <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="20" Width="253px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ControlToValidate="LastNameTextBox" ErrorMessage="* field required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <br />
        Date of Birth:
        <asp:TextBox ID="DateOfBirthTextBox" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="DateOfBirthRequiredFieldValidator" runat="server" ControlToValidate="DateOfBirthTextBox" ErrorMessage="* field required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="DateOfBirthCustomValidator" runat="server" ControlToValidate="DateOfBirthTextBox" onservervalidate="validateDateOfBirth" ErrorMessage="* Invalid date of birth" ForeColor="#FF3300"></asp:CustomValidator>
        <br />
        <br />
        Contact Phone Number: <asp:TextBox ID="PhoneNumberTextBox" runat="server" MaxLength="15" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ContactPhoneNumberRequiredFieldValidator" runat="server" ControlToValidate="PhoneNumberTextBox" ErrorMessage="* field required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Button ID="ConfirmRegistrationButton" runat="server" Text="Confirm Registration" OnClick="ConfirmRegistrationButton_Click" />
        <br />
        <br />
        <asp:Label ID="ErrorMessageLabel" runat="server"></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
