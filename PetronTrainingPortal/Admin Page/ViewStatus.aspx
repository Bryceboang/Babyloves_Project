<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Page/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="ViewStatus.aspx.cs" Inherits="Admin_Page_ViewStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        div {
            border: 3px solid #f1f1f1;
        }

        .text {
            width: 50%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .submit {
            width: 20%;
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

            .submit:hover {
                background-color: #45a049;
            }

        .button {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #0054a6;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            cursor: pointer;
        }

        .buttonGrid {
            background-color: red;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 20%;
        }

        select.custom-dropdown {
            -webkit-appearance: none; /*REMOVES DEFAULT CHROME & SAFARI STYLE*/
            -moz-appearance: none; /*REMOVES DEFAULT FIREFOX STYLE*/
            border: 0 !important; /*REMOVES BORDER*/
            color: #fff;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            font-size: 14px;
            text-align-last: center;
            padding: 10px;
            width: 95%;
            cursor: pointer;
            background: #0060ff url(drop-down-arrow.png) no-repeat right center;
            background-size: 40px 37px; /*TO ACCOUNT FOR @2X IMAGE FOR RETINA */
        }

        .container {
            padding: 16px;
        }

        .mydatagrid {
            width: 80%;
            border: solid 2px black;
            min-width: 80%;
        }

        .header {
            background-color: #000;
            font-family: Arial;
            color: White;
            height: 25px;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
        }

            .rows:hover {
                background-color: #5badff;
                color: #fff;
            }

        .mydatagrid a /** FOR THE PAGING ICONS  **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/ {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #fff;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        /*.pager {
            background-color: #5badff;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }*/

        .mydatagrid td {
            padding: 5px;
        }

        .mydatagrid th {
            padding: 5px;
        }

        h2 {
            display: block;
            font-size: 3em;
            margin-top: 0.30em;
            margin-bottom: 0.30em;
            margin-left: 0;
            margin-right: 0;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
            <h2>Status of Employees</h2>
       <div class="container">
         <%--  <asp:Label ID="Label1" runat="server" Text="LIST OF TRAININGS" Font-Bold="true" Font-Size="22pt"></asp:Label>--%>
           <br />
          <asp:Label ID="Label1" Font-Size="X-Large" runat="server" Text="TRANING LIST:"></asp:Label>
    <asp:DropDownList CssClass="custom-dropdown" ID="cmbTraining" runat="server" OnSelectedIndexChanged="cmbTraining_SelectedIndexChanged" AutoPostBack="True" Font-Size="18pt"></asp:DropDownList>
    <br />
       <asp:Label ID="Label2" Font-Size="X-Large" runat="server" Text="DEPARTMENT LIST:"></asp:Label>
    <asp:DropDownList CssClass="custom-dropdown" ID="cmbDepartment" runat="server" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged" AutoPostBack="True" Font-Size="18pt"></asp:DropDownList>
    <br />
        <asp:Label ID="Label3"  Font-Size="X-Large" runat="server" Text="SECTION LIST:"></asp:Label>
    <asp:DropDownList CssClass="custom-dropdown" ID="cmbSection" runat="server" OnSelectedIndexChanged="cmbSection_SelectedIndexChanged" AutoPostBack="True" Font-Size="18pt"></asp:DropDownList>
    <br />
           <asp:Label ID="Label4" Font-Size="X-Large" runat="server" Text="STATUS:"></asp:Label>
    <asp:DropDownList CssClass="custom-dropdown" ID="cmbStatus" runat="server" OnSelectedIndexChanged="cmbStatus_SelectedIndexChanged" AutoPostBack="True" Font-Size="18pt">
        <asp:ListItem>APPROVED</asp:ListItem>
        <asp:ListItem>PENDING</asp:ListItem>
        <asp:ListItem>DECLINED</asp:ListItem>
    </asp:DropDownList>
    <br />
                    <br />
         <%--    <div style =" background-color:black;  
        margin:0 ;padding:0"   >
        <table cellspacing="0" cellpadding = "0" rules="all" border="1" id="tblHeader" 
         style="font-family:Arial;font-size:10pt; color:white;
         border-collapse:collapse; height:100%;">
            <tr>
               <td style ="width:200px; text-align:center">EMPLOYEE NUMBER</td>
               <td style ="width:300px; text-align:center">FULLNAME</td>
               <td style ="width:300px; text-align:center">DEPARTMENT</td>
               <td style ="width:300px; text-align:center">SECTION</td>
               <td style ="width:200px; text-align:center">STATUS</td>
            </tr>
        </table>
        </div>--%>
        <div style =" height:400px;  overflow:auto;">
                    <asp:GridView ID="gridView" CssClass="mydatagrid"  ShowHeader = "true" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  runat="server" AutoGenerateColumns="false" EmptyDataText="No data uploaded" Font-Size="12pt">
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
                

                </div>

               <br />
                    <br />
                    <%--<asp:Button CssClass="button" ID="bTnExport" runat="server" Text="Export to Excel" OnClick="bTnExport_Click" Font-Size="15pt" Width="201px"></asp:Button>--%>
           <asp:Button CssClass="button" ID="bTnExport1" runat="server" Text="Export to Excel2" Font-Size="15pt" Width="201px" OnClick="bTnExport1_Click"></asp:Button>
                    <br />
                    <asp:Button ID="btnEmail" CssClass="button" runat="server" Text="Sample Email 2" OnClick="SendEmail2_Click" Width="157px" />
                <%--&nbsp;<asp:LinkButton runat="server" CssClass="button" ID="btnEmail1" Text="Sample Email 3"--%>
                        <%--OnClientClick="window.location.href = 'mailto:escruz@petron.com?subject=Training Subject';" OnClick="LinkButton3_Click"></asp:LinkButton>--%>
                    <%--<asp:Button ID="Button2" CssClass="button" runat="server" Text="Sample Email 4" OnClick="btnEmail4_Click" Width="157px" />--%>
                    
           <asp:DropDownList ID="cmbEmailDepartment" OnSelectedIndexChanged="cmbEmailDepartment_SelectedIndexChanged" runat="server" AutoPostBack="True">      </asp:DropDownList>
                    
           &nbsp;
           &nbsp;<asp:DropDownList ID="cmbEmailManager" OnSelectedIndexChanged="cmbEmailManager_SelectedIndexChanged" runat="server" AutoPostBack="True">  </asp:DropDownList>
         
                    
           <asp:DropDownList ID="cmbEmailSupervisor"  runat="server" AutoPostBack="True" Height="16px"></asp:DropDownList>
                    
                    <asp:Button ID="Button1" CssClass="button" runat="server" Text="Sample Email 1" OnClick="btnEmail1_Click" Width="157px" />
                    
           <%--<button class="btnSendEmail5">Send Email 5</button><br /><br />
           <a href="mailto:escruz@petron.com?subject=YourSubject&body=Test Body">Mail Me</a>
           </center>
    <script src="http://code.jquery.com/jquery-1.9.1.js" type="text/javascript"></script>
  <script type="text/javascript">
      $(function () {
          $('.btnSendEmail5').click(function (event) {
              var email = 'escruz@petron.com';
              var subject = 'STATUS AUTOEMAIL';
              var emailBody = 'SAMPLE BODY TEXT HERE';
              //var emailBodyGrid = gridView;
              window.location = 'mailto:' + email + '?subject=' + subject + '&body=' + emailBody + emailBodyGrid;
          });
      });
  </script>--%>
&nbsp;<asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>

</asp:Content>

