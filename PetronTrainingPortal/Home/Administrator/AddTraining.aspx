<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="AddTraining.aspx.cs" Inherits="Home_Administrator_AddTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Administrator.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main_container_train_home ">
        <div class="main_box_train">
            <center><asp:Label ID="lblTitle" runat="server" Text="TRAINING" ForeColor="White" Font-Size="16" Font-Bold="True"></asp:Label></center>
            <div class="content_train">
                <div class="left1_content_train_home ">
                    <center>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Training Program" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Training Title" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Search" ValidationGroup="training"></asp:Button>
                    &nbsp;
                    <asp:Button CssClass="button_enter" ID="btnClear1" runat="server" Text="Clear" ValidationGroup="employee" ></asp:Button>
                    </center>
                </div>
                <div class="right1_content_train_home ">
                    <br />
                    <asp:Label ID="lblHeader" runat="server" Text="Label" Font-Size="Large" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Training Venue: " Font-Names="Corbel"></asp:Label>
                    <asp:Label ID="lblTrainingVenue" runat="server" Text="Executive Lounge, PBR Housing Compound" Font-Names="Corbel"></asp:Label>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Facilitator: " Font-Names="Corbel"></asp:Label>
                    <asp:Label ID="lblFacilitator" runat="server" Text="Mr. Texas Joe (We Do Limited Corp.)" Font-Names="Corbel"></asp:Label>
                    <br />
                    <asp:LinkButton ID="lnkAboutTrainier" runat="server" Font-Names="Corbel" >About Trainer</asp:LinkButton>
                    |
              <asp:LinkButton ID="lnkCourseOutline" runat="server" Font-Names="Corbel" >Course Outline</asp:LinkButton>
                    |
              <asp:LinkButton ID="lnkBackground" runat="server" Font-Names="Corbel" >Background</asp:LinkButton>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Target Participants: " Font-Names="Corbel"></asp:Label>
                    <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers" Font-Names="Corbel"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Edit" />
                    <asp:Button ID="Button3" runat="server" Text="Delete" />
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="main_container_train_home ">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left2_content_train_home ">
                    <br />
                    <br />
                    <center>
                    <asp:Label ID="lblHiddenTrainingCode" runat="server" Visible="false" ForeColor="White" Font-Bold="True" Font-Size="15pt"></asp:Label>
                      <br />
                        <asp:Label ID="Label2" runat="server" Text="Training Program:" ForeColor="White" Font-Bold="True"></asp:Label>
                    &nbsp;<br />
                        <asp:DropDownList ID="DropDownList3" runat="server">
                        </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="lbl3" runat="server" Text="Training Title:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                        <asp:DropDownList ID="DropDownList4" runat="server">
                        </asp:DropDownList>
                    <br />
                    </center>
                </div>
                <div class="right2_content_train_home">
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Course Outline:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtVenue" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="Background:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtDateDuration" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="Starting Date:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtTimeDuration" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="End Date:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtProvider" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Venue:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtParticipants" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Facilitator:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtObjectives" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="About Trainer:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtOutline" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Target Participants:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="TextBox1" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                </div>
            </div>
        </div>
    </div>
    <%--<div class="main_container_train_home ">
        <div class="main_box_train">
            <div class="content_train">
                <div class="right3_content_train_home">
                     <asp:GridView ID="gridTrainingCapacity" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" Width="954px">
                        <Columns>
                            <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" ItemStyle-Width="30" />
                            <asp:TemplateField HeaderText="TID" SortExpression="Timeline">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCapacity" runat="server" Text='<%#Eval("Capacity") %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gridTrainingCapacity" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" Width="954px">
                        <Columns>
                            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                            <asp:TemplateField HeaderText="Capacity">
                                <ItemTemplate>
                                    <asp:Label ID="lbl1" runat="server"
                                        Value='<%# Eval("Name") %>' />
                                    <asp:HiddenField ID="HiddenField1" runat="server"
                                        Value='<%# Eval("BirthDate") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                </div>
            </div>
        </div>
    </div>--%>
    <center><asp:Button CssClass="buttonGrid" ID="btnClear" runat="server" Text="Clear" ValidationGroup="AddTraining" Width="116px"></asp:Button>
    &nbsp;<asp:Button CssClass="buttonGrid" ID="btnSave" runat="server" Text="Save" ValidationGroup="AddTraining" Width="116"></asp:Button></center>
    </center>
</asp:Content>

