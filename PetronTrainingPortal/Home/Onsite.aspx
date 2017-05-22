<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.master" AutoEventWireup="true" CodeFile="Onsite.aspx.cs" Inherits="Home_Onsite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            width: 72%;
            background-color: white;
            height: 512px;
        }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
        }

        /* The Close Button */
        .close {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    </script>


    <div class="main">
        <div class="left">
            <img src="../Image/Onsite.jpg" />
        </div>
        <div class="right">
            <asp:Panel ID="menuPanel" runat="server" Height="500px" ScrollBars="Auto">
            </asp:Panel>
        </div>
    </div>
</asp:Content>

