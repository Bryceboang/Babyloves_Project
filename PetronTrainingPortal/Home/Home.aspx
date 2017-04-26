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

        .logo {
            float: right;
        }

        .header {
            background-color: grey;
            color: white;
            padding: 15px;
        }

        .main {
            width: 100%;
            height: 499px;
            overflow: auto;
        }

        .left {
            float: left;
            width: 79%;
            margin-right: 1%;
        }

            .left img {
                float: right;
            }

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

    <ul>


        <form id="form1" runat="server">
            <header>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img class="auto-style1" src="../Image/header.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnTrainingPrograms" ImageUrl="~/Image/training program.jpg" AlternateText="No Image available" runat="server" />
                <asp:ImageButton ID="btnTrainingEvaluation" ImageUrl="~/Image/training evaluation.jpg" AlternateText="No Image available" runat="server" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <%--<asp:Button ID="Button2" runat="server" Text="Button" />--%>
            </header>
    </ul>
    <div>
    </div>
    <div>
    </div>
    <%--<div class="content">
    <div class ="left_content"--%>
    <%--<asp:Panel ID="Panel1" runat="server" BackColor="White" style="margin-left: 50px" Width="660px" Height="350px">
            <asp:Label ID="Label1" runat="server" Text="REFINE.com" Font-Bold="True"></asp:Label> <br /> <br />
            <asp:Label ID="Label2" runat="server" Text="A gateway and medium to connect, refresh and enhance the refiners knowledge through training programs which can be requested from the department via online. This site will be an avenue for Supervisors and Managers to nominate and register employees in Training Programs. Ultimately,  REFINE.com will provide the refiners link to the completion of the full Training Cycle covering the following phases (1) Training Need Analysis, (2) Training Design, (3) Implementation and (4) Evaluation in coordination with Technical Training Department. 
                <br/> <br/> In our objective to ensure training effectiveness, we want to hear from the trainees and superiors of the trainees. <br /> Let us know which training have been applied, if personnel performance have been upgraded and learnings are manifested. <br/> <br/> 
                We understand the day to day work load that each and everyone undergoes, and with this we hope to help, ease  the weight and bring you closer to your training needs. <br /> <br />
                Mr. Emerson G. Chua <br /> <br />
                Technical Training Manager"></asp:Label>
        </asp:Panel>--%>
    <%--<img src="../Image/Logo_of_Petron.svg.png" width="70px" height="70px" />--%>
    <%--</div>--%>
    <%--<div class="logo">
            <img src="../Image/Logo_of_Petron.svg.png" width="50px" height="70px" />
        </div>--%>

    <%--</div>--%>
    <div class="main">
        <div class="left">
            <img src="../Image/Home%20Message.png" />
        </div>
        <div class="right">
            <br />
            <br />
            <img src="../Image/Logo_of_Petron.svg.png" width="85px" height="100px" />
        </div>
    </div>

    </form>
</body>
</html>
