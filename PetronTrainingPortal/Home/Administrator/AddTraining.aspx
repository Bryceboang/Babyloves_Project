<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="AddTraining.aspx.cs" Inherits="Home_Administrator_AddTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Administrator.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><a><asp:Label ID="Label9" runat="server" Text="ADD TRAINING" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label></a></center>
    <br />
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left1_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Training Program: " ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                    <%-- dito yung onsite or in house training --%>
                    <br />
                    <center><asp:Label ID="lblCodeMsg" runat="server" ForeColor="Red" ></asp:Label></center>
                </div>
                <div class="right1_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Training Title: " ForeColor="White" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:TextBox CssClass="text" ID="txtTitle" runat="server"  ValidationGroup="AddTraining" ></asp:TextBox>
                    <center><asp:Label ID="lblTitleMsg" runat="server" ForeColor="Red" ></asp:Label></center>
                    <asp:Label ID="Label1" runat="server" Text="•Course Outline: " ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="TextBox1" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="•Background: " ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="TextBox2" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left2_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="•Starting Date: " ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtVenue" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="•End Date: " ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtDateDuration" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </div>
                <div class="center2_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="•Venue: " ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtTimeDuration" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="•Target Participants: " ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtProvider" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </div>
                <div class="right2_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="•Facilitator: " ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtParticipants" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="•About Trainer: " ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="TextBox3" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <center><asp:Button CssClass="button" ID="btnSave" runat="server" Text="Add Training" ValidationGroup="AddTraining" Font-Size="12pt" Width="207px"></asp:Button></center>
</asp:Content>

