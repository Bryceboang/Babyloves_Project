<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Manager/Manager.master" AutoEventWireup="true" CodeFile="ManagerList.aspx.cs" Inherits="Home_Manager_ManagerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Manager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">
    <div class="left">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Hello!" ForeColor="Black" Font-Bold="True">
        </asp:Label> &nbsp;<asp:Label ID="lblName" runat="server" Text="" ForeColor="Black" Font-Bold="True"></asp:Label> <br /> <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnShoppingCart" ImageUrl="~/Image/Buttons/ShoppingCart.jpg"  AlternateText="No Image available" runat="server" OnClick="btnShoppingCart_Click"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnNominate" ImageUrl="~/Image/Buttons/Nominate.jpg"  AlternateText="No Image available" runat="server" OnClick="btnNominate_Click"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnApprove" ImageUrl="~/Image/Buttons/Approve.jpg"  AlternateText="No Image available" runat="server" OnClick="btnApprove_Click"/>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="btnViewStatus" ImageUrl="~/Image/Buttons/ViewStatus.jpg"  AlternateText="No Image available" runat="server" OnClick="btnViewStatus_Click"/> <br /> <br /> <br /> <br /> <br /> <br /> <br />
       <br /> <br /> <br /> <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" />
    </div>
    </div>
</asp:Content>

