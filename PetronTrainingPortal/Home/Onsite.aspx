<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.master" AutoEventWireup="true" CodeFile="Onsite.aspx.cs" Inherits="Home_Onsite" %>

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
    <div class="main">
        <div class="left">
            <img src="../Image/Onsite.jpg" />
        </div>
        <div class="right">
            <asp:Panel ID="Panel1" runat="server" Height="100%" Width="650px"></asp:Panel>
        </div>
    </div>
</asp:Content>

