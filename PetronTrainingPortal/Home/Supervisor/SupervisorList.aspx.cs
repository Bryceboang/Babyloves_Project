using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Supervisor_SupervisorList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnShoppingCart_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Default.aspx");
    }
    protected void btnNominateApprove_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Supervisor/SupervisorNominate.aspx");
    }
    protected void btnViewStatus_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Supervisor/SupervisorStatus.aspx");
    }
}