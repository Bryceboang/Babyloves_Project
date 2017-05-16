<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Supervisor/Supervisor.master" AutoEventWireup="true" CodeFile="SupervisorConfirmation.aspx.cs" Inherits="Home_Supervisor_SupervisorConfirmation" %>

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
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br /> <br /> <br /> <br /> <br /> <br /> <br />
       <div class="logoutdiv">
            <asp:Button ID="btnLogout" CssClass="logout" runat="server" Text="Logout" Font-Bold="True" Width="100px" OnClick="btnLogout_Click" />
        </div>
        </div>
        <div class="right">
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Submit" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label>
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
              <asp:LinkButton ID="lnkAboutTrainier" runat="server" Font-Names="Corbel">About Trainer</asp:LinkButton> |
              <asp:LinkButton ID="lnkCourseOutline" runat="server" Font-Names="Corbel">Course Outline</asp:LinkButton>  |
              <asp:LinkButton ID="lnkBackground" runat="server" Font-Names="Corbel">Background</asp:LinkButton>
              <br />
              <asp:Label ID="Label1" runat="server" Text="Target Participants: " Font-Names="Corbel"></asp:Label>
              <asp:Label ID="lblTarget" runat="server" Text="Production A- Process Engineers" Font-Names="Corbel"></asp:Label>
              <br />
              <br />
        <div class="rightconfirmation">
            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Your nomination has been successfully passed for  confirmation of your Manager. You may view the “Status Page” for updates on registration." Font-Names="Corbel"></asp:Label> <br /> <br />
            <asp:HyperLink ID="HyperLink1" CssClass="hyperlink" ForeColor="White" runat="server" NavigateUrl="~/Home/Default.aspx">Go back to Shopping Cart</asp:HyperLink>
        </div>
        </div>
    </div>
</asp:Content>

