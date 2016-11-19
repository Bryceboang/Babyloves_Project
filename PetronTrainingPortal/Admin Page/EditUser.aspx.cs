using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class EditUser : System.Web.UI.Page
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            ErrorEmpNo.Text = string.Empty;
            lblFullNameMsg.Text = string.Empty;
            lblPasswordMsg.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            lblDepartmentMsg.Text = string.Empty;
            lblSectionMsg.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbBoxAccessType.Text = "Supervisor";
            Variables.empNo = string.Empty;
            btnSave.Enabled = false;
            btnReset.Enabled = false;

            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == txtBoxEmployeeNumber.Text);
            if (string.IsNullOrWhiteSpace(txtBoxEmployeeNumber.Text) == true) { ErrorEmpNo.Text = "Please enter an employee number first."; }
            else if (selectUser == null) { ErrorEmpNo.Text = "This employee number doesn't exist"; }
            else
            {
                txtFullName.Text = selectUser.FullName;
                txtEmail.Text = selectUser.Email;
                ErrorEmpNo.Text = string.Empty;
                Variables.empNo = selectUser.EmployeeNumber;
                txtPassword.Text = selectUser.Password;
                cmbBoxAccessType.Text = selectUser.AccessType;

                btnSave.Enabled = true;
                btnReset.Enabled = true;

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

                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
                if (selectDept != null)
                {
                    cmbDepartment.Text = selectDept.DepartmentName;
                }

                var selectSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
                if (selectSec != null)
                {
                    ReloadSection(selectSec.SectionName);
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This employee number exists.');</script>");

            }
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Variables.empNo) == true)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please search an employee number first.');</script>");
            ErrorEmpNo.Text = string.Empty;
        }
        else
        {
            ErrorEmpNo.Text = string.Empty;
            txtPassword.Text = "petron10";
            Save("Password reset to petron10.");
        }
    }

    public void Clear()
    {
        lblFullNameMsg.Text = string.Empty;
        lblPasswordMsg.Text = string.Empty;
        txtFullName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        ErrorEmpNo.Text = string.Empty;
        lblDepartmentMsg.Text = string.Empty;
        lblSectionMsg.Text = string.Empty;
        txtBoxEmployeeNumber.Text = string.Empty;
        txtPassword.Text = string.Empty;
        cmbBoxAccessType.Text = "Supervisor";
        Variables.empNo = string.Empty;
        ErrorEmpNo.Text = string.Empty;
        btnSave.Enabled = false;
        btnReset.Enabled = false;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    public void Save(string x)
    {
        ErrorEmpNo.Text = string.Empty;
        lblFullNameMsg.Text = string.Empty;
        lblPasswordMsg.Text = string.Empty;
        lblDepartmentMsg.Text = string.Empty;
        lblSectionMsg.Text = string.Empty;

        using (var context = new DatabaseContext())
        {
            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == txtBoxEmployeeNumber.Text);
            if (string.IsNullOrEmpty(Variables.empNo) == true)
            {
                ErrorEmpNo.Text = "Please search an employee number first.";
            }
            else if (string.IsNullOrWhiteSpace(txtFullName.Text) == true)
            {
                lblFullNameMsg.Text = "please enter a full name.";
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text) == true)
            {
                lblPasswordMsg.Text = "please enter a password.";
            }
            else if (string.IsNullOrEmpty(cmbDepartment.Text) == true && cmbBoxAccessType.Text != "Admin")
            {
                lblDepartmentMsg.Text = "Please select a department name first.";
            }
            else if (string.IsNullOrEmpty(cmbSection.Text) == true && cmbBoxAccessType.Text == "Supervisor")
            {
                lblSectionMsg.Text = "Please select a section name first.";
            }
            else
            {
                if (cmbBoxAccessType.Text == "Admin")
                {
                    selectUser.Password = txtPassword.Text;
                    selectUser.AccessType = cmbBoxAccessType.Text;
                    selectUser.FullName = txtFullName.Text;
                    selectUser.Email = txtEmail.Text;
                    selectUser.DepartmentId = 0;
                    selectUser.SectionId = 0;
                    context.SaveChanges();
                    x = x + "                   Edit user successful.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x + "');", true);
                }
                else if (cmbBoxAccessType.Text == "Manager")
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                    selectUser.Password = txtPassword.Text;
                    selectUser.AccessType = cmbBoxAccessType.Text;
                    selectUser.FullName = txtFullName.Text;
                    selectUser.DepartmentId = selectDept.DepartmentId;
                    selectUser.Email = txtEmail.Text;
                    selectUser.SectionId = 0;
                    context.SaveChanges();
                    x = x + "                   Edit user successful.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x + "');", true);
                }
                else
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                    var selectSec = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text);

                    selectUser.Password = txtPassword.Text;
                    selectUser.AccessType = cmbBoxAccessType.Text;
                    selectUser.FullName = txtFullName.Text;
                    selectUser.DepartmentId = selectDept.DepartmentId;
                    selectUser.Email = txtEmail.Text;
                    selectUser.SectionId = selectSec.SectionId;
                    context.SaveChanges();
                    x = x + "                   Edit user successful.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x + "');", true);
                }
                Clear();

                var accountType = Session["AccountType"].ToString();
                var empNo = Session["EmpNo"].ToString();
                if (selectUser.AccessType != accountType && selectUser.EmployeeNumber == empNo)
                {
                    Session["EmpNo"] = null;
                    Session["FirstName"] = null;
                    Session["AccountType"] = null;
                    Session.Abandon();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "clearHistory", "ClearHistory();", true);

                    Response.Redirect("~/Main Page/Login.aspx");
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save("");
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