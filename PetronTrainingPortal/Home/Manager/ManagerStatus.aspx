<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Manager/Manager.master" AutoEventWireup="true" CodeFile="ManagerStatus.aspx.cs" Inherits="Home_Manager_ManagerStatus" %>

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
        &nbsp;<asp:Label ID="lblName" runat="server" Text="" ForeColor="Black" Font-Bold="True"></asp:Label> <br /> <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" Text="Status Page" ForeColor="Black" Font-Bold="True" Font-Size="15"></asp:Label><br />
        <asp:Panel ID="menuPanel" runat="server" ScrollBars="Vertical">
            </asp:Panel>
            <div class="logoutdiv">
                <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" />
            </div>
        </div>
        <div id="gridWhole" runat="server" class="right">
            <div class="headernominate">
                  <center><asp:Label ID="Label2" runat="server" Text="Status" Font-Names="Corbel" Font-Bold="true" Font-Size="XX-Large"></asp:Label></center>
              </div>
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
                    <asp:LinkButton ID="lnkAboutTrainier" runat="server" Font-Names="Corbel" OnClick="lnkAboutTrainer_Click">About Trainer</asp:LinkButton>|
              <asp:LinkButton ID="lnkCourseOutline" runat="server" Font-Names="Corbel" OnClick="lnkCourseOutline_Click">Course Outline</asp:LinkButton>|
              <asp:LinkButton ID="lnkBackground" runat="server" Font-Names="Corbel" OnClick="lnkBackground_Click">Background</asp:LinkButton>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Target Participants: " Font-Names="Corbel"></asp:Label>
                    <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers" Font-Names="Corbel"></asp:Label>
                </div>
                <asp:GridView ID="gridNominee" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                        <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <br />
                <div id="gridDiv" runat="server" class="rightgrid">
                    <br />
                    <div class="nominee">
                        <asp:Label runat="server" Text="Total Nominee: " Font-Names="Corbel"></asp:Label>
                        <asp:Label ID="lblTotalNominee" runat="server" Text="0" ForeColor="Red" Font-Names="Corbel"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

