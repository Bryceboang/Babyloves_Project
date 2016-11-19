<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="DeleteUser.aspx.cs" Inherits="DeleteUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
 /*div {
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
}*/

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
            <h2>DELETE USER</h2>
                <div class="container">
                    <asp:Label ID="Label1" runat="server" Text="Employee Number:" Font-Size="X-Large" Width="200px"></asp:Label>
                    &nbsp;<asp:TextBox CssClass="text" ID="txtBoxEmployeeNumber" runat="server" Font-Size="14pt" ValidationGroup="DeleteUser"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBoxEmployeeNumber" ErrorMessage="*" ForeColor="Red" ValidationGroup="DeleteUser"></asp:RequiredFieldValidator>
                      <asp:Label ID="ErrorEmpNo" runat="server" ForeColor="Red" Text=""></asp:Label>
                                       <br />
                     <asp:Button ID="btnSearch" CssClass="button" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="DeleteUser" Font-Size="15pt" />
                    &nbsp;<asp:Button ID="btnClear" CssClass="button" runat="server" Text="Clear" OnClick="btnClear_Click" ValidationGroup="DeleteUser"  Font-Size="15pt" />
                    <br />
                    <br />
                    <asp:Label ID="lblEmp" runat="server" Font-Size="X-Large"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnDelete" CssClass="button" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick = "Confirm()" ValidationGroup="DeleteUser" Enabled="False" Font-Size="15pt"></asp:Button>
                </div>
        </center>
      
</asp:Content>



