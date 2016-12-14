<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="Admin_Page_UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main_container_user_home ">
        <div class="main_box_user">
            <center><asp:Label ID="lblTitle" runat="server" Text="USER" ForeColor="White" Font-Size="16" Font-Bold="True"></asp:Label></center>
            <div class="content_user">
                <div class="left1_content_user_home ">
                    <br />
                    <br />
                    <center>
                    <asp:Label ID="lblEmpNum" runat="server" Text="Employee Number" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="txtBoxEmployeeNumberSearch" runat="server" ValidationGroup="user" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtBoxEmployeeNumberSearch" ForeColor="Red" ValidationGroup="user"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="ErrorEmpNo" runat="server" ForeColor="Red" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Enter" ValidationGroup="user" OnClick="btnSearch_Click"></asp:Button>
                    </center>
                </div>
                <div class="right1_content_user_home ">
                    <center>
                    <asp:GridView ID="gridEmployee" OnRowCommand="gridEmployee_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns>
                             <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="AccessType" HeaderText="Access Type" />
                            <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                            <asp:BoundField DataField="SectionName" HeaderText="Section" />
                            <asp:ButtonField  CommandName="EditEmployee"   ImageUrl="~/Image/edit.png" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                            <asp:ButtonField  CommandName="RemoveUser"   ImageUrl="~/Image/remove.jpg" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                        </Columns>
                    </asp:GridView>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="main_container_user_home ">
        <div class="main_box_user">
            <div class="content_user">
                <div class="left2_content_user_home ">
                    <center>
                    <asp:Label ID="lblhidden" runat="server" Visible="false" ForeColor="White" Font-Bold="True"></asp:Label>
             <br />
                    <asp:Label ID="Label2" runat="server" Text="Employee Number:" ForeColor="White" Font-Bold="True" Width="150"></asp:Label>
                    <asp:TextBox ID="txtBoxEmployeeNumber" CssClass="text" runat="server" ValidationGroup="useradd" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtBoxEmployeeNumber" ForeColor="Red" ValidationGroup="useradd"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Full Name:" ForeColor="White" Font-Bold="True" Width="150"></asp:Label>
                    <asp:TextBox ID="txtFullName" CssClass="text" runat="server" ValidationGroup="useradd" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtFullName" ForeColor="Red" ValidationGroup="useradd"></asp:RequiredFieldValidator>
                    <center><asp:Label ID="lblFullNameMsg" runat="server" ForeColor="Red" ></asp:Label></center>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Email:" ForeColor="White" Font-Bold="True" Width="150"></asp:Label>
                    <asp:TextBox ID="txtEmail" CssClass="text" runat="server" ValidationGroup="useradd" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="useradd"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Password:" ForeColor="White" Font-Bold="True" Width="150"></asp:Label>
                    <asp:TextBox ID="txtPassword" CssClass="text" runat="server" ValidationGroup="useradd" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="useradd"></asp:RequiredFieldValidator>
                    <center><asp:Label ID="lblPasswordMsg" runat="server" ForeColor="Red" ></asp:Label></center></center>
                </div>
                <div class="right2_content_user_home">
                    <center>
                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Access Type:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:DropDownList ID="cmbAccessType" CssClass="custom-dropdown" OnSelectedIndexChanged="cmbBoxAccessType_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    <asp:ListItem>Supervisor</asp:ListItem>
                    <asp:ListItem>Manager</asp:ListItem>
                    <asp:ListItem>Admin</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="labelDept" runat="server" Text="Department:" ForeColor="White" Font-Bold="True" Width="120"></asp:Label>
                    <asp:DropDownList ID="cmbDepartment" CssClass="custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Label ID="lblDepartmentMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="labelSection" runat="server" Text="Section:" ForeColor="White" Font-Bold="True" Width="120"></asp:Label>
                    <asp:DropDownList ID="cmbSection" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Label ID="lblSectionMsg" runat="server" ForeColor="Red" ></asp:Label>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <center>
        <asp:Button ID="btnClear" OnClick="btnClear_Click"  CssClass="buttonGrid" runat="server" Text="Clear" Font-Size="10pt" Width="116px"></asp:Button>
        &nbsp;
        <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="buttonGrid" runat="server" Text="Save" ValidationGroup="useradd" Font-Size="10pt" Width="116px"></asp:Button>
        &nbsp;
        <asp:Button ID="btnReset" OnClick="btnReset_Click" CssClass="buttonGrid" runat="server" Text="Reset Password" Enabled="False" Font-Size="10pt" Width="195px" />
    </center>
</asp:Content>

