using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_UserHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ReloadDepartment();
            ReloadSection();
            Variables.empNo = string.Empty;
        }
    }

    public void Reload()
    {
        using (var context = new DatabaseContext())
        {
            List<TrainingViews> trainViewList = new List<TrainingViews>();
            trainViewList.Clear();
            lblhidden.Text = string.Empty;
            string deptName = string.Empty;
            string secName = string.Empty;

            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumberSearch.Text.ToLower());
            var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
            if (selectDept != null)
            {
                deptName = selectDept.DepartmentName;
            }
           
            var selectSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
            if (selectSec != null)
            {
                secName = selectSec.SectionName;
            }
            Variables.empNo = selectUser.EmployeeNumber;

            trainViewList.Add(new TrainingViews()
            {
                DepartmentName = deptName,
                EmployeeNumber = selectUser.EmployeeNumber,
                FullName = selectUser.FullName,
                SectionName = secName,
                AccessType = selectUser.AccessType,
                Email = selectUser.Email
            });

            gridEmployee.DataSource = null;
            gridEmployee.DataSource = trainViewList.ToList();
            gridEmployee.DataBind();
        }
    }

    public void ReloadDepartment()
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

                if (secList.Count() > 0)
                {
                    foreach (var item in secList) { cmbSection.Items.Add(item.SectionName); }
                }

            }
        }
    }

    public void Clear()
    {
        lblhidden.Text = string.Empty;
        txtBoxEmployeeNumberSearch.Text = string.Empty;
        txtBoxEmployeeNumber.Text = string.Empty;
        txtFullName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtPassword.Text = string.Empty;
        cmbAccessType.Text = "Supervisor";
        gridEmployee.DataSource = null;
        gridEmployee.DataBind();
        txtBoxEmployeeNumber.Enabled = true;
    }

    public void Edit(string keyword, string acess)
    {
        using (var context = new DatabaseContext())
        {
            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber.ToLower() == keyword.ToLower());

            if (acess == "Supervisor")
            {
                if (string.IsNullOrEmpty(cmbDepartment.Text) == true && cmbAccessType.Text != "Admin")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a department name first.');</script>");
                }
                else if (string.IsNullOrEmpty(cmbSection.Text) == true && cmbAccessType.Text == "Supervisor")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a section name first.');</script>");
                }
                else
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                    var selectSec = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text && c.DepartmentId == selectDept.DepartmentId);

                    selectUser.Password = txtPassword.Text;
                    selectUser.AccessType = cmbAccessType.Text;
                    selectUser.FullName = txtFullName.Text;
                    selectUser.DepartmentId = selectDept.DepartmentId;
                    selectUser.Email = txtEmail.Text;
                    selectUser.EmployeeNumber = txtBoxEmployeeNumber.Text;
                    selectUser.SectionId = selectSec.SectionId;

                    context.SaveChanges();
                    Clear();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "User successfully edited." + "');", true);
                }
            }
            else if (acess == "MANAGER")
            {
                if (string.IsNullOrEmpty(cmbDepartment.Text) == true && cmbAccessType.Text != "Admin")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a department name first." + "');", true);
                }
                else
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);

                    selectUser.Password = txtPassword.Text;
                    selectUser.AccessType = cmbAccessType.Text;
                    selectUser.FullName = txtFullName.Text;
                    selectUser.DepartmentId = selectDept.DepartmentId;
                    selectUser.Email = txtEmail.Text;
                    selectUser.EmployeeNumber = txtBoxEmployeeNumber.Text;
                    selectUser.SectionId = 0;

                    context.SaveChanges();
                    Clear();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "User successfully edited." + "');", true);
                }
            }
            else
            {
                selectUser.Password = txtPassword.Text;
                selectUser.AccessType = cmbAccessType.Text;
                selectUser.FullName = txtFullName.Text;
                selectUser.DepartmentId = 0;
                selectUser.Email = txtEmail.Text;
                selectUser.EmployeeNumber = txtBoxEmployeeNumber.Text;
                selectUser.SectionId = 0;
                context.SaveChanges();
                Clear();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "User successfully edited." + "');", true);
            }
        }
    }

    public void Save(string acess)
    {
        using (var context = new DatabaseContext())
        {

            if (acess == "Supervisor")
            {
                if (string.IsNullOrEmpty(cmbDepartment.Text) == true && cmbAccessType.Text != "Admin")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a department name first.');</script>");
                }
                else if (string.IsNullOrEmpty(cmbSection.Text) == true && cmbAccessType.Text == "Supervisor")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a section name first.');</script>");
                }
                else
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                    var selectSec = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text && c.DepartmentId == selectDept.DepartmentId);

                    User newUser = new PetronTrainingPortal.App_Code.User()
                    {
                        Password = txtPassword.Text,
                        AccessType = cmbAccessType.Text,
                        FullName = txtFullName.Text,
                        DepartmentId = selectDept.DepartmentId,
                        Email = txtEmail.Text,
                        EmployeeNumber = txtBoxEmployeeNumber.Text,
                        SectionId = selectSec.SectionId
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    Clear();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "User successfully added." + "');", true);
                }
            }
            else if (acess == "Manager")
            {
                if (string.IsNullOrEmpty(cmbDepartment.Text) == true && cmbAccessType.Text != "Admin")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a department name first." + "');", true);
                }
                else
                {
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);

                    User newUser = new PetronTrainingPortal.App_Code.User()
                    {
                        Password = txtPassword.Text,
                        AccessType = cmbAccessType.Text,
                        FullName = txtFullName.Text,
                        DepartmentId = selectDept.DepartmentId,
                        Email = txtEmail.Text,
                        EmployeeNumber = txtBoxEmployeeNumber.Text,
                        SectionId = 0
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    Clear();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "User successfully added." + "');", true);
                }
            }
            else
            {
                User newUser = new PetronTrainingPortal.App_Code.User()
                {
                    Password = txtPassword.Text,
                    AccessType = cmbAccessType.Text,
                    FullName = txtFullName.Text,
                    DepartmentId = 0,
                    Email = txtEmail.Text,
                    EmployeeNumber = txtBoxEmployeeNumber.Text,
                    SectionId = 0
                };
                context.Users.Add(newUser);
                context.SaveChanges();
                Clear();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "User successfully added." + "');", true);
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (string.IsNullOrWhiteSpace(txtBoxEmployeeNumber.Text) == true)
            {
                string x = "Please enter an employee number.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x + "');", true);
            }
            else if (string.IsNullOrWhiteSpace(txtFullName.Text) == true)
            {
                string x = "please enter a full name.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x + "');", true);
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text) == true)
            {
                string x = "please enter a password.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x + "');", true);
            }
            else
            {
                if (lblhidden.Text == string.Empty)
                {
                    var check = context.Users.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumber.Text.ToLower());
                    var checkEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumber.Text.ToLower());
                    if (check != null || checkEmp != null)
                    {
                        string x = "Cannot add duplicate employee number.";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x + "');", true);
                    }
                    else { Save(cmbAccessType.Text); }

                }
                else
                {
                    var list = context.Users.Where(c => c.EmployeeNumber != lblhidden.Text).ToList();
                    var check = list.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumber.Text.ToLower());
                    var checkEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumber.Text.ToLower());
                    if (check != null || checkEmp != null)
                    {
                        string x = "Cannot add duplicate employee number.";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + x + "');", true);
                    }
                    else { Edit(lblhidden.Text, cmbAccessType.Text); }

                }
            }

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblEmpNoMsg.Text = string.Empty;
        using (var context = new DatabaseContext())
        {
            Variables.empNo = string.Empty;
            if (string.IsNullOrEmpty(txtBoxEmployeeNumberSearch.Text) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please enter an employee number.');</script>");
            }
            else
            {
                var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumberSearch.Text.ToLower());
                if (selectUser != null) { Reload(); btnClear.Enabled = true; btnReset.Enabled = true; }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This employee number doesn't exist.');</script>");
                    lblEmpNoMsg.Text = "This employee number doesn't exist.";
                }
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        lblhidden.Text = string.Empty;
        txtBoxEmployeeNumber.Text = string.Empty;
        txtFullName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtPassword.Text = string.Empty;
        cmbAccessType.Text = "Supervisor";
        txtBoxEmployeeNumber.Enabled = true;
    }

    public void gridEmployee_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            txtBoxEmployeeNumber.Enabled = true;
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow selectedRow = gridEmployee.Rows[index];
            TableCell empNo = selectedRow.Cells[0];
            string id = empNo.Text;

            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == id);
            if (e.CommandName == "RemoveUser")
            {
                if (selectUser != null)
                {
                    var empNoSession = Session["EmpNo"].ToString().ToLower();
                    var checkExisting = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == selectUser.EmployeeNumber);
                    var checkExistingComplete = context.CompleteEmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == selectUser.EmployeeNumber);

                    if (checkExisting != null || checkExistingComplete != null)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Cannot delete this user because some records will be affected.');</script>");
                    }
                    else if (Variables.empNo.ToString().ToLower() == empNoSession)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This account is currently logged in.           Delete unsuccesful.');</script>");
                    }
                    else
                    {
                        context.Users.Remove(selectUser);
                        context.SaveChanges();

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The selected user is removed.');</script>");
                        Clear();
                        AccessType();
                    }
                }
            }
            else
            {
                if (selectUser != null)
                {
                    txtBoxEmployeeNumber.Enabled = false;
                    string deptName = string.Empty;
                    string secName = string.Empty;
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
                    var selectSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);

                    if (selectDept != null)
                    {
                        deptName = selectDept.DepartmentName;
                        cmbDepartment.Text = deptName;
                        ReloadSection();
                    }

        

                    if (selectSec != null)
                    {
                        secName = selectSec.SectionName;
                        cmbSection.Text = secName;
                    }

                    lblhidden.Text = selectUser.EmployeeNumber;
                    txtBoxEmployeeNumber.Text = selectUser.EmployeeNumber;
                    txtFullName.Text = selectUser.FullName;
                    txtEmail.Text = selectUser.Email;
                    txtPassword.Text = selectUser.Password;
   
                    cmbAccessType.Text = selectUser.AccessType;
                    AccessType();
                }
            }
        }
    }

    public void AccessType()
    {
        using (var context = new DatabaseContext())
        {
            labelDept.Visible = true;
            cmbDepartment.Visible = true;
            lblDepartmentMsg.Visible = true;

            labelSection.Visible = true;
            cmbSection.Visible = true;
            lblSectionMsg.Visible = true;

            if (cmbAccessType.Text.ToLower() == "Admin")
            {
                labelDept.Visible = false;
                cmbDepartment.Visible = false;
                lblDepartmentMsg.Visible = false;

                labelSection.Visible = false;
                cmbSection.Visible = false;
                lblSectionMsg.Visible = false;
            }
            else if (cmbAccessType.Text.ToLower() == "Manager")
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

    protected void cmbBoxAccessType_SelectedIndexChanged(object sender, EventArgs e)
    {
        AccessType();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (lblhidden.Text == string.Empty) { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please edit an employee first.');</script>"); }
            else
            {
                var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == lblhidden.Text);
                selectUser.Password = "petron10";
                context.SaveChanges();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Employee password successfully reset to petron10.');</script>");
                Clear();
            }
        }
    }
    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadSection();
    }
}