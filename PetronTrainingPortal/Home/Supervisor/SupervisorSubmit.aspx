<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Supervisor/Supervisor.master" AutoEventWireup="true" CodeFile="SupervisorSubmit.aspx.cs" Inherits="Home_Supervisor_SupervisorSubmit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Supervisor.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">
        <div class="left">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblHello" runat="server" Text="Hello!" ForeColor="Black" Font-Bold="True"></asp:Label>
        &nbsp;<asp:Label ID="lblName" runat="server" Text="" ForeColor="Black" Font-Bold="True"></asp:Label> <br /> <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" Text="Review" ForeColor="Black" Font-Bold="True" Font-Size="15"></asp:Label><br /> <br /> <br /> <br /> <br /> <br /> <br />
           <asp:Panel ID="menuPanel" runat="server" ScrollBars="Vertical">
            </asp:Panel>
              <div class="logoutdiv">
            <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" OnClick="btnLogout_Click" />
        </div>
        </div>
        <div class="right">
            <div class="headernominate">
                  <center><asp:Label ID="Label6" runat="server" Text="Submit" Font-Names="Corbel" Font-Bold="true" Font-Size="XX-Large"></asp:Label></center>
              </div>
            <div class="rightsubmit">
            <asp:Label ID="Label2" runat="server" Text="Please review list below if complete and final for compliance. Kindly key-in your full name for authentication then click the submit button." Font-Names="Corbel" Font-Size="Smaller"></asp:Label>
        </div>
        <div class="rightsubmit2">
            <asp:Label ID="Label4" runat="server" Text="I verify that the following registration is valid and will conform to the terms and conditions set by the Technical Training Department." Font-Names="Corbel" Font-Size="Smaller"></asp:Label>
            <asp:TextBox ID="txtFullName" CssClass="txtBox" placeholder="Enter Full Name here" runat="server"></asp:TextBox>
        </div>
         <div  id="gridWhole" runat="server">
          <div class="rightsubmit3">
              <div class="rightsubmit4">
              <asp:Label ID="lblHeader" runat="server" Text="Label" Font-Size="Large" Font-Bold="True"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Training Venue: " Font-Names="Corbel" Font-Size="Small"></asp:Label>
              <asp:Label ID="lblTrainingVenue" runat="server" Text="Executive Lounge, PBR Housing Compound" Font-Names="Corbel" Font-Size="Small"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Facilitator: " Font-Names="Corbel" Font-Size="Small"></asp:Label>
              <asp:Label ID="lblFacilitator" runat="server" Text="Mr. Texas Joe (We Do Limited Corp.)" Font-Names="Corbel" Font-Size="Small"></asp:Label>
              <br />
              <asp:LinkButton ID="lnkAboutTrainier" runat="server" Font-Names="Corbel" Font-Size="Small">About Trainer</asp:LinkButton> |
              <asp:LinkButton ID="lnkCourseOutline" runat="server" Font-Names="Corbel" Font-Size="Small">Course Outline</asp:LinkButton>  |
              <asp:LinkButton ID="lnkBackground" runat="server" Font-Names="Corbel" Font-Size="Small">Background</asp:LinkButton>
              <br />
              <asp:Label ID="Label1" runat="server" Text="Target Participants: " Font-Names="Corbel" Font-Size="Small"></asp:Label>
              <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers" Font-Names="Corbel" Font-Size="Small"></asp:Label>
              </div>
              <br />
              <div id="gridDiv" runat="server">
                  <div class="grid">
                  <asp:GridView ID="gridNominee" runat="server" AutoGenerateColumns="false" OnRowCommand="gridNominee_RowCommand"  CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                      <Columns>
                          <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                          <asp:BoundField DataField="NomineeId" HeaderText="NomineeId" Visible="false" />
                          <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                          <asp:BoundField DataField="ServiceYears" HeaderText="Service Years" />
                          <asp:ButtonField  ItemStyle-HorizontalAlign="Center"  HeaderText="REMOVE" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image" ImageUrl="~/Image/Button-Delete-icon.png" Text="NOMINATE" CommandName="NominateEmployee"/>
                      </Columns>
                  </asp:GridView>
                </div>
                  <br />
                  <div class="labelsubmit">
                  <asp:Label runat="server" Text="Total Nominee Added: " Font-Names="Corbel" Font-Size="Small"></asp:Label>
                  <asp:Label ID="lblTotalNominee" runat="server" Text="0" ForeColor="Red" Font-Names="Corbel" Font-Size="Small"></asp:Label>
                </div>
              </div>
        </div>

        <div class="rightsubmitbtn">
        <asp:Button ID="btnSubmit" CssClass="submit" runat="server" Text="Submit" Font-Bold="True" Width="110px" OnClick="btnSubmit_Click" />
        </div>
            </div>
    </div>
</asp:Content>

