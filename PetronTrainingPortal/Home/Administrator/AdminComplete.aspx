<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="AdminComplete.aspx.cs" Inherits="Home_Administrator_AdminComplete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Administrator.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><a><asp:Label ID="Label2" runat="server" Text="TRAINING STATUS" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label></a></center>
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
                    <asp:LinkButton ID="lnkAboutTrainier" runat="server" Font-Names="Corbel" >About Trainer</asp:LinkButton>
                    |
              <asp:LinkButton ID="lnkCourseOutline" runat="server" Font-Names="Corbel" >Course Outline</asp:LinkButton>
                    |
              <asp:LinkButton ID="lnkBackground" runat="server" Font-Names="Corbel" >Background</asp:LinkButton>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Target Participants: " Font-Names="Corbel"></asp:Label>
                    <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers" Font-Names="Corbel"></asp:Label>
                    </center>
                    <br />
                    <center>
                    <%--<asp:GridView ID="gridEmp" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country" ItemStyle-Width="150">
                               <ItemTemplate>
                                   <asp:TextBox ID="txtComment" runat="server" Text='<%# Eval("Comment") %>'></asp:TextBox>
                               </ItemTemplate>
                           </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <center><asp:Button CssClass="button" ID="btnSave" runat="server" Text="Training Complete" ValidationGroup="EditTraining" Font-Size="15pt" Width="220px"></asp:Button></center>
</asp:Content>

