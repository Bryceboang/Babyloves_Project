﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Manager/Manager.master" AutoEventWireup="true" CodeFile="ManagerSubmit.aspx.cs" Inherits="Home_Manager_ManagerSubmit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Manager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">
        <div class="left">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Hello!" ForeColor="Black" Font-Bold="True"></asp:Label>
        &nbsp;<asp:Label ID="lblName" runat="server" Text="" ForeColor="Black" Font-Bold="True"></asp:Label> <br /> <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" Text="Review" ForeColor="Black" Font-Bold="True" Font-Size="15"></asp:Label><br /> <br /> <br /> <br /> <br /> <br /> <br />
       <br /> <br /> <br /> <br /> <br /> <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" />
        </div>
        <div class="right">
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="16pt" ForeColor="White" Text="Submit"></asp:Label>
        </div>
        <div class="rightsubmitbtn">
            <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />
        <asp:Button ID="btnSubmit" CssClass="submit" runat="server" Text="Submit" Font-Bold="True" Width="100px" />
        </div>
        </div>
</asp:Content>

