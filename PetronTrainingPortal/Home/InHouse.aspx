<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.master" AutoEventWireup="true" CodeFile="InHouse.aspx.cs" Inherits="Home_InHouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
    .main {
            width: 100%;
            height: 100%;
            overflow: auto;
        }

        .left {
            float: left;
            width: 28%;
            margin-right: 0%;
            height: 100%;
        }
        .right {
            float: left;
            width: 55%;
            background-color: white;
            height: 100%;
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

        function sweetAlertSuccess(myText) {
            swal(
             title = myText
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
        <div class="left">
            <img src="../Image/InHouse.jpg" />
        </div>
        <div class="right">
            <asp:Panel ID="menuPanel" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>

