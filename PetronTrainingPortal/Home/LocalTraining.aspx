<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.master" AutoEventWireup="true" CodeFile="LocalTraining.aspx.cs" Inherits="Home_LocalTraining" %>

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
            <img src="../Image/LocalTraining.jpg" />
        </div>
        
        <div class="right">
                            <asp:LinkButton ID="lnkPrevious" runat="server" OnClick="lnkPrevious_Click"><<<</asp:LinkButton>   &nbsp;&nbsp;
               <asp:Label ID="lblCount" runat="server" Text="1 of 2" ForeColor="Black" Font-Bold="True" Font-Names="Corbel"></asp:Label>   &nbsp;&nbsp;
                  <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click">>>></asp:LinkButton>
            <asp:Panel ID="menuPanel" runat="server" >

            </asp:Panel>
        </div>
    </div>
</asp:Content>

