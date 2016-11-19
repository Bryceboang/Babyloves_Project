using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_AddEmployee : System.Web.UI.Page
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
            ReloadSection();
        }
    }
 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            lblSectionMsg.Text = string.Empty;
            lblDepartmentMsg.Text = string.Empty;
            lblEmpNoMsg.Text = string.Empty;
            if (string.IsNullOrEmpty(cmbDepartment.Text) == true)
            {
                lblDepartmentMsg.Text = "Please select a department name first.";
            }
            else if (string.IsNullOrEmpty(cmbSection.Text) == true)
            {
                lblSectionMsg.Text = "Please select a section name first.";
            }
            else
            {
                var checkDuplicate = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmpNo.Text.ToLower());
                var checkDuplicateUser = context.Users.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmpNo.Text.ToLower());

                if (checkDuplicate != null || checkDuplicateUser != null)
                {
                    lblEmpNoMsg.Text = "Cannot accept duplicate employee number.";
                }
                else
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                    var selectSec = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text && c.DepartmentId == selectDept.DepartmentId);

                    Employee newEmp = new Employee()
                    {
                        EmployeeNumber = txtBoxEmpNo.Text,
                        FullName = txtFullName.Text,
                        DepartmentId = selectDept.DepartmentId,
                        SectionId = selectSec.SectionId
                    };
                    context.Employees.Add(newEmp);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Employee successfully added.');</script>");
                    txtBoxEmpNo.Text = string.Empty;
                    txtFullName.Text = string.Empty;
                }

            }
        }
    }
    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblDepartmentMsg.Text = string.Empty;
        ReloadSection();
    }
}