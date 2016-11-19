<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="SectionHome.aspx.cs" Inherits="Admin_Page_SectionHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main_container_dept_home ">
        <div class="main_box_dept">
            <div class="content_dept">
                <div class="left1_content_dept_home ">
                    <br />
                    <center>
                    <asp:Label ID="Label6" runat="server" Text="Department Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cmbDept" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Section Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cmbSec" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    </center>
                </div>
                <div class="right1_content_dept_home">
                    <center>
                    <asp:GridView ID="gridSec" OnRowCommand="gridSec_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="Section" HeaderText="Section Name" />
                            <asp:ButtonField  CommandName="Edit"   ImageUrl="~/Image/edit.png" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                            <asp:ButtonField  CommandName="Remove"   ImageUrl="~/Image/remove.jpg" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
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
                        <asp:Label ID="Label2" runat="server" Text="Section Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtBoxSection" CssClass="text" runat="server" ValidationGroup="dept" Width="350px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtBoxSection" ForeColor="Red" ValidationGroup="sec"></asp:RequiredFieldValidator>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <center>
        <asp:Button ID="btnClear"  CssClass="buttonGrid" runat="server" Text="Clear" ValidationGroup="sec" Enabled="False" Font-Size="10pt" Width="116px"></asp:Button>
        &nbsp;
        <asp:Button ID="btnSave"  CssClass="buttonGrid" runat="server" Text="Save" ValidationGroup="sec" Enabled="False" Font-Size="10pt" Width="116px"></asp:Button>
    </center>
</asp:Content>

