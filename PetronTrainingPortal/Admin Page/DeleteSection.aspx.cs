using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_DeleteSection : System.Web.UI.Page
{
    public void Reload()
    {
        using (var context = new DatabaseContext())
        {
            var deptList = context.Departments.OrderBy(c => c.DepartmentName).ToList();
            if (deptList.Count > 0)
            {
                foreach (var item in deptList) { cmbDepartment.Items.Add(item.DepartmentName); }
            }
        }
    }

    public void ReloadSection()
    {
        cmbSection.Items.Clear();
        using (var context = new DatabaseContext())
        {
            if (string.IsNullOrEmpty(cmbDepartment.Text) != true)
            {
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                var secList = context.Sections.OrderBy(c => c.SectionName).Where(c => c.DepartmentId == selectDept.DepartmentId);
                foreach (var item in secList) { cmbSection.Items.Add(item.SectionName); }
            }
        }

    }

    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblDepartmentMsg.Text = string.Empty;
        lblSectionMsg.Text = string.Empty;
        ReloadSection();
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
            ReloadSection();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblDepartmentMsg.Text = string.Empty;
        lblSectionMsg.Text = string.Empty;
        using (var context = new DatabaseContext())
        {
            var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
            var selectSec = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text && c.DepartmentId == selectDept.DepartmentId);

            if (selectDept == null) { lblDepartmentMsg.Text = "Please select a department first."; }
            else if (selectSec == null) { lblSectionMsg.Text = "Please select a section first."; }
            else
            {
                var checkUser = context.Users.FirstOrDefault(c => c.SectionId == selectSec.SectionId);
                var checkEmp = context.Employees.FirstOrDefault(c => c.SectionId == selectSec.SectionId);

                if (checkEmp != null || checkUser != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Cannot delete this section because some records will be affected." + "');", true);
                }
                else
                {
                    context.Sections.Remove(selectSec);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Section successfully deleted." + "');", true);
                    ReloadSection();
                }
            }
        }
    }
}