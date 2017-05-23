<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="AddDepartment.aspx.cs" Inherits="Home_Administrator_AddDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Administrator.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main_container_dept_home ">
        <div class="main_box_dept">
            <center><asp:Label ID="lblTitle" runat="server" Text="DEPARTMENT" ForeColor="White" Font-Size="16" Font-Bold="True"></asp:Label></center>
            <div class="content_dept">
                <div class="left1_content_dept_home ">
                    <br />
                    <br />
                    <center>
                    <asp:Label ID="Label6" runat="server" Text="Department Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:DropDownList ID="cmbDepartment" CssClass="custom-dropdown" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Search"></asp:Button>
                    &nbsp;
                    <%--<asp:Button CssClass="button_enter" ID="btnClear1" runat="server" Text="Clear" ValidationGroup="employee" OnClick="btnClear1_Click"></asp:Button>--%>
                    </center>
                </div>
                <div class="right1_content_dept_home">
                    <center>
                    <asp:GridView ID="gridDept" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
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
                         <asp:Label ID="lblHidden" runat="server" Visible="false" ForeColor="White" Font-Bold="True"></asp:Label>
                        <br />   
                        <asp:Label ID="Label1" runat="server" Text="Department Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtBoxDepartment" CssClass="text" runat="server" ValidationGroup="dept" Width="350px"></asp:TextBox>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <center>
        <asp:Button ID="btnClear" CssClass="buttonGrid" runat="server" Text="Clear" ValidationGroup="dept" Font-Size="10pt" Width="116px"></asp:Button>
        &nbsp;
        <asp:Button ID="btnSave" CssClass="buttonGrid" runat="server" Text="Save" ValidationGroup="dept" Font-Size="10pt" Width="116px"></asp:Button>
    </center>
</asp:Content>

