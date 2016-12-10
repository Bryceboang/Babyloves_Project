<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/MasterPageSupervisor.master" AutoEventWireup="true" CodeFile="TrainingRegister.aspx.cs" Inherits="Supervisor_TrainingRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Supervisor.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main_container_train">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left_content_train">
                    <center>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Training Code" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="txtTrainingCode" runat="server" ValidationGroup="trngvisor"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtTrainingCode" ForeColor="Red" ValidationGroup="trngvisor"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Enter" OnClick="btnSearch_Click" ValidationGroup="trngvisor"></asp:Button>
                    </center>
                </div>
                <div class="right_content_train">
                    <asp:Label ID="Label8" runat="server" Text="Training Details" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <center><asp:Label ID="lblTrainingTitle" runat="server" ForeColor="White" Font-Bold="True" Font-Size="15pt"></asp:Label>
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
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="main_container_train">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left_content_train2">
                    <center>
                    <asp:Label ID="Label13" runat="server" Text="NOMINATE" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Department" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblDepartment" runat="server" Text="" ForeColor="White"></asp:Label>
                    <br />
                    <br />
                    <br />
                        <asp:Label ID="Label10" runat="server" Text="Section" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblSection" runat="server" Text="" ForeColor="White"></asp:Label>
                    </center>
                </div>
                <div class="right_content_train2">
                    <center>
                    <div style="height: 265px; overflow: auto;">
                    <asp:GridView ID="gridEmployee" CssClass="mydatagrid" PagerStyle-CssClass="pager" OnRowCommand="gridEmployee_RowCommand" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="false" EmptyDataText="No data uploaded" Font-Size="8pt">
                        <Columns>
                            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="EmployeeNumber" HeaderText="EMPLOYEE NUMBER" />
                            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="FullName" HeaderText="FULLNAME" />
                            <asp:ButtonField  ItemStyle-HorizontalAlign="Center"  HeaderText="REGISTER" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image" ImageUrl="~/Image/Button-Add-icon.png" Text="NOMINATE" CommandName="NominateEmployee"/>
                        </Columns>
                    </asp:GridView>
                    </div>
                    </center>
                </div>
            </div>
        </div>
    </div>



    <%--<center>
        <h2>TRAINING REGISTRATION</h2>
    </center>
    <div class="container">
        <asp:Label ID="Label1" runat="server" Text="TRAINING CODE:" Width="250px" Font-Size="X-Large"></asp:Label>
        <asp:TextBox ID="txtTrainingCode" runat="server" CssClass="text"></asp:TextBox>
        <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="Search Training" OnClick="btnSearch_Click" Font-Size="15pt" Width="250px"></asp:Button>
        <br />
        <asp:Label ID="Label2" runat="server" Text="TRAINING TITLE:" Width="250px" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="lblTrainingTitle" runat="server" Text="" Font-Size="X-Large" Font-Bold="True"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="DESCRIPTION:" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:GridView ID="gridTraining" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="false" EmptyDataText="No data uploaded" Font-Size="12pt">
            <Columns>
                <asp:BoundField DataField="TrainingVenue" HeaderText="Training Venue" />
                <asp:BoundField DataField="DateDuration" HeaderText="Date Duration" />
                <asp:BoundField DataField="TimeDuration" HeaderText="Time Duration" />
                <asp:BoundField DataField="TrainingProvider" HeaderText="Training Provider" />
                <asp:BoundField DataField="TargetParticipants" HeaderText="Target Participants" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label4" runat="server" Text="DEPARTMENT:" Width="180px" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="lblDepartment" runat="server" Font-Size="X-Large" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="SECTION:" Width="120px" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="lblSection" runat="server" Font-Size="X-Large" Font-Bold="True"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="LIST OF EMPLOYEES:" Font-Size="XX-Large"></asp:Label>
        <br />
        <div style="height: 400px; overflow: auto;">
            <asp:GridView ID="gridEmployee" CssClass="mydatagrid" PagerStyle-CssClass="pager" OnRowCommand="gridEmployee_RowCommand" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="false" EmptyDataText="No data uploaded" Font-Size="12pt">
                <Columns>
                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"  DataField="EmployeeNumber" HeaderText="EMPLOYEE NUMBER" />
                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px"  DataField="FullName" HeaderText="FULLNAME" />
                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px"  DataField="DepartmentName" HeaderText="DEPARTMENT" />
                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px"  DataField="SectionName" HeaderText="SECTION" />
                    <asp:ButtonField  ItemStyle-HorizontalAlign="Center"  HeaderText="Registration" ButtonType="Button" ControlStyle-CssClass="buttonGrid" Text="NOMINATE" CommandName="Nominate" HeaderStyle-Width="100px" ControlStyle-Width="150px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>--%>
</asp:Content>

