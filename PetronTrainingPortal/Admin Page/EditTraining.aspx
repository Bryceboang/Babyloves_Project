<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="EditTraining.aspx.cs" Inherits="EditTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center><a><asp:Label ID="Label9" runat="server" Text="EDIT TRAINING" Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label></a></center>
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left1_content_train_editTrain">
                    <center>
                    <br />
                    <asp:Label ID="Label18" runat="server" Text="Training Code:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbTrainingCode" OnSelectedIndexChanged="cmbTraining_SelectedIndexChanged"  runat="server" AutoPostBack="True"></asp:DropDownList>
                    <br />
                    <asp:Label ID="lblcmbCodeMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />
                    </center>
                </div>
                <div class="right1_content_train_editTrain">
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Training Code:" ForeColor="White" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtCode" CssClass="text" runat="server" ValidationGroup="EditTraining"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtCode" ForeColor="Red" ValidationGroup="EditTraining"></asp:RequiredFieldValidator>
                    <br />
                    <center><asp:Label ID="Label19" runat="server" ForeColor="Red" ></asp:Label></center>
                    <br />
                    <asp:Label ID="lbltxtCodeMsg" runat="server" Text="Training Title:" ForeColor="White" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:TextBox CssClass="text" ID="txtTitle" runat="server"  ValidationGroup="EditTraining" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtTitle" ForeColor="Red" ValidationGroup="EditTraining"></asp:RequiredFieldValidator>
                    <br />
                    <center><asp:Label ID="lblTitleMsg" runat="server" ForeColor="Red" ></asp:Label></center>
                </div>
            </div>
        </div>
    </div>
    <div class="main_container_train_admin">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left2_content_train_editTrain">
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="•Training Venue:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtVenue" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="•Date Duration:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtDateDuration" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </div>
                <div class="center2_content_train_editTrain">
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="•Time Duration:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtTimeDuration" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="•Training Provider:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtProvider" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </div>
                <div class="right2_content_train_editTrain">
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="•Target Participants:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtParticipants" runat="server"  ValidationGroup="AddTraining" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </div>
            </div>
        </div>
    </div>
    <center><asp:Button CssClass="button" ID="btnSave" runat="server" Text="Update Training" OnClick="btnSave_Click" ValidationGroup="AddTraining" Font-Size="12pt" Width="207px"></asp:Button></center>



        <%--<center>
            <h2>EDIT TRAINING</h2>
                <div class="container">
                    <asp:Label ID="Label1" runat="server" Text="Training Code:" Width="200px" Font-Size="X-Large"></asp:Label>
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbTrainingCode" OnSelectedIndexChanged="cmbTraining_SelectedIndexChanged"  runat="server" Font-Size="20pt" AutoPostBack="True"></asp:DropDownList>
                      <asp:Label ID="lblcmbCodeMsg" runat="server" ForeColor="Red" ></asp:Label>
                     <br />
                    <asp:Label ID="Label4" runat="server" Text="Training Code:" Width="200px" Font-Size="X-Large"></asp:Label>
                    &nbsp;
                    <asp:TextBox CssClass="text" ID="txtCode" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                          <asp:Label ID="lbltxtCodeMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCode" ErrorMessage="*" ForeColor="Red" ValidationGroup="AddTraining"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Training Title:" Width="200px" Font-Size="X-Large"></asp:Label>
                    &nbsp;
                    <asp:TextBox CssClass="text" ID="txtTitle" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                          <asp:Label ID="lblTitleMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTitle" ErrorMessage="*" ForeColor="Red" ValidationGroup="AddTraining"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="DESCRIPTION:" Width="500px" Font-Size="X-Large" Height="31px"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="•Training Venue:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtVenue" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="•Date Duration:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtDateDuration" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="•Time Duration:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtTimeDuration" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="•Training Provider:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtProvider" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="•Target Participants:" Width="300px" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox CssClass="text" ID="txtParticipants" runat="server"  ValidationGroup="AddTraining" Font-Size="14pt"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button CssClass="button" ID="btnSave" runat="server" Text="Update Training" OnClick="btnSave_Click" ValidationGroup="EditTraining" Font-Size="15pt" Width="220px"></asp:Button>
                </div>
        </center>--%>
</asp:Content>

