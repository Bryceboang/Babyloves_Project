<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Supervisor/Supervisor.master" AutoEventWireup="true" CodeFile="SupervisorSubmit.aspx.cs" Inherits="Home_Supervisor_SupervisorSubmit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Supervisor.css" rel="stylesheet" />
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
            <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" OnClick="btnLogout_Click" />
        </div>
        </div>
        <div class="right">
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Submit" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label>
        </div>
        <div class="rightsubmit">
            <asp:Label ID="Label2" runat="server" Text="Please review list below if complete and final for compliance. Kindly key-in your full name for authentication then click the submit button." Font-Names="Corbel"></asp:Label>
        </div>
        <div class="rightsubmit">
            <asp:Label ID="Label4" runat="server" Text="I verify that the following registration is valid and will conform to the terms and conditions set by the Technical Training Department." Font-Names="Corbel"></asp:Label> <br />
            <asp:TextBox ID="TextBox1" CssClass="txtBox" placeholder="Enter Full Name here" runat="server"></asp:TextBox>
        </div>
    </div>
</asp:Content>

