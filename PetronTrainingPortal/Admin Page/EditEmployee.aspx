<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="EditEmployee.aspx.cs" Inherits="Admin_Page_EditEmployee" %>

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

        .button2 {
            border-style: none;
        border-color: inherit;
        border-width: medium;
        background-color: #0054a6;
            color: white;
            padding: 14px 20px;
            margin: 8px;
            cursor: pointer;
            }

        select.custom-dropdown {
            -webkit-appearance: none; /*REMOVES DEFAULT CHROME & SAFARI STYLE*/
            -moz-appearance: none; /*REMOVES DEFAULT FIREFOX STYLE*/
            border: 0 !important; /*REMOVES BORDER*/
            color: #fff;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            font-size: 14px;
            padding: 10px;
            width: 35%;
            cursor: pointer;
            background: #0060ff url(drop-down-arrow.png) no-repeat right center;
            background-size: 40px 37px; /*TO ACCOUNT FOR @2X IMAGE FOR RETINA*/
        }

        .container {
            padding: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <h2>EDIT EMPLOYEE</h2>
        <div class="container">
            <asp:Label ID="Label1" runat="server" Width="200px" Text="Employee Number:" Font-Size="X-Large"></asp:Label>
            &nbsp;<asp:TextBox CssClass="text" ID="txtBoxEmployeeNumber" runat="server" Font-Size="14pt" Width="210px"></asp:TextBox>
            <asp:Label ID="lblEmpNoMsg" runat="server" ForeColor="Red" ></asp:Label>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBoxEmployeeNumber" ErrorMessage="*" ForeColor="Red" ValidationGroup="EditEmployee"></asp:RequiredFieldValidator>
            &nbsp;<asp:Label ID="ErrorEmpNo" runat="server" ForeColor="Red" Text=""></asp:Label>
            <br />
            &nbsp;<asp:Button ID="btnSearch" CssClass="button" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="EditEmployee" Font-Size="15pt" />
            &nbsp;<asp:Button ID="btnClear" CssClass="button" runat="server" Text="Clear" OnClick="btnClear_Click" ValidationGroup="EditEmployee" Font-Size="15pt" />
            <br />
            <asp:Label ID="Label4" runat="server" Width="150px" Text="Full Name:" Font-Size="X-Large"></asp:Label>
            <asp:TextBox CssClass="text" ID="txtFullName" runat="server" Font-Size="14pt" Width="460px"></asp:TextBox>
               <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Department:" Font-Size="X-Large" Width="180px"></asp:Label>
            <asp:DropDownList ID="cmbDepartment" CssClass="custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged" runat="server"></asp:DropDownList>
              <asp:Label ID="lblDepartmentMsg" runat="server" ForeColor="Red" ></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Section:" Font-Size="X-Large" Width="155px"></asp:Label>
            <asp:DropDownList ID="cmbSection" CssClass="custom-dropdown" runat="server"></asp:DropDownList>
            <asp:Label ID="lblSectionMsg" runat="server" ForeColor="Red" ></asp:Label>
            <br />
            <asp:Button ID="btnSave"  CssClass="button2" runat="server" Text="Update Employee" OnClick="btnSave_Click" ValidationGroup="EditEmployee" Font-Size="15pt" Width="208px"></asp:Button>
        </div>
    </center>
</asp:Content>

