<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.master" AutoEventWireup="true" CodeFile="OtherTraining.aspx.cs" Inherits="Home_OtherTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .main {
            width: 100%;
            height: 499px;
            overflow: auto;
        }

        img {
            opacity: 0.5;
            filter: alpha(opacity=50); /* For IE8 and earlier */
        }

        .left {
            float: left;
            width: 28%;
            margin-right: 5%;
            background-color: white;
            opacity: 0.6;
            filter: alpha(opacity=100); /* For IE8 and earlier */
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
            filter: alpha(opacity=100); /* For IE8 and earlier */
            height: 20%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">
        <div class="left"> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <%--<asp:Label ID="Label1" runat="server" Text="Other Training" ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="23pt" Font-Bold="True"></asp:Label>--%> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Modules" ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="23pt" Font-Bold="True"></asp:Label> <br /> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="a list and links of training" ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="13pt" Font-Bold="True"></asp:Label> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="modules taken by newly" ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="13pt" Font-Bold="True"></asp:Label> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="promoted employees and" ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="13pt" Font-Bold="True"></asp:Label> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Text="specialized, customized based" ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="13pt" Font-Bold="True"></asp:Label> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="on their needs." ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="13pt" Font-Bold="True"></asp:Label>
        </div>
        <br />
        <div class="right"> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Page under construction." ForeColor="Black" Font-Names="Goudy Old Style" Font-Size="15pt" Font-Bold="True"></asp:Label>
        </div>
    </div>
</asp:Content>

