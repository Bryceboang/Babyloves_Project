<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Manager/Manager.master" AutoEventWireup="true" CodeFile="ManagerSubmit.aspx.cs" Inherits="Home_Manager_ManagerSubmit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Manager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script src="../sweetalert-master/dist/sweetalert.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../sweetalert-master/dist/sweetalert.css">
    <script>
        function sweetAlertMessage(myTitle, myText) {
            swal(
             title = myTitle,
             text = myText
         );
        }

        function sweetAlertSuccess(myText) {
            swal(
             title = myText,
             type = "success"
         );
        }

        function sweetAlertWarning(myText) {
            swal(
             title = "Warning",
             text = myText,
             type = "warning"
         );
        }

        function sweetAlertError(myText) {
            swal(
             title = "Error",
             text = myText,
             type = "error"
         );
        }

        function sweetAlertInfo(myText) {
            swal(
             title = "Information",
             text = myText,
             type = "info"
         );
        }
    </script>
    <div class="main">
        <div class="left">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblHello" runat="server" Text="Hello!" ForeColor="Black" Font-Bold="True"></asp:Label>
            &nbsp;<asp:Label ID="lblName" runat="server" Text="" ForeColor="Black" Font-Bold="True"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Review" ForeColor="Black" Font-Bold="True" Font-Size="15"></asp:Label>
              <asp:Panel ID="menuPanel" runat="server" ScrollBars="Vertical">
            </asp:Panel>
            <div class="logoutdiv">
                <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" />
            </div>
        </div>
        <div id="gridWhole" runat="server" class="right">
            <div class="headernominate">
                  <center><asp:Label ID="Label2" runat="server" Text="Submit" Font-Names="Corbel" Font-Bold="true" Font-Size="XX-Large"></asp:Label></center>
              </div>
          <div class="rightsecond">
              <div class="rightsecondbox">
                  <asp:Label ID="Label5" runat="server" Text="Please review the  list of attendees you nominated." Font-Names="Corbel" Font-Size="Large"></asp:Label> <br /> <br />
                  <asp:Label ID="lblHeader" runat="server" Text="Label" Font-Size="Large" Font-Bold="True" ForeColor="Red"></asp:Label>
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
              </div>
              <div>
                  <div id="gridDiv" runat="server">
                      <div class="grid">
                      <asp:GridView ID="gridNominee" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" OnRowCommand="gridNominee_RowCommand" EmptyDataText="No data uploaded" Font-Size="10pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                          <Columns>
                              <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                              <asp:BoundField DataField="NomineeId" HeaderText="NomineeId" Visible="false" />
                              <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                              <asp:BoundField DataField="ServiceYears" HeaderText="Service Years" />
                             <asp:ButtonField ItemStyle-HorizontalAlign="Center"  HeaderText="REMOVE" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image" ImageUrl="~/Image/Button-Delete-icon.png" Text="NOMINATE" CommandName="NominateEmployee"/>
                          </Columns>
                      </asp:GridView>
                    </div>
                      <br />
                      <div class="label">
                  <asp:Label runat="server" Text="Total Nominee Added: " Font-Names="Corbel"></asp:Label>
                      <asp:Label ID="lblTotalNominee" runat="server" Text="0" ForeColor="Red" Font-Names="Corbel"></asp:Label>
                      </div>
                  </div>
              </div>
              <br /> <br />
              <div>
                  <asp:Label ID="Label4" runat="server" Text="I verify through inputting  my name here that the list is  complete and accurate." Font-Names="Corbel" Font-Size="Large"></asp:Label> <br />
                  <asp:TextBox ID="txtFullName" CssClass="txtBox" placeholder="Enter Full Name here" runat="server"></asp:TextBox>
              </div>
          </div>
            <div class="rightsubmitbtn">
                 
                <asp:Button ID="btnSubmit" CssClass="submit" runat="server" Text="Submit" Font-Bold="True" Width="110px" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>

