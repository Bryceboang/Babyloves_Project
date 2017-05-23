<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="AdminConfirmation.aspx.cs" Inherits="Home_Administrator_AdminConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Administrator.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><a><asp:Label ID="Label1" runat="server" Text="ADMIN REGISTRATION" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label></a></center>
    <br />
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left_content_train_admin">
                    <center>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Training Program:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                        <%-- eg. Onsite/InHouse --%>
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Training Title:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Enter" ValidationGroup="trngadmin"></asp:Button>
                    </center>
                </div>
                <div class="right_content_train_admin">
                    <br />
                    <asp:Label ID="lblHeader" runat="server" Text="Label" Font-Size="Large" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Training Venue: " Font-Names="Corbel"></asp:Label>
                    <asp:Label ID="lblTrainingVenue" runat="server" Text="Executive Lounge, PBR Housing Compound" Font-Names="Corbel"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Facilitator: " Font-Names="Corbel"></asp:Label>
                    <asp:Label ID="lblFacilitator" runat="server" Text="Mr. Texas Joe (We Do Limited Corp.)" Font-Names="Corbel"></asp:Label>
                    <br />
                    <asp:LinkButton ID="lnkAboutTrainier" runat="server" Font-Names="Corbel">About Trainer</asp:LinkButton>
                    |
              <asp:LinkButton ID="lnkCourseOutline" runat="server" Font-Names="Corbel">Course Outline</asp:LinkButton>
                    |
              <asp:LinkButton ID="lnkBackground" runat="server" Font-Names="Corbel">Background</asp:LinkButton>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Target Participants: " Font-Names="Corbel"></asp:Label>
                    <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers" Font-Names="Corbel"></asp:Label>
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
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbDepartment" runat="server" AutoPostBack="True"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Section:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cmbSection" CssClass="custom-dropdown" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Status:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbStatus" runat="server" AutoPostBack="True">
                        <asp:ListItem>OnWaitingList</asp:ListItem>
                        <asp:ListItem>Registered</asp:ListItem>
                        <asp:ListItem>Declined</asp:ListItem>
                        <asp:ListItem>For registration</asp:ListItem>
                    </asp:DropDownList>
                    </center>
                </div>
                <div class="right_content_train2_admin">
                    <center>
                    <div style="height: 265px; overflow: auto;">
                    <asp:GridView ID="gridView" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="false" EmptyDataText="No data uploaded" Font-Size="8pt">
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

