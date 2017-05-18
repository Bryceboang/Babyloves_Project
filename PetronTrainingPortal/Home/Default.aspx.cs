using PetronTrainingPortal.App_Code;
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
        Variables.checkOutCode = string.Empty;
        Variables.code = string.Empty;
        Variables.shopTrainingId = 0;
        Variables.submitCode = string.Empty;
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
    protected void btnRefineryProgram_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/RefineryEngineer.aspx");
    }
    protected void btnOtherTraining_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/OtherTraining.aspx");
    }
}