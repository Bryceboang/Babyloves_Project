<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Manager/Manager.master" AutoEventWireup="true" CodeFile="ManagerApprove.aspx.cs" Inherits="Home_Manager_ManagerApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Manager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script src="../SweetAlert/dist/sweetalert.min.js"></script>

    <link rel="stylesheet" type="text/css" href="../Sweetalert/dist/sweetalert.css">
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

        function sweetAlertConfirmation() {
            document.querySelector('#from1').addEventListener('submit', function (e) {
                var form = this;
                e.preventDefault();
                swal({
                    title: "Are you sure?",
                    text: "You will not be able to recover this imaginary file!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: '#DD6B55',
                    confirmButtonText: 'Yes, I am sure!',
                    cancelButtonText: "No, cancel it!",
                    closeOnConfirm: false,
                    closeOnCancel: false
                },
                function (isConfirm) {
                    if (isConfirm) {
                        swal({
                            title: 'Shortlisted!',
                            text: 'Candidates are successfully shortlisted!',
                            type: 'success'
                        }, function () {
                            form.submit();
                        });

                    } else {
                        swal("Cancelled", "Your imaginary file is safe :)", "error");
                    }
                });
            });
        }


        $('.confirmation').click(function (e) {
            e.preventDefault(); // Prevent the href from redirecting directly
            var linkURL = $(this).attr("href");
            warnBeforeRedirect(linkURL);
        });

        function warnBeforeRedirect(linkURL) {
            swal({
                title: "Leave this site?",
                text: "If you click 'OK', you will be redirected to " + linkURL,
                type: "warning",
                showCancelButton: true
            }, function () {
                // Redirect the user
                window.location.href = linkURL;
            });
        }

    </script>
    <div class="main">
        <div class="left">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblHello" runat="server" Text="Hello!" ForeColor="Black" Font-Bold="True"></asp:Label>
        &nbsp;<asp:Label ID="lblName" runat="server" Text="" ForeColor="Black" Font-Bold="True"></asp:Label> <br /> <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" Text="Items for Confirmation" ForeColor="Black" Font-Bold="True" Font-Size="15"></asp:Label><br />
             <asp:Panel ID="menuPanel" runat="server" ScrollBars="Vertical">
            </asp:Panel>
             <div class="logoutdiv">
        <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" OnClick="btnLogout_Click" />
        </div>
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
                  <asp:LinkButton ID="lnkAboutTrainier" runat="server" Font-Names="Corbel" OnClick="lnkAboutTrainer_Click">About Trainer</asp:LinkButton>
                  |
              <asp:LinkButton ID="lnkCourseOutline" runat="server" Font-Names="Corbel" OnClick="lnkCourseOutline_Click">Course Outline</asp:LinkButton>
                  |
              <asp:LinkButton ID="lnkBackground" runat="server" Font-Names="Corbel" OnClick="lnkBackground_Click">Background</asp:LinkButton>
                  <br />
                  <asp:Label ID="Label1" runat="server" Text="Target Participants: " Font-Names="Corbel"></asp:Label>
                  <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers" Font-Names="Corbel"></asp:Label>
                  <br />
                  <br />
              </div>
              <div>
                  <asp:LinkButton ID="lnkConfirm" runat="server" OnClick="lnkConfirm_Click" Font-Names="Corbel">Confirm Nominations</asp:LinkButton>
                  &nbsp;&nbsp;
                    <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="lnkSubmit_Click" Font-Names="Corbel">Submit</asp:LinkButton>
                  &nbsp;&nbsp;
                           <asp:LinkButton ID="lnkDecline" runat="server" Font-Names="Corbel" OnClick="lnkDecline_Click">Decline</asp:LinkButton>
              </div>
              <br />
              <br />
              <br />
              <div id="gridDiv" runat="server">
                  <asp:GridView ID="gridNominee" runat="server" AutoGenerateColumns="false" OnRowCommand="gridNominee_RowCommand" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                      <Columns>
                          <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" />
                          <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                          <asp:BoundField DataField="ServiceYears" HeaderText="Service Years" />
                              <asp:BoundField DataField="Status" HeaderText="Status" />
                          <asp:ButtonField ItemStyle-HorizontalAlign="Center" HeaderText="CONFIRM" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image" ImageUrl="~/Image/Button-Add-icon.png" Text="CONFIRM" CommandName="ConfirmEmployee" />
                          <asp:ButtonField ItemStyle-HorizontalAlign="Center" HeaderText="DECLINE" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image" ImageUrl="~/Image/Button-Delete-icon.png" Text="DECLINE" CommandName="DeclineEmployee" />
                      </Columns>
                  </asp:GridView>
                  <br />
                  &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;    &nbsp;&nbsp;
                  <asp:Label runat="server" Text="Total Nominees: " Font-Names="Corbel"></asp:Label>
                  <asp:Label ID="lblTotalNominee" runat="server" Text="0" ForeColor="Red" Font-Names="Corbel"></asp:Label>
              </div>
          </div>
        </div>
    </div>
</asp:Content>

