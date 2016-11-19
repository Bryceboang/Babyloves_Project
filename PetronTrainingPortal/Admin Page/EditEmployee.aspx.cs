using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_EditEmployee : System.Web.UI.Page
{
    public void Reload()
    {
        using (var context = new DatabaseContext())
        {
            var deptList = context.Departments.OrderBy(c => c.DepartmentName).ToList();
            if (deptList.Count > 0) { foreach (var item in deptList) { cmbDepartment.Items.Add(item.DepartmentName); } }
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

    public void ReloadSection(string text)
    {
        cmbSection.Items.Clear();
        using (var context = new DatabaseContext())
        {
            if (string.IsNullOrEmpty(cmbDepartment.Text) != true)
            {
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                var secList = context.Sections.Where(c => c.DepartmentId == selectDept.DepartmentId);
                foreach (var item in secList) { cmbSection.Items.Add(item.SectionName); }
                cmbSection.Text = text;
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
            Variables.empNo = string.Empty;
            Reload();
            ReloadSection();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblSectionMsg.Text = string.Empty;
        lblDepartmentMsg.Text = string.Empty;
        lblEmpNoMsg.Text = string.Empty;
        Variables.empNo = string.Empty;

        using (var context = new DatabaseContext())
        {
            var checkEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumber.Text.ToLower());
            if (checkEmp == null) { lblEmpNoMsg.Text = "This employee number doesn't exist."; }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This employee number exist.');</script>");
                txtFullName.Text = checkEmp.FullName;
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == checkEmp.DepartmentId);
                var selectSec = context.Sections.FirstOrDefault(c => c.SectionId == checkEmp.SectionId);
                cmbDepartment.Text = selectDept.DepartmentName;
                Variables.empNo = checkEmp.EmployeeNumber;
                ReloadSection(selectSec.SectionName);
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        lblSectionMsg.Text = string.Empty;
        lblDepartmentMsg.Text = string.Empty;
        lblEmpNoMsg.Text = string.Empty;
        txtBoxEmployeeNumber.Text = string.Empty;
        txtFullName.Text = string.Empty;
        Variables.empNo = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            lblSectionMsg.Text = string.Empty;
            lblDepartmentMsg.Text = string.Empty;
            lblEmpNoMsg.Text = string.Empty;
            if (string.IsNullOrEmpty(cmbDepartment.Text) == true) { lblDepartmentMsg.Text = "Please select a department name first."; }
            else if (string.IsNullOrEmpty(cmbSection.Text) == true) { lblSectionMsg.Text = "Please select a section name first."; }
            else if (string.IsNullOrEmpty(Variables.empNo) == true) { lblEmpNoMsg.Text = "Please search an employee number first."; }
            else
            {
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                var selectSec = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text && c.DepartmentId == selectDept.DepartmentId);
                var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == Variables.empNo.ToLower());
                emp.FullName = txtFullName.Text;
                emp.DepartmentId = selectDept.DepartmentId;
                emp.SectionId = selectSec.SectionId;
                context.SaveChanges();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Employee details sucessfully edited.');</script>");
                txtBoxEmployeeNumber.Text = string.Empty;
                txtFullName.Text = string.Empty;
                Variables.empNo = string.Empty;
            }
        }
    }
    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadSection();
    }
}