<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="DepartmentHome.aspx.cs" Inherits="Admin_Page_DepartmentHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main_container_dept_home ">
        <div class="main_box_dept">
            <div class="content_dept">
                <div class="left1_content_dept_home ">
                    <br />
                    <br />
                    <center>
                    <asp:Label ID="Label6" runat="server" Text="Department Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:DropDownList ID="cmbDepartment" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="training"></asp:Button>
                    </center>
                </div>
                <div class="right1_content_dept_home">
                    <center>
                    <asp:GridView ID="gridDept" OnRowCommand="gridDept_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="DepartmentId" Visible="false" HeaderText="DepartmentId" />
                            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                            <asp:ButtonField  CommandName="EditDepartment"   ImageUrl="~/Image/edit.png" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                            <asp:ButtonField  CommandName="RemoveDepartment"   ImageUrl="~/Image/remove.jpg" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                        </Columns>
                    </asp:GridView>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <div class="main_container_dept_home ">
        <div class="main_box_dept">
            <div class="content_dept">
                <div class="left2_content_dept_home ">
                    <center>
                        <br />   
                         <asp:Label ID="lblHidden" runat="server" Visible="false" ForeColor="White" Font-Bold="True" Font-Size="15pt"></asp:Label>
                        <br />   
                        <asp:Label ID="Label1" runat="server" Text="Department Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtBoxDepartment" CssClass="text" runat="server" ValidationGroup="dept" Width="350px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtBoxDepartment" ForeColor="Red" ValidationGroup="dept"></asp:RequiredFieldValidator>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <center>
        <asp:Button ID="btnClear" OnClick="btnClear_Click"  CssClass="buttonGrid" runat="server" Text="Clear" ValidationGroup="dept" Enabled="False" Font-Size="10pt" Width="116px"></asp:Button>
        &nbsp;
        <asp:Button ID="btnSave" OnClick="btnSave_Click"  CssClass="buttonGrid" runat="server" Text="Save" ValidationGroup="dept" Enabled="False" Font-Size="10pt" Width="116px"></asp:Button>
    </center>
</asp:Content>

