﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.master" AutoEventWireup="true" CodeFile="LocalTraining.aspx.cs" Inherits="Home_LocalTraining" %>

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
            width: 72%;
            background-color: white;
            height: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="sweetalert-master/dist/sweetalert.min.js"></script>
    <link href="sweetalert-master/dist/sweetalert.css" rel="stylesheet" />
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
            <img src="../Image/LocalTraining.jpg" />
        </div>
        
        <div class="right">
            <asp:Panel ID="menuPanel" runat="server" Height="513px" ScrollBars="Auto" >
            </asp:Panel>
        </div>
    </div>
</asp:Content>

