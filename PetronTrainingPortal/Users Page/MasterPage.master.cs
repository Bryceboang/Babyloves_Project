using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpNo"] != null)
        {
            linkbTnlogout.Visible = true;
            lblWelcome.Visible = true;
            lblFirstname.Visible = true;
            lblFirstname.Text = Session["EmpNo"].ToString();
        }
        else if (Session["FirstName"] != null)
        {
            linkbTnlogout.Visible = true;
            lblWelcome.Visible = true;
            lblFirstname.Visible = true;
            lblFirstname.Text = Session["FirstName"].ToString();
        }
        else
        {
            linkbTnlogout.Visible = false;
            lblWelcome.Visible = false;
            lblFirstname.Visible = false;
        }
    }

    private void Logout()
    {
        Session["EmpNo"] = null;
        Session["FirstName"] = null;
        Session["AccountType"] = null;
        Session.Clear();
        Session.Abandon();

        Response.Redirect("~/Main Page/Login.aspx");
        lblWelcome.Text = " ";
        lblFirstname.Text = " ";
    }

    protected void linkbTnlogout_Click(object sender, EventArgs e)
    {
        Logout();
    }

    //protected void linkBtnChangePass_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Users Page/ChangePassword.aspx");
    //}
}
