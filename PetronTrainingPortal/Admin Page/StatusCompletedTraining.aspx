<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="StatusCompletedTraining.aspx.cs" Inherits="Admin_Page_StatusCompletedTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><asp:Label ID="Label5" runat="server" Text="COMPLETED TRAINING" Font-Size="18" ForeColor="White" Font-Bold="True"></asp:Label></center>
    <div class="main_container_train">
        <div class="main_box_train">
            <div class="content_train">
                <center>
                <div class="left_content_train">
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Training Title:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbTraining" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbTraining_SelectedIndexChanged"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Date:" ForeColor="White" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbDate_SelectedIndexChanged"></asp:DropDownList>
                 </div>
                <div class="right_content_train">
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Department:" Font-Bold="True" ForeColor="White"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Section:" Font-Bold="True" ForeColor="White"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="custom-dropdown" ID="cmbSection" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSection_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="upperright_content_train">
                    <div style =" height:200px;  overflow:auto;">
                    <asp:GridView ID="gridView" CssClass="mydatagrid"  ShowHeader = "true" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="false" EmptyDataText="No data uploaded" Font-Size="12pt">
                    <Columns>
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"  DataField="SectionName" HeaderText="SECTION NAME"  />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px"  DataField="NoOfEmployees" HeaderText="NUMBER OF EMPLOYEES"  />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px"  DataField="NoOfSupervisor" HeaderText="NUMBER OF Supervisor"  />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px"  DataField="TotalApproved" HeaderText="TOTAL APPROVED"  />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px"  DataField="TotalPending" HeaderText="TOTAL PENDING"  />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px"  DataField="TotalDeclined" HeaderText="TOTAL DECLINED"  />
                    </Columns>
             <RowStyle CssClass="rows"></RowStyle>
                    </asp:GridView>
                </div>
                </center>
                </div>
            <div class="left_content_train2">
            <div style =" height:300px;  overflow:auto; width: 785px;">
                <center>
                    <asp:GridView ID="gridViewEmployee" CssClass="mydatagrid"  ShowHeader = "true" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  runat="server" AutoGenerateColumns="false" EmptyDataText="No data uploaded" Font-Size="8pt">
                    <Columns>
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"  DataField="EmployeeNumber" HeaderText="EMPLOYEE NUMBER"  />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px"  DataField="FullName" HeaderText="FULLNAME"  />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px"  DataField="DepartmentName" HeaderText="DEPARTMENT"  />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px"  DataField="SectionName" HeaderText="SECTION"  />
                    <asp:BoundField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px"  DataField="Status" HeaderText="STATUS"  />
                    </Columns>
                        <HeaderStyle CssClass="header"></HeaderStyle>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                        <PagerStyle CssClass="pager"></PagerStyle>
                        <RowStyle CssClass="rows"></RowStyle>
                    </asp:GridView>
                </center>
                </div>
              </div>
            <div class="right_content_train2">
                <center>
                    <br />
                    <br />
              <asp:Button CssClass="button" ID="bTnExport1" runat="server" Text="Export to Excel" Font-Size="10pt" Width="150" OnClick="bTnExport1_Click"></asp:Button>
                </center>
            </div>
            </div>
        </div>
</asp:Content>

