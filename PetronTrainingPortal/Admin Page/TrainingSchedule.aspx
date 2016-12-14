<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="TrainingSchedule.aspx.cs" Inherits="Admin_Page_TrainingSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><a><asp:Label ID="Label2" runat="server" Text="TRAINING SCHEDULES" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label></a></center>
    <br />
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="center_content_train_admin">
                    <br />
                    <center><asp:Label ID="lblList" Text="LIST OF ACTIVE TRAININGS" runat="server" ForeColor="White" Font-Bold="True" Font-Size="15"></asp:Label>
                    <asp:GridView ID="gridTraining" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" Width="850px">
                        <Columns>
                            <asp:BoundField DataField="TrainingTitle" HeaderText="Training Title" />
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
</asp:Content>

