<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Manager/Manager.master" AutoEventWireup="true" CodeFile="ManagerSubmit.aspx.cs" Inherits="Home_Manager_ManagerSubmit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Manager.css" rel="stylesheet" />
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
            <asp:Label ID="Label3" runat="server" Text="Review" ForeColor="Black" Font-Bold="True" Font-Size="15"></asp:Label><br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="logoutdiv">
                <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" />
            </div>
        </div>
        <div class="right">
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="16pt" ForeColor="White" Text="Submit"></asp:Label>
        </div>
        <div id="gridWhole" runat="server" class="right">
            <br />
            &nbsp;&nbsp;&nbsp;
          <div class="rightsecond">
              <div class="rightsecondbox">
                  <asp:Label ID="lblHeader" runat="server" Text="Label" Font-Size="Large" Font-Bold="True"></asp:Label>
                  <br />
                  <asp:Label runat="server" Text="Training Venue: " Font-Names="Corbel"></asp:Label>
                  <asp:Label ID="lblTrainingVenue" runat="server" Text="Executive Lounge, PBR Housing Compound" Font-Names="Corbel"></asp:Label>
                  <br />
                  <asp:Label runat="server" Text="Facilitator: " Font-Names="Corbel"></asp:Label>
                  <asp:Label ID="lblFacilitator" runat="server" Text="Mr. Texas Joe (We Do Limited Corp.)" Font-Names="Corbel"></asp:Label>
                  <br />
                  <asp:LinkButton ID="lnkAboutTrainier" runat="server" Font-Names="Corbel">About Trainer</asp:LinkButton>
                  |
              <asp:LinkButton ID="lnkCourseOutline" runat="server" Font-Names="Corbel">Course Outline</asp:LinkButton>
                  |
              <asp:LinkButton ID="lnkBackground" runat="server" Font-Names="Corbel">Background</asp:LinkButton>
                  <br />
                  <asp:Label ID="Label1" runat="server" Text="Target Participants: " Font-Names="Corbel"></asp:Label>
                  <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers" Font-Names="Corbel"></asp:Label>
                  <br />
                  <br />
              </div>
              <div>
                  <br />
                  <br />
                  <br />
                  <div id="gridDiv" runat="server">
                      <asp:GridView ID="gridNominee" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                          <Columns>
                              <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                              <asp:BoundField DataField="NomineeId" HeaderText="NomineeId" Visible="false" />
                              <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                              <asp:BoundField DataField="ServiceYears" HeaderText="Service Years" />
                          </Columns>
                      </asp:GridView>
                      <br />
                      &nbsp;&nbsp;
                  &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;
                  <asp:Label runat="server" Text="Total Nominee Added: " Font-Names="Corbel"></asp:Label>
                      <asp:Label ID="lblTotalNominee" runat="server" Text="0" ForeColor="Red" Font-Names="Corbel"></asp:Label>
                  </div>
              </div>
          </div>

            <div class="rightsubmitbtn">
                 <asp:TextBox ID="txtFullName" CssClass="txtBox" placeholder="Enter Full Name here" runat="server"></asp:TextBox>
                <asp:Button ID="btnSubmit" CssClass="submit" runat="server" Text="Submit" Font-Bold="True" Width="110px" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>

