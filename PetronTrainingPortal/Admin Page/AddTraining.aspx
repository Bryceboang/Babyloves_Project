<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="AddTraining.aspx.cs" Inherits="AddTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><a><asp:Label ID="Label9" runat="server" Text="ADD TRAINING" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label></a></center>
    <br />
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left1_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Training Code:" ForeColor="White" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtCode" CssClass="textCode" runat="server" ValidationGroup="AddTraining"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtTrainingCode" ForeColor="Red" ValidationGroup="AddTraining"></asp:RequiredFieldValidator>
                    <br />
                    <center><asp:Label ID="lblCodeMsg" runat="server" ForeColor="Red" ></asp:Label></center>
                </div>
                <div class="right1_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Training Title:" ForeColor="White" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:TextBox CssClass="text" ID="txtTitle" runat="server"  ValidationGroup="AddTraining" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtTitle" ForeColor="Red" ValidationGroup="AddTraining"></asp:RequiredFieldValidator>
                    <br />
                    <center><asp:Label ID="lblTitleMsg" runat="server" ForeColor="Red" ></asp:Label></center>
                </div>
            </div>
        </div>
    </div>
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left2_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="•Training Venue:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtVenue" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="•Date Duration:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtDateDuration" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </div>
                <div class="center2_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="•Time Duration:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtTimeDuration" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="•Training Provider:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtProvider" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </div>
                <div class="right2_content_train_addTrain">
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="•Target Participants:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtParticipants" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </div>
            </div>
        </div>
    </div>
    <center><asp:Button CssClass="button" ID="btnSave" runat="server" Text="Add Training" OnClick="btnSave_Click" ValidationGroup="AddTraining" Font-Size="12pt" Width="207px"></asp:Button></center>

        <%--<center>
            <h2>ADD TRAINING</h2>
                <div class="container">
                    <asp:Label ID="Label3" runat="server" Text="Training Code:" Width="200px" Font-Size="X-Large"></asp:Label>
                    &nbsp;
                    <asp:TextBox CssClass="text" ID="txtCode" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <asp:Label ID="lblCodeMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Training Title:" Width="200px" Font-Size="X-Large"></asp:Label>
                    &nbsp;
                    <asp:TextBox CssClass="text" ID="txtTitle" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <asp:Label ID="lblTitleMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="DESCRIPTION:" Width="150px" Font-Size="X-Large" Height="31px"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="•Training Venue:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtVenue" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="•Date Duration:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtDateDuration" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="•Time Duration:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtTimeDuration" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="•Training Provider:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtProvider" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="•Target Participants:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtParticipants" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Button CssClass="button" ID="btnSave" runat="server" Text="Add Training" OnClick="btnSave_Click" ValidationGroup="AddTraining" Font-Size="15pt" Width="207px"></asp:Button>
                </div>
        </center>--%>
</asp:Content>

