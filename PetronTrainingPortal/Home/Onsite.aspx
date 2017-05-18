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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="left">
            <img src="../Image/Onsite.jpg" />
        </div >
     <div class="right">
            <asp:Panel ID="menuPanel" runat="server" height="500px" ScrollBars="Auto" >
            </asp:Panel>
       </div >
    </div>
</asp:Content>

