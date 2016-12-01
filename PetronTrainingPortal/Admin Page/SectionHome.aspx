<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="SectionHome.aspx.cs" Inherits="Admin_Page_SectionHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main_container_dept_home ">
        <div class="main_box_dept">
            <div class="content_dept">
                <div class="left1_content_sec_home ">
                    <br />
                    <center>
                    <asp:Label ID="Label6" runat="server" Text="Department Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cmbDepartment" CssClass="custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Section Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cmbSection" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"></asp:Button>
                    </center>
                </div>
                <div class="right1_content_sec_home">
                    <center>
                    <asp:GridView ID="gridSec" OnRowCommand="gridSec_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns> 
                            <asp:BoundField DataField="SectionId" Visible="false" HeaderText="Section Id" />
                            <asp:BoundField DataField="SectionName" HeaderText="Section Name" />
                            <asp:ButtonField  CommandName="EditSection"   ImageUrl="~/Image/edit.png" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                            <asp:ButtonField  CommandName="RemoveSection"   ImageUrl="~/Image/remove.jpg" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
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
                <div class="left2_content_sec_home ">
                    <center>
                    <br />
                    <asp:Label ID="lblHidden" runat="server" Visible="false" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />   
                    <asp:Label ID="Label3" runat="server" Text="Department Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cmbSelectDepartment" CssClass="custom-dropdown" AutoPostBack="true" Width="350px" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Section Name:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtBoxSection" CssClass="text" runat="server" ValidationGroup="sec" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtBoxSection" ForeColor="Red" ValidationGroup="sec"></asp:RequiredFieldValidator>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <center>
        <asp:Button ID="btnClear" OnClick="btnClear_Click" CssClass="buttonGrid" runat="server" Text="Clear" ValidationGroup="sec" Enabled="False" Font-Size="10pt" Width="116px"></asp:Button>
        &nbsp;
        <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="buttonGrid" runat="server" Text="Save" ValidationGroup="sec" Font-Size="10pt" Width="116px"></asp:Button>
    </center>
</asp:Content>

