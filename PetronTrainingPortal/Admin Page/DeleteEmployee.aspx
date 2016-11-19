<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="DeleteEmployee.aspx.cs" Inherits="Admin_Page_DeleteEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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

.text  {
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

select.custom-dropdown {
 -webkit-appearance: none;  /*REMOVES DEFAULT CHROME & SAFARI STYLE*/
 -moz-appearance: none;  /*REMOVES DEFAULT FIREFOX STYLE*/
 border: 0 !important;  /*REMOVES BORDER*/

 color: #fff;
 -webkit-border-radius: 5px;
 border-radius: 5px;
 font-size: 14px;
 padding: 10px;
 width: 35%;
 cursor: pointer;

 background: #0060ff url(drop-down-arrow.png) no-repeat right center;
 background-size: 40px 37px; /*TO ACCOUNT FOR @2X IMAGE FOR RETINA */
}

.container {
    padding: 16px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <h2>DELETE EMPLOYEE</h2>
        <div class="container">
            <asp:Label ID="Label1" runat="server" Text="Employee Number:" Font-Size="X-Large" Width="210px"></asp:Label>
            &nbsp;<asp:TextBox CssClass="text" ID="txtBoxEmployeeNumber" runat="server" Font-Size="14pt" ValidationGroup="DeleteEmp"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBoxEmployeeNumber" ErrorMessage="*" ForeColor="Red" ValidationGroup="DeleteEmp"></asp:RequiredFieldValidator>
            <asp:Label ID="lblEmpNoMsg" runat="server" ForeColor="Red" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnSearch" CssClass="button" runat="server" Text="Search" OnClick="btnSearch_Click" Font-Size="15pt" ValidationGroup="DeleteEmp" />
            &nbsp;<asp:Button ID="btnClear" CssClass="button" runat="server" Text="Clear" OnClick="btnClear_Click"  Font-Size="15pt" />
            <br />
            <asp:Label ID="lblFullName" runat="server" Font-Size="X-Large" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnDelete" CssClass="button" runat="server" Text="Delete" OnClick="btnDelete_Click"  Font-Size="15pt" ValidationGroup="DeleteEmp"></asp:Button>
        </div>
    </center>
</asp:Content>

