<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .main {
            width: 100%;
            height: 499px;
            overflow: auto;
        }

        .left {
            float: left;
            width: 28%;
            margin-right: 1%;
            background-color: #ffffff;
            opacity: 0.6;
            filter: alpha(opacity=60); /* For IE8 and earlier */
            height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">
    <div class="left">
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Training Programs" ForeColor="Black" Font-Bold="True"></asp:Label> <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnOnsiteTraining" ImageUrl="~/Image/Buttons/OnsiteTraining.jpg"  AlternateText="No Image available" runat="server" OnClick="btnOnsiteTraining_Click"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnInHouseTraining" ImageUrl="~/Image/Buttons/InHouseTraining.jpg"  AlternateText="No Image available" runat="server" OnClick="btnInHouseTraining_Click"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnLocalTraining" ImageUrl="~/Image/Buttons/LocalTraining.jpg"  AlternateText="No Image available" runat="server" OnClick="btnLocalTraining_Click"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnTrainingModules" ImageUrl="~/Image/Buttons/TrainingModules.jpg"  AlternateText="No Image available" runat="server" OnClick="btnTrainingModules_Click"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnRefineryProgram" ImageUrl="~/Image/Buttons/RefineryEngineer.jpg"  AlternateText="No Image available" runat="server"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnOtherTraining" ImageUrl="~/Image/Buttons/OtherTraining.jpg"  AlternateText="No Image available" runat="server"/>
    </div>
    </div>

</asp:Content>

