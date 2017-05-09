<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Supervisor/Supervisor.master" AutoEventWireup="true" CodeFile="SupervisorNominate.aspx.cs" Inherits="Home_Supervisor_SupervisorNominate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Supervisor.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="left">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblHello" runat="server" Text="Hello!" ForeColor="Black" Font-Bold="True"></asp:Label>
            &nbsp;<asp:Label ID="lblName" runat="server" Text="" ForeColor="Black" Font-Bold="True"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Shopping Cart" ForeColor="Black" Font-Bold="True" Font-Size="15"></asp:Label><br />
            <asp:Panel ID="menuPanel" runat="server" Height="346px" Width="277px" ScrollBars="Vertical">
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="logoutdiv">
                <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" OnClick="btnLogout_Click" />
            </div>
        </div>
        <div class="right">
            <br />
            &nbsp;&nbsp;&nbsp;
          <div>
              <asp:Label ID="lblHeader" runat="server" Text="Label"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Training Venue: "></asp:Label>
              <asp:Label ID="lblTrainingVenue" runat="server" Text="Executive Lounge, PBR Housing Compound"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Facilitator: "></asp:Label>
              <asp:Label ID="lblFacilitator" runat="server" Text="Mr. Texas Joe (We Do Limited Corp.)"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Target Participants: "></asp:Label>
              <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers"></asp:Label>
              <br />
              <asp:LinkButton ID="lnkAboutTrainier" runat="server">About Trainer</asp:LinkButton>
              &nbsp;&nbsp;
                    <asp:LinkButton ID="lnkCourseOutline" runat="server">Course Outline</asp:LinkButton>
              &nbsp;&nbsp;
                           <asp:LinkButton ID="lnkBackground" runat="server">LinkButton</asp:LinkButton>
              <br />
              <asp:LinkButton ID="lnkAddNominee" runat="server" OnClick="lnkAddNominee_Click">Add Nominee</asp:LinkButton>
              &nbsp;&nbsp;
                    <asp:LinkButton ID="lnkPassForConfirmation" runat="server">Pass For Confirmation</asp:LinkButton>
              &nbsp;&nbsp;
                           <asp:LinkButton ID="lnkDelete" runat="server">Delete</asp:LinkButton>
              <br />
              <br />
              <br />
              <div id="gridDiv" runat="server">
                  <asp:GridView ID="gridNominee" runat="server" AutoGenerateColumns="false" OnRowCommand="gridNominee_RowCommand"  CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                      <Columns>
                          <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                          <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                          <asp:BoundField DataField="ServiceYears" HeaderText="Service Years" />
                          <asp:ButtonField  ItemStyle-HorizontalAlign="Center"  HeaderText="NOMINATE" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image" Text="NOMINATE" CommandName="NominateEmployee"/>
                      </Columns>
                  </asp:GridView>
                  <br />
                  <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                  &nbsp;&nbsp;
                <asp:Label ID="lblSection" runat="server" Text="Section"></asp:Label>
                  &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;
                  <asp:Label runat="server" Text="Total Nominee Added: "></asp:Label>
                  <asp:Label ID="lblTotalNominee" runat="server" Text="2" ForeColor="Red"></asp:Label>
              </div>
          </div>
        </div>
    </div>
</asp:Content>

