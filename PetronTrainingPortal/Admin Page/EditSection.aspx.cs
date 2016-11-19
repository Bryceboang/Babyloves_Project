using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_EditSection : System.Web.UI.Page
{
    public void Reload()
    {
        using (var context = new DatabaseContext())
        {
            var deptList = context.Departments.OrderBy(c => c.DepartmentName).ToList();
            if (deptList.Count > 0)
            {
                foreach (var item in deptList.OrderBy(c => c.DepartmentName)) { cmbDepartment.Items.Add(item.DepartmentName); }
            }
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
            Variables.secNo = 0;
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        Variables.secNo = 0;
        lblCmbDeptMsg.Text = string.Empty;
        lblSelectSecMsg.Text = string.Empty;
        txtSection.Text = string.Empty;
        lblSectionMsg.Text = string.Empty;
        using (var context = new DatabaseContext())
        {
            var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
            if (selectDept != null)
            {
                var checkSec = context.Sections.FirstOrDefault(c => c.SectionName.ToLower() == txtSelectSection.Text.ToLower() && c.DepartmentId == selectDept.DepartmentId);
                if (string.IsNullOrWhiteSpace(txtSelectSection.Text) == true) { lblSelectSecMsg.Text = "Please enter a section first."; }
                else if (checkSec == null) { lblSelectSecMsg.Text = "This section doesn't exist in this department"; }
                else
                {
                    txtSection.Text = checkSec.SectionName;
                    Variables.secNo = checkSec.SectionId;
                }
            }
            else
            {
                lblCmbDeptMsg.Text = "Please select a department first.";
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Variables.secNo = 0;
        lblCmbDeptMsg.Text = string.Empty;
        lblSelectSecMsg.Text = string.Empty;
        txtSection.Text = string.Empty;
        txtSelectSection.Text = string.Empty;
        lblSectionMsg.Text = string.Empty;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblSectionMsg.Text = string.Empty;
        txtSelectSection.Text = string.Empty;
        using (var context = new DatabaseContext())
        {
            if (Variables.secNo == 0) { txtSelectSection.Text = "Please search a section first."; }
            else
            {
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                var list = context.Sections.Where(c => c.SectionId != Variables.secNo).ToList();
                var checkDup = context.Sections.FirstOrDefault(c => c.DepartmentId == selectDept.DepartmentId && c.SectionName.ToLower() == txtSection.Text.ToLower());
                if (checkDup != null) { lblSectionMsg.Text = "This section name already exist in this department."; }
                else
                {
                    var selectSect = context.Sections.FirstOrDefault(c => c.SectionId == Variables.secNo);
                    selectSect.DepartmentId = selectDept.DepartmentId;
                    selectSect.SectionName = txtSection.Text;
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Section successfully edited." + "');", true);
                    Variables.secNo = 0;
                    lblSelectSecMsg.Text = string.Empty;
                    txtSection.Text = string.Empty;
                    txtSelectSection.Text = string.Empty;
                    lblSectionMsg.Text = string.Empty;
                }
            }
        }
    }

}