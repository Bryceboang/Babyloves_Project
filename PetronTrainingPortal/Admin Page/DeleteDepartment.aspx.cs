using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_DeleteDepartment : System.Web.UI.Page
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
        if (!Page.IsPostBack)
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

            Reload();
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            lblCmbDeptMsg.Text = string.Empty;
            if (string.IsNullOrEmpty(cmbDepartment.Text) != true)
            {
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                var checkUser = context.Users.FirstOrDefault(c => c.DepartmentId == selectDept.DepartmentId);
                var checkEmp = context.Employees.FirstOrDefault(c => c.DepartmentId == selectDept.DepartmentId);
                var checkSec = context.Sections.FirstOrDefault(c => c.DepartmentId == selectDept.DepartmentId);

                if (checkEmp != null || checkUser != null || checkSec != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Cannot delete this department because some records will be affected." + "');", true);
                }
                else
                {
                    context.Departments.Remove(selectDept);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Department successfully deleted." + "');", true);
                    Reload();
                }
            }
            else
            {
                lblCmbDeptMsg.Text = "Please select a department first.";
            }
        }
    }
}