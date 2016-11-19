<%@ Page Title="" Language="C#" MasterPageFile="~/Users Page/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.text {
    width: 50%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    border-radius: 4px;
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

.submit:hover  {
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

       

.container {
    padding: 16px;
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <h2><asp:Label ID="lblTitle" runat="server" Text="EMPLOYEE DETAILS"></asp:Label></h2>
    <div class="container">
        <asp:Label ID="lblFname" runat="server" Text="Full Name:" Width="150px" Font-Size="13pt"></asp:Label>
        <asp:TextBox CssClass="text" ID="txtFirstName" runat="server" Font-Size="14pt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="registration" ControlToValidate="txtFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblMidInitial" runat="server" Text="Email Address:" Width="150px" Font-Size="13pt"></asp:Label>
        <asp:TextBox CssClass="text" ID="txtMiddleInitial" runat="server" Font-Size="14pt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="registration" ForeColor="Red" ControlToValidate="txtMiddleInitial"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblLname" runat="server" Text="Position:" Width="150px" Font-Size="13pt"></asp:Label>
        <asp:TextBox CssClass="text" ID="txtLastName" runat="server" Font-Size="14pt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="registration" ControlToValidate="txtLastName" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblEmailAdd" runat="server" Text="Department:" Width="150px" Font-Size="13pt"></asp:Label>
        <asp:TextBox CssClass="text" ID="txtEmailAddress" runat="server" TextMode="Email" Font-Size="14pt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ValidationGroup="registration" ControlToValidate="txtEmailAddress" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblContactNum" runat="server" Text="Section:" Width="150px" Font-Size="13pt"></asp:Label>
        <asp:TextBox CssClass="text" ID="txtContactNumber" runat="server" TextMode="Number" Font-Size="14pt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ValidationGroup="registration" ControlToValidate="txtContactNumber" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Employee Number:" Width="150px" Font-Size="13pt"></asp:Label><asp:TextBox CssClass="text" ID="lblEmployeeNumber" runat="server" Enabled="False" Font-Size="14pt"></asp:TextBox>
        <br />
        <asp:Button CssClass="button" ID="btnSave" runat="server" Text="Submit" ValidationGroup="registration" OnClick="btnSave_Click" Font-Size="15pt"></asp:Button>
    </div>
</center>
   
</asp:Content>

