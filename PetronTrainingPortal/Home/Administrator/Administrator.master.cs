using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Administrator_Administrator : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //    if (Session["FullName"] != null)
        //    {
        //        linkbTnlogout.Visible = true;
        //        lblWelcome.Visible = true;
        //        lblFirstname.Visible = true;
        //        lblFirstname.Text = Session["EmpNo"].ToString() + ": " + Session["FullName"].ToString();
        //    }
        //    else
        //    {
        //        linkbTnlogout.Visible = false;
        //        lblWelcome.Visible = false;
        //        lblFirstname.Visible = false;
        //    }
        //}
    }

    private void Logout()
    {
        Session["EmpNo"] = null;
        Session["FullName"] = null;
        Session["AccountType"] = null;
        Session.Clear();
        Session.Abandon();

        Response.Redirect("~/Home/Login.aspx");
        lblWelcome.Text = " ";
        lblFirstname.Text = " ";
    }

    protected void linkbTnlogout_Click(object sender, EventArgs e)
    {
        Logout();
    }
}
