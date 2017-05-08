<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Manager/Manager.master" AutoEventWireup="true" CodeFile="ManagerSuccessful.aspx.cs" Inherits="Home_Manager_ManagerSuccessful" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Manager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">
        <div class="left">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblHello" runat="server" Text="Hello!" ForeColor="Black" Font-Bold="True"></asp:Label>
        &nbsp;<asp:Label ID="lblName" runat="server" Text="" ForeColor="Black" Font-Bold="True"></asp:Label> <br /> <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" Text="Review" ForeColor="Black" Font-Bold="True" Font-Size="15"></asp:Label><br /> <br /> <br /> <br /> <br /> <br /> <br />
        <div class="logoutdiv">
        <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" />
        </div>
        </div>
        <div class="rightconfirmation">
            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Thank you! Your confirmation has been successfully passed  to the Technical Training Department. For status updates ,  click here or view the  Status Page." Font-Names="Corbel"></asp:Label> <br /> <br />
            <asp:HyperLink ID="HyperLink1" CssClass="hyperlink" ForeColor="White" runat="server" NavigateUrl="~/Home/Default.aspx">Go back to Shopping Cart</asp:HyperLink>
        </div>
    </div>
</asp:Content>

