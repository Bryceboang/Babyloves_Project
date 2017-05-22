<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Home_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .txtLogin { 
            border: 3px groove #0000FF; 
            outline:0; 
            height:25px; 
            width: 200px; 
        }
        .btnLogin {
	        background-color:#0558ff;
	        display:inline-block;
	        cursor:pointer;
	        color:#ffffff;
	        font-family:Georgia;
	        font-size:16px;
	        padding:7px 50px;
	        text-decoration:none;
	        text-shadow:0px 1px 0px #154682;
        }
        .btnLogin:hover {
	        background-color:#0061a7;
        }
        .btnLogin:active {
	        position:relative;
	        top:1px;
        }
        .main {
            width: 100%;
            height: 560px;
            overflow: auto;
        }

        .left {
            float: left;
            width: 28%;
            margin-right: 5%;
            background-color: white;
            opacity: 0.7;
            filter: alpha(opacity=60); /* For IE8 and earlier */
            height: 100%;
        }
        .right {
            float: right;
            width: 15%;
        }
        h2.ontop {
            position: relative;
            top: 4.7em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="SweetAlert/dist/sweetalert.min.js"></script>
    <link rel="stylesheet" type="text/css" href="SweetAlert/dist/sweetalert.css">

    <script>
        function sweetAlertMessage(myTitle, myText) {
            swal(
             title = myTitle,
             text = myText
         );
        }

        function sweetAlertWarning(myText) {
            swal(
             title = "Warning",
             text = myText,
             type = "warning"
         );
        }

        function sweetAlertError(myText) {
            swal(
             title = "Error",
             text = myText,
             type = "error"
         );
        }

        function sweetAlertInfo(myText) {
            swal(
             title = "Information",
             text = myText,
             type = "info"
         );
        }
    </script>
    <div class="main">
        <div class="left"> <div> <br /> <br /> <br /> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmpNum" CssClass="txtLogin" runat="server" placeholder="Employee Number"></asp:TextBox> <br /> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPass" CssClass="txtLogin" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox> <br /> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLogin" CssClass="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" /></div>
        </div>
        <div class="right"> <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="../Image/Logo_of_Petron.svg.png" width="85px" height="100px" />
        </div>
    </div>
</asp:Content>

