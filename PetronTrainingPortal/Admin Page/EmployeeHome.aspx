<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="EmployeeHome.aspx.cs" Inherits="Admin_Page_EmployeeHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main_container_emp_home ">
        <div class="main_box_emp">
            <div class="content_emp">
                <div class="left1_content_emp_home ">
                    <br />
                    <center>
                    <asp:Label ID="lblEmpNum" runat="server" Text="Employee Number" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="txtBoxEmployeeNumber" runat="server" ValidationGroup="employee"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtBoxEmployeeNumber" ForeColor="Red" ValidationGroup="employee"></asp:RequiredFieldValidator>
                    <br />
            <asp:Label ID="lblEmpNoMsg" runat="server" ForeColor="Red" ></asp:Label>
                        <br />
                    <asp:Label ID="ErrorEmpNo" runat="server" ForeColor="Red" Text=""></asp:Label>
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Enter" ValidationGroup="employee"></asp:Button>
                    </center>
                </div>
                <div class="right1_content_emp_home ">
                    <center>
                    <asp:GridView ID="gridEmployee" OnRowCommand="gridEmployee_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                            <asp:BoundField DataField="Section" HeaderText="Section" />
                            <asp:ButtonField  CommandName="Edit"   ImageUrl="~/Image/edit.png" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                            <asp:ButtonField  CommandName="Remove"   ImageUrl="~/Image/remove.jpg" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                        </Columns>
                    </asp:GridView>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <div class="main_container_emp_home ">
        <div class="main_box_emp">
            <div class="content_emp">
                <div class="left2_content_emp_home ">
                    <br />
                    <center>
                    <asp:Label ID="Label2" runat="server" Text="Employee Number:" ForeColor="White" Font-Bold="True" Width="150"></asp:Label>
                    <asp:TextBox ID="txtBoxEmployeeNumber1" CssClass="text" runat="server" ValidationGroup="user"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtBoxEmployeeNumber1" ForeColor="Red" ValidationGroup="user"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Full Name:" ForeColor="White" Font-Bold="True" Width="150"></asp:Label>
                    <asp:TextBox ID="txtFullName" CssClass="text" runat="server" ValidationGroup="user"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtFullName" ForeColor="Red" ValidationGroup="user"></asp:RequiredFieldValidator>
                    </center>
                </div>
                <div class="right2_content_emp_home">
                    <br />
                    <center>
                    <asp:Label ID="Label6" runat="server" Text="Department:" ForeColor="White" Font-Bold="True" Width="100"></asp:Label>
                    <asp:DropDownList ID="cmbDept" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Label ID="lblDepartmentMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Section:" ForeColor="White" Font-Bold="True" Width="100"></asp:Label>
                    <asp:DropDownList ID="cmbSec" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Label ID="lblSectionMsg" runat="server" ForeColor="Red" ></asp:Label>
                    </center>
                </div>
            </div>
        </div>
    </div>
        <center>
        <asp:Button ID="btnClear"  CssClass="buttonGrid" runat="server" Text="Clear" ValidationGroup="EditUser" Enabled="False" Font-Size="10pt" Width="116px"></asp:Button>
        &nbsp;
        <asp:Button ID="btnSave"  CssClass="buttonGrid" runat="server" Text="Save" ValidationGroup="EditUser" Enabled="False" Font-Size="10pt" Width="116px"></asp:Button>
        </center>
</asp:Content>

