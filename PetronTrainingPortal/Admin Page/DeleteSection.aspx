﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="DeleteSection.aspx.cs" Inherits="Admin_Page_DeleteSection" %>

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
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #0054a6;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            cursor: pointer;
        }*/

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
            background-size: 40px 37px; /*TO ACCOUNT FOR @2X IMAGE FOR RETINA */
        }

        .container {
            padding: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <center>
        <h2>DELETE SECTION</h2>
        <div class="container">
            <asp:Label ID="Label2" runat="server" Text="Department:" Font-Size="X-Large" Width="195px"></asp:Label>
            <asp:DropDownList ID="cmbDepartment" CssClass="custom-dropdown" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
            <asp:Label ID="lblDepartmentMsg" runat="server" ForeColor="Red" ></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Section:" Font-Size="X-Large" Width="170px"></asp:Label>
            <asp:DropDownList ID="cmbSection" CssClass="custom-dropdown" runat="server"></asp:DropDownList>
               <asp:Label ID="lblSectionMsg" runat="server" ForeColor="Red" ></asp:Label>
            <br />
            <br />
            <asp:Button CssClass="button" ID="btnSave" runat="server" Text="Delete Section" OnClick="btnSave_Click"  Font-Size="15pt" Width="210px"></asp:Button>
        </div>
    </center>
</asp:Content>

