<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="DeleteTraining.aspx.cs" Inherits="DeleteTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main_container_deletetrain">
        <div class="main_box_train">
            <div class="content_train">
                <div class="left_content_deletetrain">
                    <center>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Training Code" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="txtTrainingCode" runat="server" ValidationGroup="deltrain"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtTrainingCode" ForeColor="Red" ValidationGroup="deltrain"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Button CssClass="button_enter" ID="btnSearch" runat="server" Text="Enter" OnClick="btnSearch_Click" ValidationGroup="deltrain"></asp:Button>
                    </center>
                </div>
                <div class="right_content_deletetrain">
                    <asp:Label ID="Label8" runat="server" Text="Training Details" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <center><asp:Label ID="lblTrainingTitle" runat="server" ForeColor="White" Font-Bold="True" Font-Size="15pt"></asp:Label>
                    <asp:GridView ID="gridTraining" OnRowCommand="gridTraining_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" EmptyDataText="No data uploaded" Font-Size="8pt" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="TrainingVenue" HeaderText="Training Venue" />
                            <asp:BoundField DataField="DateDuration" HeaderText="Date Duration" />
                            <asp:BoundField DataField="TimeDuration" HeaderText="Time Duration" />
                            <asp:BoundField DataField="TrainingProvider" HeaderText="Training Provider" />
                            <asp:BoundField DataField="TargetParticipants" HeaderText="Target Participants" />
                            <asp:ButtonField  CommandName="Remove"   ImageUrl="~/Image/remove.jpg" Text="" ItemStyle-HorizontalAlign="Center"  HeaderText="" ControlStyle-CssClass="buttonAddDelete" ButtonType="Image"  />
                        </Columns>
                    </asp:GridView>
                    </center>
                </div>
            </div>
        </div>
    </div>
    <center></center>



    <%--<center>
            <h2>DELETE TRAINING</h2>
                <div class="container">
                    <asp:Label ID="Label1" runat="server" Text="Training Code:" Width="200px" Font-Size="X-Large"></asp:Label>
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbTrainingCode" runat="server" Font-Size="20pt" OnSelectedIndexChanged="cmbTrainingCode_SelectedIndexChanged" AutoPostBack="True" Width="469px"></asp:DropDownList>
                    <asp:Label ID="lblCodeMsg" runat="server" ForeColor="Red" ></asp:Label>
                     <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Training Title:" Width="200px" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="lblTrainingTitle" runat="server" Text="" Font-Size="X-Large"></asp:Label>
                    <br />
                    <br />--%>
                      <%--    
                    <asp:Label ID="Label3" runat="server" Text="Description:" Font-Size="X-Large"></asp:Label>
                    <br />
              <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="false" EmptyDataText="No data uploaded" Font-Size="12pt">
                    <Columns>
                    <asp:BoundField DataField="TrainingVenue" HeaderText="Training Venue"  />
                    <asp:BoundField DataField="DateDuration" HeaderText="Date Duration"  />
                    <asp:BoundField DataField="TimeDuration" HeaderText="Time Duration"  />
                    <asp:BoundField DataField="TrainingProvider" HeaderText="Training Provider"  />
                    <asp:BoundField DataField="TargetParticipants" HeaderText="Target Participants"  />
                    </Columns>    
                    </asp:GridView>--%>
                    <%--<br />
                    <br />
                    
                </div>
        </center>--%>

</asp:Content>

