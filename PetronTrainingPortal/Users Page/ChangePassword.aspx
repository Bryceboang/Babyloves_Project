<%@ Page Title="" Language="C#" MasterPageFile="~/Users Page/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        div {
            border-radius: 5px;
            background-color: #f2f2f2;
            padding: 20px;
        }

           h2 { 
    display: block;
    font-size: 3em;
    margin-top: 0.30em;
    margin-bottom: 0.30em;
    margin-left: 0;
    margin-right: 0;
    font-weight: bold;
}


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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <center>
      <h2>CHANGE PASSWORD</h2>
        <div class="container">
            <br />
            <asp:Label ID="lblOldpass" runat="server" Text="Old Password:" Width="130px" Font-Size="13pt"></asp:Label>
            <asp:TextBox CssClass="text" ID="txtBoxOldPass" runat="server" placeholder="Enter Old Password" TextMode="Password" ValidationGroup="changepass" Font-Size="14pt"></asp:TextBox>
                     &nbsp; <asp:Label ID="ErrorEmpNo" runat="server" ForeColor="Red" Text=""></asp:Label>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtBoxOldPass" ForeColor="Red" ValidationGroup="changepass"></asp:RequiredFieldValidator>
            <br/>
            <asp:Label ID="lblNewpass" runat="server" Text="New Password:" Width="130px" Font-Size="13pt"></asp:Label>
            <asp:TextBox CssClass="text" ID="txtBoxNewPass" runat="server" placeholder="Enter New Password" ValidationGroup="changepass" TextMode="Password" Font-Size="14pt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtBoxNewPass" ForeColor="Red" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                      &nbsp; <asp:Label ID="ErrorEmpNo2" runat="server" ForeColor="Red" Text=""></asp:Label>
           </br>
               <asp:Button CssClass="button" ID="btnChangePass" runat="server" Text="Submit" type="submit" ValidationGroup="changepass" OnClick="btnChangePass_Click" Font-Size="15pt"></asp:Button>
        </div>
    </center>

</asp:Content>

