<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage/MasterPageHomePage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="HomePage_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="dropdown_menu_new_files/mbcsmbmcp.css" rel="stylesheet" />
    <style>
        .label {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Online Registration" Font-Bold="True" Font-Size="16pt" Font-Names="Verdana"></asp:Label>
    <img src="../Image/line.png" width="1085px" />
    <asp:Label ID="Label2" runat="server" Text="Logon" Font-Bold="True" Font-Size="13pt" Font-Names="Verdana"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" CssClass="label" Text="Employee Number:" Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Width="170px" ></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" CssClass="label" Text="Password:" Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Width="170px"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server" Width="150px"></asp:TextBox>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnLogon" runat="server" Text="Log on"/>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" CssClass="label" Text="Request for a new password, " Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Width="219px"></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" Font-Names="Verdana" Font-Size="9pt">click here.</asp:HyperLink>
</asp:Content>

