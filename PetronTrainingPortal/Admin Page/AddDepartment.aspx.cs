using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_AddDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpNo"] == null)
        {
            Response.Redirect("~/Main Page/Login.aspx");
        }
        else if (Session["AccountType"] == "Supervisor")
        {
            Response.Redirect("~/Supervisor/TrainingRegister.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Administrator only" + "');", true);
        }
        else if (Session["AccountType"] == "Manager")
        {
            Response.Redirect("~/Manager/TrainingApproval.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Administrator only" + "');", true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            lblDeptMsg.Text = string.Empty;
            var duplicate = context.Departments.FirstOrDefault(c => c.DepartmentName.ToLower() == txtDepartment.Text.ToLower());
            if (string.IsNullOrWhiteSpace(txtDepartment.Text) == true) { lblDeptMsg.Text = "Please enter a department name"; }
            else if (duplicate != null) { lblDeptMsg.Text = "Cannot add the same department name"; }
            else
            {
                Department dept = new Department()
                {
                    DepartmentName = txtDepartment.Text
                };
                context.Departments.Add(dept);
                context.SaveChanges();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Department successfully added.');</script>");
                txtDepartment.Text = string.Empty;
            }
        }
    }
}