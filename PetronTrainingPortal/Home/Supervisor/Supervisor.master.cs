using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Supervisor_Supervisor : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////if (Session["EmpNo"] == null)
        ////{
        ////    Response.Redirect("~/Home/Login.aspx");
        ////}
        ////else if (Session["AccountType"] == "Admin")
        ////{
        ////    Response.Redirect("~/Administrator/ReportAdmin.aspx");
        ////    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Supervisor only" + "');", true);
        ////}
        ////else if (Session["AccountType"] == "Manager")
        ////{
        ////    Response.Redirect("~/Home/Manager/ManagerList.aspx");
        ////    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Supervisor only" + "');", true);
        ////}
    }
}
