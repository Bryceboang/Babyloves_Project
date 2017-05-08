<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REFINE.com</title>
    <style>
        .auto-style1 {
            width: 221px;
            height: 51px;
        }
    </style>
    <link href="Home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <ul>
    <header>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img class="auto-style1" src="../Image/header.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnTrainingPrograms" ImageUrl="~/Image/Buttons/TrainingProgram.jpg"  AlternateText="No Image available" runat="server" OnClick="btnTrainingPrograms_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnTrainingEvaluation" ImageUrl="~/Image/Buttons/TrainingEvaluation.jpg"  AlternateText="No Image available" runat="server" OnClick="btnTrainingEvaluation_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <%--<asp:Button ID="Button2" runat="server" Text="Button" />--%>
    </header>
    </ul>
    <div> <br />
    </div>
    <div> <br />
    </div>
    <div class="mainhome">
    <div class="lefthome">
        <img src="../Image/Refine%20message.jpg" />
    </div>
    <div class="righthome">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img src="../Image/Logo_of_Petron.svg.png" width="85px" height="100px" />
    </div>
    </div>
    </form>
</body>
</html>
