﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Supervisor/Supervisor.master" AutoEventWireup="true" CodeFile="SupervisorList.aspx.cs" Inherits="Home_Supervisor_SupervisorList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Supervisor.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">
    <div class="left">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblHello" runat="server" Text="Hello!" ForeColor="Black" Font-Bold="True">
        </asp:Label> &nbsp;<asp:Label ID="lblName" runat="server" Text="" ForeColor="Black" Font-Bold="True"></asp:Label> <br /> <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnShoppingCart" ImageUrl="~/Image/Buttons/ShoppingCart.jpg"  AlternateText="No Image available" runat="server" OnClick="btnNominateApprove_Click"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnNominateApprove" ImageUrl="~/Image/Buttons/Nominate.jpg"  AlternateText="No Image available" runat="server" OnClick="btnNominateApprove_Click"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="btnViewStatus" ImageUrl="~/Image/Buttons/ViewStatus.jpg"  AlternateText="No Image available" runat="server" OnClick="btnViewStatus_Click"/> <br /> <br /> <br /> <br /> <br /> <br /> <br />
       <div class="logoutdiv">
            <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" OnClick="btnLogout_Click" />
       </div>
    </div>
    </div>
    </asp:Content>

