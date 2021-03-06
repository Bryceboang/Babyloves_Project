﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Supervisor_SupervisorList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (Session["EmpNo"] == null)
            //{
            //    Response.Redirect("~/Home/Login.aspx");
            //}
            //else if (Session["AccountType"] == "Admin")
            //{
            //    Response.Redirect("~/Administrator/ReportAdmin.aspx");
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Supervisor only" + "');", true);
            //}
            //else if (Session["AccountType"] == "Manager")
            //{
            //    Response.Redirect("~/Home/Manager/ManagerList.aspx");
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Supervisor only" + "');", true);
            //}
            if (Session["FullName"] != null)
            {
                btnLogout.Visible = true;
                lblHello.Visible = true;
                lblName.Visible = true;
                lblName.Text = Session["FullName"].ToString();
            }
            else
            {
                btnLogout.Visible = false;
                lblHello.Visible = false;
                lblName.Visible = false;
            }
        }
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

    private void Logout()
    {
        Session["EmpNo"] = null;
        Session["FullName"] = null;
        Session["AccountType"] = null;
        Session.Clear();
        Session.Abandon();

        Response.Redirect("~/Home/Login.aspx");
        lblHello.Text = " ";
        lblName.Text = " ";
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Logout();
    }
}