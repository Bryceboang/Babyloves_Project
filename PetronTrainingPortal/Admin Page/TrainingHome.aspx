<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="TrainingHome.aspx.cs" Inherits="Admin_Page_TrainingHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main_container_train_home ">
        <div class="main_box_train">
            <center><asp:Label ID="lblTitle" runat="server" Text="TRAINING" ForeColor="White" Font-Size="16" Font-Bold="True"></asp:Label></center>
            <div class="content_train">
                <div class="left1_content_train_home ">
                    <center>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Training Code" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="txtTrainingCode" runat="server" ValidationGroup="training" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtTrainingCode" ForeColor="Red" ValidationGroup="training"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblEmpNoMsg" runat="server" ForeColor="Red" Text=""></asp:Label>
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="training"></asp:Button>
                    &nbsp;
                    <asp:Button CssClass="button_enter" ID="btnClear1" runat="server" Text="Clear" ValidationGroup="employee" OnClick="btnClear1_Click"></asp:Button>
                    </center>
                </div>
                <div class="right1_content_train_home ">
                    <asp:Label ID="Label8" runat="server" Text="Training Details" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <center><asp:Label ID="lblTrainingTitle" runat="server" ForeColor="White" Font-Bold="True" Font-Size="15pt"></asp:Label>
                    <asp:GridView ID="gridTraining" OnRowCommand="gridTraining_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="TrainingVenue" HeaderText="Training Venue" />
                            <asp:BoundField DataField="DateDuration" HeaderText="Date Duration" />
                            <asp:BoundField DataField="TimeDuration" HeaderText="Time Duration" />
                            <asp:BoundField DataField="TrainingProvider" HeaderText="Training Provider" />
                            <asp:BoundField DataField="TargetParticipants" HeaderText="Target Participants" />
                            <asp:ButtonField CommandName="EditTraining" ImageUrl="~/Image/edit.png" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                            <asp:ButtonField CommandName="DeleteTraining" ImageUrl="~/Image/remove.jpg" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                        </Columns>
                    </asp:GridView>
                    </center>
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
                    <br />
                    <center>
                    <asp:Label ID="lblHiddenTrainingCode" runat="server" Visible="false" ForeColor="White" Font-Bold="True" Font-Size="15pt"></asp:Label>
                      <br />
                        <asp:Label ID="Label2" runat="server" Text="Training Code:" ForeColor="White" Font-Bold="True"></asp:Label>
                    &nbsp;<br />
                        <asp:TextBox ID="txtCode" CssClass="text" runat="server" ValidationGroup="EditTraining" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtCode" ForeColor="Red" ValidationGroup="AddTraining"></asp:RequiredFieldValidator>
                    <br />
                    <center><asp:Label ID="lblCodeMsg" runat="server" ForeColor="Red" ></asp:Label></center>
                    <br />
                    <asp:Label ID="lbl3" runat="server" Text="Training Title:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:TextBox CssClass="text" ID="txtTitle" runat="server"  ValidationGroup="EditTraining" Width="200px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtTitle" ForeColor="Red" ValidationGroup="AddTraining"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblTitleMsg" runat="server" ForeColor="Red" ></asp:Label></center>
                </div>
                <div class="right2_content_train_home">
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Training Venue:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtVenue" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="Date Duration:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtDateDuration" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="Time Duration:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtTimeDuration" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Training Provider:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtProvider" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Target Participants:" ForeColor="White" Font-Bold="True" Width="150px"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtParticipants" runat="server" ValidationGroup="AddTraining" TextMode="MultiLine" Width="350px"></asp:TextBox>
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
    <div class="main_container_train_home ">
        <div class="main_box_train">
            <div class="content_train">
                <div class="right3_content_train_home">
                    <%-- <asp:GridView ID="gridTrainingCapacity" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" Width="954px">
                        <Columns>
                            <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" ItemStyle-Width="30" />
                            <asp:TemplateField HeaderText="TID" SortExpression="Timeline">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCapacity" runat="server" Text='<%#Eval("Capacity") %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>

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
    </div>
    <center><asp:Button CssClass="buttonGrid" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" ValidationGroup="AddTraining" Width="116px"></asp:Button>
    &nbsp;<asp:Button CssClass="buttonGrid" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="AddTraining" Width="116"></asp:Button></center>
    &nbsp;<asp:Button CssClass="buttonGrid" ID="Button1" runat="server" Text="Save" OnClick="btnSave_Click" Width="116"></asp:Button></center>
</asp:Content>

