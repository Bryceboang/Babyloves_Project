<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="TrainingCompleted.aspx.cs" Inherits="Admin_Page_TrainingCompleted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center><a><asp:Label ID="Label2" runat="server" Text="TRAINING STATUS" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label></a></center>
    <br />
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left_content_train_admin">
                    <center>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Training Code:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbTrainingCode" OnSelectedIndexChanged="cmbTraining_SelectedIndexChanged"  runat="server" AutoPostBack="True"></asp:DropDownList>
                        <br />
                    <asp:Label ID="lblcmbCodeMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Enter" OnClick="btnSearch_Click" ValidationGroup="trngadmin"></asp:Button>
                    </center>
                </div>
                <div class="right_content_train_admin">
                    <asp:Label ID="Label12" runat="server" Text="Training Details" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <center><asp:Label ID="lblTrainingTitle" runat="server" ForeColor="White" Font-Bold="True" Font-Size="15"></asp:Label>
                    <asp:GridView ID="gridTraining" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="TrainingVenue" HeaderText="Training Venue" />
                            <asp:BoundField DataField="DateDuration" HeaderText="Date Duration" />
                            <asp:BoundField DataField="TimeDuration" HeaderText="Time Duration" />
                            <asp:BoundField DataField="TrainingProvider" HeaderText="Training Provider" />
                            <asp:BoundField DataField="TargetParticipants" HeaderText="Target Participants" />
                        </Columns>
                    </asp:GridView>
                    </center>
                    <br />
                    <center>
                    <asp:GridView ID="gridEmp" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
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
                    </asp:GridView>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <center><asp:Button CssClass="button" ID="btnSave" runat="server" Text="Training Completed" OnClick="btnSave_Click" ValidationGroup="EditTraining" Font-Size="15pt" Width="220px"></asp:Button></center>
    <%--<center>
            <h2>Training Completed</h2>
                <div class="container">
                    <asp:Label ID="Label1" runat="server" Text="Training Code:" Width="200px" Font-Size="X-Large"></asp:Label>
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbTrainingCode" OnSelectedIndexChanged="cmbTraining_SelectedIndexChanged"  runat="server" Font-Size="20pt" AutoPostBack="True"></asp:DropDownList>
                      <asp:Label ID="lblcmbCodeMsg" runat="server" ForeColor="Red" ></asp:Label>
                     <br />
                    <asp:Label ID="Label4" runat="server" Text="Training Code:" Width="200px" Font-Size="X-Large"></asp:Label>
                    &nbsp;
                    <asp:TextBox CssClass="text" ID="txtCode" runat="server" Enabled="false"  Font-Size="14pt"></asp:TextBox>
                     <br />
                    <asp:Label ID="Label5" runat="server" Text="Training Title:" Width="200px" Font-Size="X-Large"></asp:Label>
                    &nbsp;
                    <asp:TextBox CssClass="text" ID="txtTitle" runat="server" Enabled="false"   Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="DESCRIPTION:" Width="500px" Font-Size="X-Large" Height="31px"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="•Training Venue:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtVenue" runat="server" Enabled="false"   Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="•Date Duration:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtDateDuration" Enabled="false" runat="server"   Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="•Time Duration:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtTimeDuration" Enabled="false" runat="server"  Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="•Training Provider:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtProvider" Enabled="false" runat="server" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="•Target Participants:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtParticipants" Enabled="false" runat="server"   Font-Size="14pt"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button CssClass="button" ID="btnSave" runat="server" Text="Training Completed" OnClick="btnSave_Click" ValidationGroup="EditTraining" Font-Size="15pt" Width="220px"></asp:Button>
                </div>
        </center>--%>
</asp:Content>

