<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Training Evaluation/TrainingEvaluation.master" AutoEventWireup="true" CodeFile="DefaultEvaluation.aspx.cs" Inherits="Home_Training_Evaluation_DefaultEvaluation" %>

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
            margin-right: 5%;
            background-color: white;
            opacity: 0.3;
            filter: alpha(opacity=60); /* For IE8 and earlier */
            height: 100%;
        }
        .left p {
            margin: 5%;
            font-weight: bold;
            color: #000000;
        }
        .right {
            float: left;
            width: 53%;
            background-color: red;
            opacity: 0.5;
            filter: alpha(opacity=60); /* For IE8 and earlier */
            height: 20%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">
        <div class="left"> <br />
            &nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Training Evaluation" ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="23pt" Font-Bold="True"></asp:Label>
        </div>
        <br />
        <div class="right"> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Page under construction." ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="15pt" Font-Bold="True"></asp:Label>
        </div>
    </div>
</asp:Content>

