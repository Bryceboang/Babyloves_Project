using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddUser : System.Web.UI.Page
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
            var duplicate = context.Users.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmpNo.Text.ToLower());
            var duplicateEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmpNo.Text.ToLower());
            if (duplicate != null || duplicateEmp != null)
            {
                lblEmpNoMsg.Text = "Cannot add duplicate employee number.";
            }
            else if (string.IsNullOrEmpty(cmbDepartment.Text) == true && cmbBoxAccessType.Text != "Admin")
            {
                lblDepartmentMsg.Text = "Please select a department name first.";
            }
            else if (string.IsNullOrEmpty(cmbSection.Text) == true && cmbBoxAccessType.Text != "Admin")
            {
                lblSectionMsg.Text = "Please select a section name first.";
            }
            else
            {
                if (cmbBoxAccessType.Text == "Admin")
                {
                    User newUser = new User()
                    {
                        EmployeeNumber = txtBoxEmpNo.Text,
                        Password = txtBoxPass.Text,
                        AccessType = cmbBoxAccessType.Text,
                        FullName = txtFullName.Text,
                        Email = txtEmail.Text,
                        DepartmentId = 0,
                        SectionId = 0
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                }
                else if (cmbBoxAccessType.Text == "Manager")
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                    User newUser = new User()
                    {
                        EmployeeNumber = txtBoxEmpNo.Text,
                        Password = txtBoxPass.Text,
                        AccessType = cmbBoxAccessType.Text,
                        Email = txtEmail.Text,
                        FullName = txtFullName.Text,
                        DepartmentId = selectDept.DepartmentId,
                        SectionId = 0
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                }
                else
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                    var selectSec = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text && c.DepartmentId == selectDept.DepartmentId);

                    User newUser = new User()
                    {
                        EmployeeNumber = txtBoxEmpNo.Text,
                        Password = txtBoxPass.Text,
                        AccessType = cmbBoxAccessType.Text,
                        Email = txtEmail.Text,
                        FullName = txtFullName.Text,
                        DepartmentId = selectDept.DepartmentId,
                        SectionId = selectSec.SectionId
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('User successfully added.');</script>");

                txtBoxEmpNo.Text = string.Empty;
                txtBoxPass.Text = string.Empty;
                txtFullName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                lblDepartmentMsg.Text = string.Empty;
                lblSectionMsg.Text = string.Empty;
                lblEmpNoMsg.Text = string.Empty;
                cmbBoxAccessType.Text = "Supervisor";
            }
        }
    }

    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblDepartmentMsg.Text = string.Empty;
        ReloadSection();
    }
    protected void cmbBoxAccessType_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (cmbBoxAccessType.Text == "Admin")
            {
                labelDept.Visible = false;
                cmbDepartment.Visible = false;
                lblDepartmentMsg.Visible = false;

                labelSection.Visible = false;
                cmbSection.Visible = false;
                lblSectionMsg.Visible = false;
            }
            else if (cmbBoxAccessType.Text == "Manager")
            {
                labelSection.Visible = false;
                cmbSection.Visible = false;
                lblSectionMsg.Visible = false;
            }
            else
            {
                labelDept.Visible = true;
                cmbDepartment.Visible = true;
                lblDepartmentMsg.Visible = true;

                labelSection.Visible = true;
                cmbSection.Visible = true;
                lblSectionMsg.Visible = true;
            }
        }
    }
}