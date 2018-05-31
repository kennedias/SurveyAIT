<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SurveyWebApp.App_Pages.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p><h1>Search</h1>Search criteria</p>
        <p>
            <strong>Last Name*: </strong>
            <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LastNameTextBox" ErrorMessage="* Field Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </p>
        <p>
            <strong>Given Names:</strong>
            <asp:TextBox ID="GivenNamesTextBox" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="GivenNamesTextBox" ErrorMessage="* Field Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            <strong>Banks</strong></p>
        <p>
            <asp:CheckBoxList ID="BankCheckBoxList" runat="server">
            </asp:CheckBoxList>
        </p>
        <p>
            <strong>Bank Services Used</strong></p>
        <p>
            <asp:CheckBoxList ID="ServicesCheckBoxList" runat="server">
            </asp:CheckBoxList>
        </p>
        <p>
            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="ErrorMessageLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="SearchGridView" runat="server">
            </asp:GridView>
        </p>
    </div>
    </form>
</body>
</html>
