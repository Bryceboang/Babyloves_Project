using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_AddSection : System.Web.UI.Page
{
    public void Reload()
    {
        cmbDepartment.Items.Clear();
        using (var context = new DatabaseContext())
        {
            var deptList = context.Departments.OrderBy(c => c.DepartmentName).ToList();
            if (deptList.Count > 0) { foreach (var item in deptList) { cmbDepartment.Items.Add(item.DepartmentName); } }
        }
    }

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
        if (!Page.IsPostBack)
        {
            Reload();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            lblCmbDeptMsg.Text = string.Empty;
            if (string.IsNullOrEmpty(cmbDepartment.Text) != true)
            {
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                var duplicate = context.Sections.FirstOrDefault(c => c.DepartmentId == selectDept.DepartmentId && c.SectionName.ToLower() == txtSection.Text.ToLower());

                if (selectDept == null)
                {
                    lblCmbDeptMsg.Text = "Please select a department first.";
                }
                else
                {
                    if (duplicate != null)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Cannot accept the same section name in a department." + "');", true);
                    }
                    else
                    {
                        Section newSec = new Section()
                        {
                            DepartmentId = selectDept.DepartmentId,
                            SectionName = txtSection.Text
                        };
                        context.Sections.Add(newSec);
                        context.SaveChanges();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Section successfully added." + "');", true);
                        txtSection.Text = string.Empty;
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a department first." + "');", true);
            }
        }
    }
}