<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="AdminReport.aspx.cs" Inherits="Admin_Page_AdminReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center><a><asp:Label ID="Label1" runat="server" Text="ADMIN REGISTRATION" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label></a></center>
    <br />
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left_content_train_admin">
                    <center>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Training Code:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="txtTrainingCode" runat="server" ValidationGroup="trngadmin"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtTrainingCode" ForeColor="Red" ValidationGroup="trngadmin"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblEmpNoMsg" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Enter" ValidationGroup="trngadmin"></asp:Button>
                    </center>
                </div>
                <div class="right_content_train_admin">
                    <asp:Label ID="Label8" runat="server" Text="Training Details" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <center><asp:Label ID="lblTrainingTitle" runat="server" ForeColor="White" Font-Bold="True" Font-Size="15"></asp:Label>
                    <asp:GridView ID="gridTraining" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" Height="91px">
                        <Columns>
                            <asp:BoundField DataField="TrainingVenue" HeaderText="Training Venue" />
                            <asp:BoundField DataField="DateDuration" HeaderText="Date Duration" />
                            <asp:BoundField DataField="TimeDuration" HeaderText="Time Duration" />
                            <asp:BoundField DataField="TrainingProvider" HeaderText="Training Provider" />
                            <asp:BoundField DataField="TargetParticipants" HeaderText="Target Participants" />
                        </Columns>
                    </asp:GridView>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left_content_train2_admin">
                    <center>
                    <br />
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Department:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbDepartment" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Section:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cmbSection" CssClass="custom-dropdown" OnSelectedIndexChanged="cmbSection_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Status:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbStatus" OnSelectedIndexChanged="cmbStatus_SelectedIndexChanged" runat="server" AutoPostBack="True">
                        <asp:ListItem>PENDING</asp:ListItem>
                        <asp:ListItem>APPROVED</asp:ListItem>
                        <asp:ListItem>NO STATUS</asp:ListItem>
                    </asp:DropDownList>
                    </center>
                </div>
                <div class="right_content_train2_admin">
                    <center>
                    <div style="height: 265px; overflow: auto;">
                    <asp:GridView ID="gridView" CssClass="mydatagrid" OnRowCommand="gridView_RowCommand" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="false" EmptyDataText="No data uploaded" Font-Size="8pt">
                        <Columns>
                            <asp:BoundField  ItemStyle-HorizontalAlign="Center" DataField="SectionName" HeaderText="SECTION NAME"  />
                            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="EmployeeNumber" HeaderText="EMPLOYEE NUMBER" />
                            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="FullName" HeaderText="FULLNAME" />
                              <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="ServiceYears" HeaderText="SERVICE YEARS" />
                            <asp:ButtonField  CommandName="Nominate" ImageUrl="~/Image/Button-Add-icon.png" Text=""     ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                            <asp:ButtonField  CommandName="Reject"  ImageUrl="~/Image/Button-Delete-icon.png" Text=""  ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image" />
                            <asp:ButtonField  CommandName="Remove"   ImageUrl="~/Image/remove.jpg" Text=""              ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                               </Columns>
                    </asp:GridView>
                    </div>
                    </center>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

