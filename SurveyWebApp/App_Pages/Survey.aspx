<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="SurveyWebApp.App_Pages.Survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <p><h1>Survey</h1></p>
        <asp:PlaceHolder ID="SurveyTextPlaceHolder" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="SurveyCheckboxPlaceHolder" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="SurveyRadioButtonPlaceHolder" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="SurveyDropDownListPlaceHolder" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Button ID="NextButton" runat="server" OnClick="NextButton_Click" Text="Next" />
        <p>
            <asp:Label ID="ErrorMessageLabel" runat="server"></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
