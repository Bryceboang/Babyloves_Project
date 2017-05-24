<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="Home_Administrator_AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Administrator.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main_container_emp_home ">
        <div class="main_box_emp">
            <center><asp:Label ID="lblTitle" runat="server" Text="EMPLOYEE" ForeColor="White" Font-Size="16" Font-Bold="True"></asp:Label></center>
            <div class="content_emp">
                <div class="left1_content_emp_home ">
                    <br />
                    <br />
                    <center>
                    <asp:Label ID="lblEmpNum" runat="server" Text="Employee Number" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="txtBoxEmployeeNumberSearch" runat="server" ValidationGroup="employee" Width="150"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblEmpNoMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Search" ValidationGroup="employee"></asp:Button>
                    &nbsp;
                    <asp:Button CssClass="button_enter" ID="btnClear1" runat="server" Text="Clear" ValidationGroup="employee"></asp:Button>
                    </center>
                </div>
                <div class="right1_content_emp_home ">
                    <center>
                    <asp:GridView ID="gridEmployee" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                            <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                            <asp:BoundField DataField="SectionName" HeaderText="Section" />
                            <asp:BoundField DataField="DateHired" HeaderText="Date Hired" />
                            <asp:ButtonField  CommandName="EditEmployee"   ImageUrl="~/Image/edit.png" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                            <asp:ButtonField  CommandName="RemoveEmployee"   ImageUrl="~/Image/remove.jpg" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
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
                    <center>
                    <asp:Label ID="lblhidden" runat="server" Visible="false" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Employee Number:" ForeColor="White" Font-Bold="True" Width="150"></asp:Label>
                    <asp:TextBox ID="txtBoxEmployeeNumber" CssClass="text" runat="server" ValidationGroup="addemp" Width="250px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Full Name:" ForeColor="White" Font-Bold="True" Width="150"></asp:Label>
                    <asp:TextBox ID="txtFullName" CssClass="text" runat="server" ValidationGroup="addemp" Width="250px"></asp:TextBox>
                   <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Date Hired:" ForeColor="White" Font-Bold="True" Width="150"></asp:Label>
                        <asp:TextBox ID="txtDateHired" runat="server" TextMode="DateTime"></asp:TextBox>
                           </center>
                </div>
                <div class="right2_content_emp_home">
                    <center>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Department:" ForeColor="White" Font-Bold="True" Width="100"></asp:Label>
                    <asp:DropDownList ID="cmbDepartment" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    &nbsp;<br />
                        <asp:Label ID="lblDepartmentMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Section:" ForeColor="White" Font-Bold="True" Width="100"></asp:Label>
                    <asp:DropDownList ID="cmbSection" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    &nbsp;<br />
                        <asp:Label ID="lblSectionMsg" runat="server" ForeColor="Red" ></asp:Label>
                    </center>
                </div>
            </div>
        </div>
    </div>
        <center>
        <asp:Button ID="btnClear" CssClass="buttonGrid" runat="server" Text="Clear" ValidationGroup="addemp" Enabled="False" Font-Size="10pt" Width="116px"></asp:Button>
        &nbsp;
        <asp:Button ID="btnSave" CssClass="buttonGrid" runat="server" Text="Save" ValidationGroup="addemp" Font-Size="10pt" Width="116px"></asp:Button>
        </center>
</asp:Content>

