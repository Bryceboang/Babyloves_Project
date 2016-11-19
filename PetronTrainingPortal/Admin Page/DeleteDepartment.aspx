<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="DeleteDepartment.aspx.cs" Inherits="Admin_Page_DeleteDepartment" %>

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
           border-style: none;
               border-color: inherit;
               border-width: medium;
               background-color: #0054a6;
               color: white;
               padding: 14px 20px;
               margin: 8px 0;
               cursor: pointer;
  }

.custom-dropdown {
           border-style: none !important;
               border-color: inherit !important;
               border-width: 0 !important;
               -webkit-appearance: none;  /*REMOVES DEFAULT CHROME & SAFARI STYLE*/
               -moz-appearance: none;  /*REMOVES DEFAULT FIREFOX STYLE*/
               appearance: none;
 /*REMOVES BORDER*/

               color: #fff;
               -webkit-border-radius: 5px;
               border-radius: 5px;
               font-size: 14px;
               padding: 10px;
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
            <h2>DELETE DEPARTMENT</h2>
                <div class="container">
                    <asp:Label ID="Label1" runat="server" Text="Department Name:" Width="200px" Font-Size="X-Large"></asp:Label>
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbDepartment" runat="server"  Font-Size="20pt" Width="350px" ValidationGroup="DeleteDept"></asp:DropDownList>
                    <asp:Label ID="lblCmbDeptMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />
                    <br />
                    <asp:Button CssClass="button" ID="btnDelete" runat="server" Text="Delete Department" OnClick="btnDelete_Click" ValidationGroup="DeleteDept" Font-Size="15pt" Width="223px"></asp:Button>
                </div>
        </center>
</asp:Content>

