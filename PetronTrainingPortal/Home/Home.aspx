<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REFINE.com</title>
    <style>
        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: white;
            height: 50px;
        }

        body {
            background-image: url("../Image/PictureTanker1.jpg");
            background-repeat: no-repeat;
        }

        .header {
            background-color: white;
            color: white;
            padding: 15px;
        }

        .main {
            width: 100%;
            height: 505px;
            overflow: auto;
        }

        .left {
            float: left;
            width: 79%;
            margin-right: 1%;
        }
        /*.left img {
                float: right;
            }*/

        .right {
            float: right;
            width: 15%;
        }

        .auto-style1 {
            width: 221px;
            height: 51px;
        }
    </style>
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
    <div class="main">
    <div class="left">
        <img src="../Image/Refine%20message.jpg" />
    </div>
    <div class="right">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img src="../Image/Logo_of_Petron.svg.png" width="85px" height="100px" />
    </div>
    </div>
    </form>
</body>
</html>
