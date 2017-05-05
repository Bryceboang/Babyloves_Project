using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Manager_ManagerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnShoppingCart_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Default.aspx");
    }
    protected void btnNominate_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Manager/ManagerNominate.aspx");
    }
    protected void btnApprove_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Manager/ManagerApprove.aspx");
    }
    protected void btnViewStatus_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Manager/ManagerStatus.aspx");
    }
}