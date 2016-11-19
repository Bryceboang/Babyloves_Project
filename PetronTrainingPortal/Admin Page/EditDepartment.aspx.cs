using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_EditDepartment : System.Web.UI.Page
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
            Variables.deptNo = 0;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            lblDeptMsg.Text = string.Empty;
            lblDepartmentCmbMsg.Text = string.Empty;
            if (Variables.deptNo == 0)
            {
                lblDepartmentCmbMsg.Text = "Please select a department first.";
            }
            else
            {
                var deptList = context.Departments.Where(c => c.DepartmentName.ToLower() != cmbDepartment.Text.ToLower()).ToList();
                var checkDuplicate = deptList.FirstOrDefault(c => c.DepartmentName.ToLower() == txtDepartment.Text.ToLower());
                if (checkDuplicate != null)
                {
                    lblDeptMsg.Text = "Cannot change department name to an exisiting department.";
                }
                else
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == Variables.deptNo);
                    selectDept.DepartmentName = txtDepartment.Text;
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Department successfully edited." + "');", true);
                    Variables.deptNo = 0;
                    txtDepartment.Text = string.Empty;
                    lblDeptMsg.Text = string.Empty;
                    lblDepartmentCmbMsg.Text = string.Empty;
                }
            }
        }
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        Variables.deptNo = 0;
        txtDepartment.Text = string.Empty;
        lblDeptMsg.Text = string.Empty;
        lblDepartmentCmbMsg.Text = string.Empty;
        using (var context = new DatabaseContext())
        {
            if (string.IsNullOrEmpty(cmbDepartment.Text) == true)
            {
                lblDepartmentCmbMsg.Text = "Please select a department first.";
            }
            else
            {
                var dept = context.Departments.FirstOrDefault(c => c.DepartmentName.ToLower() == cmbDepartment.Text.ToLower());
                Variables.deptNo = dept.DepartmentId;
                txtDepartment.Text = dept.DepartmentName;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "This department is selected." + "');", true);
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Variables.deptNo = 0;
        txtDepartment.Text = string.Empty;
        lblDeptMsg.Text = string.Empty;
        lblDepartmentCmbMsg.Text = string.Empty;
    }
}