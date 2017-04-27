using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOnsiteTraining_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Onsite.aspx");
    }
    protected void btnInHouseTraining_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/InHouse.aspx");
    }
    protected void btnLocalTraining_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/LocalTraining.aspx");
    }
    protected void btnTrainingModules_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/TrainingModules.aspx");
    }
}