﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_Page_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Supervisor.css" rel="stylesheet" />
    <style>
        .text {
            width: 50%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }


        .submit {
            width: 20%;
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

            .submit:hover {
                background-color: #45a049;
            }

        .button {
            background-color: #0054a6;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 20%;
        }

        .container {
            padding: 16px;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }
    </style>
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
            function Confirm2() {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Second question?")) {
                    confirm_value.value = "Yes";
                } else {
                    confirm_value.value = "No";
                }
                document.forms[0].appendChild(confirm_value);
                
            }
            function LAST() {
                onclick = "Confirm2";
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
          <asp:Label ID="Label1" runat="server" ForeColor="White" Text="CHANGE PASSWORD" Font-Size="16pt"></asp:Label>
        <div class="container">
            <br />
            <asp:Label ID="lblOldpass" runat="server" Text="Old Password:" Width="130px" Font-Size="13pt" ForeColor="White"></asp:Label>
            <asp:TextBox CssClass="text" ID="txtBoxOldPass" runat="server" placeholder="Enter Old Password" TextMode="Password" ValidationGroup="changepass" Font-Size="14pt"></asp:TextBox>
                     &nbsp; <asp:Label ID="ErrorEmpNo" runat="server" ForeColor="Red" Text=""></asp:Label>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtBoxOldPass" ForeColor="Red" ValidationGroup="changepass"></asp:RequiredFieldValidator>
            <br/>
            <asp:Label ID="lblNewpass" runat="server" Text="New Password:" Width="130px" Font-Size="13pt" ForeColor="White"></asp:Label>
            <asp:TextBox CssClass="text" ID="txtBoxNewPass" runat="server" placeholder="Enter New Password" ValidationGroup="changepass" TextMode="Password" Font-Size="14pt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtBoxNewPass" ForeColor="Red" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                      &nbsp; <asp:Label ID="ErrorEmpNo2" runat="server" ForeColor="Red" Text=""></asp:Label>
           </br>
               <asp:Button CssClass="button" ID="btnChangePass" runat="server" Text="Submit" type="submit" ValidationGroup="changepass" OnClick="btnChangePass_Click" Font-Size="10pt" Height="45px" Width="163px"></asp:Button>
            <asp:Button ID="btnConfirm" runat="server" Text="Button" OnClick="OnConfirm" OnClientClick="Confirm()"></asp:Button>
            <asp:Button ID="Button1" runat="server" Text="Button" Visible="false" OnClick="OnConfirm2" OnClientClick="Confirm2()"></asp:Button>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
    </center>
</asp:Content>

