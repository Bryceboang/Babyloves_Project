<%@ Page Title="" Language="C#" MasterPageFile="~/Main Page/MasterPageMain.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Main_Page_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Home.css" rel="stylesheet" media="screen" />
    <script src="home_files/mbjsmbmcp.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <center><asp:Label ID="lblPbr" runat="server" Text="Petron Bataan Refinery" Font-Bold="True" Font-Names="SansSerif" Font-Size="20pt" ForeColor="White"></asp:Label>
            <br />
            <asp:Label ID="lblTechDpt" runat="server" Text="Technical Training Department" Font-Bold="False" Font-Names="SansSerif" Font-Size="15pt" ForeColor="White"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblTrngPrtal" runat="server" Text="TRAINING PORTAL" Font-Bold="True" Font-Names="Calibri" Font-Size="30pt" Font-Overline="False" Font-Strikeout="False" ForeColor="Red"></asp:Label>
            <br />
            <div class="main_container">
                <asp:Label ID="Label3" runat="server" Text="Already registered?" ForeColor="White" Font-Names="Calibri"></asp:Label>
            <div class="main_box">
            <asp:Label ID="lblEmpNo" runat="server" Text="Employee No:" ForeColor="White" Font-Bold="True" Font-Names="Calibri"></asp:Label>
                <br />
            <asp:TextBox ID="txtBoxEmpno" CssClass="text" runat="server" placeholder="Enter Employee Number" ValidationGroup="login"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtBoxEmpno" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
            <br/>
            <asp:Label ID="lblPassword" runat="server" Text="Password:" ForeColor="White" Font-Bold="True" Font-Names="Calibri"></asp:Label>
                <br />
            <asp:TextBox ID="txtBoxPass" CssClass="text" runat="server" type="password" placeholder="Enter Password" ValidationGroup="login"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtBoxPass" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
            <br/>
            <br />
            <a href="mailto:escruz@petron.com?subject=Reset Password&body=Requesting to reset my password in Training Portal.">Forgot Password?</a>
            <br />
            <br />
            <asp:Button CssClass="buttonbg" ID="btnLogin" runat="server" Text="Log In" type="submit" OnClick="btnLogin_Click" ValidationGroup="login" ForeColor="White"></asp:Button>
            </div>
            </div>
            <%--<div class="main_container1">
                <asp:Label ID="Label4" runat="server" Text="Not yet a member?" ForeColor="White"></asp:Label>
                <div class="main_box1">
                    <asp:Button CssClass="buttonsu" ID="Button2" runat="server" Text="Sign up" ForeColor="White"></asp:Button>
                </div>
            </div>--%>



        <%--<div class="container">
            <asp:Label ID="lblEmpNo" runat="server" Text="Employee No:" Width="180px" Font-Bold="true" Font-Size="18pt"></asp:Label>
            <asp:TextBox CssClass="text" ID="txtBoxEmpno" runat="server" placeholder="Enter Employee Number" ValidationGroup="login" Font-Size="14pt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtBoxEmpno" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
            <br/>
            <asp:Label ID="lblPassword" runat="server" Text="Password:" Width="180px" Font-Bold="true" Font-Size="18pt"></asp:Label>
            <asp:TextBox CssClass="text" ID="txtBoxPass" runat="server" type="password" placeholder="Enter Password" ValidationGroup="login" Font-Size="14pt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtBoxPass" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
            <br/>
            
            <a href="mailto:escruz@petron.com?subject=Reset Password&body=Requesting to reset my password in Training Portal.">Forgot Password?</a>
            <br />
            <br />
            <asp:Button CssClass="button" ID="btnLogin" runat="server" Text="Submit" type="submit" OnClick="btnLogin_Click" ValidationGroup="login" Font-Size="15pt"></asp:Button>
        </div>--%>
            
    </center>
 
</asp:Content>

