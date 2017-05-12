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
            <div class="logoutdiv">
                <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" OnClick="btnLogout_Click" />
            </div>
        </div>
        <div class="right">
            <br />
            &nbsp;&nbsp;&nbsp;
          <div class="rightsecond">
              <asp:Label ID="lblHeader" runat="server" Text="Label"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Training Venue: " Font-Names="Corbel"></asp:Label>
              <asp:Label ID="lblTrainingVenue" runat="server" Text="Executive Lounge, PBR Housing Compound" Font-Names="Corbel"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Facilitator: " Font-Names="Corbel"></asp:Label>
              <asp:Label ID="lblFacilitator" runat="server" Text="Mr. Texas Joe (We Do Limited Corp.)" Font-Names="Corbel"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Target Participants: "></asp:Label>
              <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers" Font-Names="Corbel"></asp:Label>
              <br />
              <asp:LinkButton ID="lnkAboutTrainier" runat="server" Font-Names="Corbel">About Trainer</asp:LinkButton>
              &nbsp;&nbsp;
                    <asp:LinkButton ID="lnkCourseOutline" runat="server" Font-Names="Corbel">Course Outline</asp:LinkButton>
              &nbsp;&nbsp;
                           <asp:LinkButton ID="lnkBackground" runat="server" Font-Names="Corbel">LinkButton</asp:LinkButton>
              <br />
              <asp:LinkButton ID="lnkAddNominee" runat="server" OnClick="lnkAddNominee_Click" Font-Names="Corbel">Add Nominee</asp:LinkButton>
              &nbsp;&nbsp;
                    <asp:LinkButton ID="lnkPassForConfirmation" runat="server" Font-Names="Corbel">Pass For Confirmation</asp:LinkButton>
              &nbsp;&nbsp;
                           <asp:LinkButton ID="lnkDelete" runat="server" Font-Names="Corbel">Delete</asp:LinkButton>
              <br />
              <br />
              <br />
              <div id="gridDiv" runat="server">
                  <asp:GridView ID="gridNominee" runat="server" AutoGenerateColumns="false" OnRowCommand="gridNominee_RowCommand"  CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                      <Columns>
                          <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                          <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                          <asp:BoundField DataField="ServiceYears" HeaderText="Service Years" />
                          <asp:ButtonField  ItemStyle-HorizontalAlign="Center"  HeaderText="NOMINATE" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image" ImageUrl="~/Image/Button-Add-icon.png" Text="NOMINATE" CommandName="NominateEmployee"/>
                      </Columns>
                  </asp:GridView>
                  <br />
                  <asp:Label ID="lblDepartment" runat="server" Text="Department" Font-Names="Corbel"></asp:Label>
                  &nbsp;&nbsp;
                <asp:Label ID="lblSection" runat="server" Text="Section" Font-Names="Corbel"></asp:Label>
                  &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;
                  <asp:Label runat="server" Text="Total Nominee Added: " Font-Names="Corbel"></asp:Label>
                  <asp:Label ID="lblTotalNominee" runat="server" Text="2" ForeColor="Red" Font-Names="Corbel"></asp:Label>
              </div>
          </div>
        </div>
    </div>
</asp:Content>

