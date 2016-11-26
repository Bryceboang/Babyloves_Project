using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_EmployeeHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReloadDepartment();
        ReloadSection();
    }

    public void Reload()
    {
        using (var context = new DatabaseContext())
        {
            List<TrainingViews> trainViewList = new List<TrainingViews>();
            trainViewList.Clear();
            lblhidden.Text = string.Empty;

            var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumberSearch.Text.ToLower());
            var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
            var selectSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);

            trainViewList.Add(new TrainingViews()
            {
                DepartmentName = selectDept.DepartmentName,
                EmployeeNumber = selectEmp.EmployeeNumber,
                FullName = selectEmp.FullName,
                SectionName = selectSec.SectionName
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
                    cmbSection.Items.Add("ALL");
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
        gridEmployee.DataSource = null;
        gridEmployee.DataBind();
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

            var select = context.Employees.FirstOrDefault(c => c.EmployeeNumber == id);
            if (e.CommandName == "RemoveEmployee")
            {
                if (select != null)
                {
                    var checkExisting = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == select.EmployeeNumber);
                    var checkExistingComplete = context.CompleteEmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == select.EmployeeNumber);

                    if (checkExisting != null || checkExistingComplete != null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Cannot delete this employee because some records will be affected.');</script>"); }
                    else
                    {
                        context.Employees.Remove(select);
                        context.SaveChanges();

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The selected employee is removed.');</script>");
                        Clear();
                    }
                }
            }
            else
            {
                if (select != null)
                {
                    txtBoxEmployeeNumber.Enabled = false;
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == select.DepartmentId);
                    var selectSec = context.Sections.FirstOrDefault(c => c.SectionId == select.SectionId);

                    lblhidden.Text = select.EmployeeNumber;
                    cmbDepartment.Text = selectDept.DepartmentName;
                    cmbSection.Text = selectSec.SectionName;
                    txtFullName.Text = select.FullName;
                }
            }
        }
    }

    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadSection();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (string.IsNullOrEmpty(txtBoxEmployeeNumberSearch.Text) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please enter an employee number.');</script>");
            }
            else
            {
                var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumberSearch.Text.ToLower());
                if (selectEmp != null) { Reload(); }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This employee number doesn't exist.');</script>");
                }
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        lblhidden.Text = string.Empty;
        txtFullName.Text = string.Empty;
        txtBoxEmployeeNumberSearch.Text = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (string.IsNullOrEmpty(cmbDepartment.Text) == true) { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a department first.');</script>"); }
            else if (string.IsNullOrEmpty(cmbSection.Text) == true) { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a section first.');</script>"); }
            else
            {
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                var selectSec = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text && c.DepartmentId == selectDept.DepartmentId);
                if (string.IsNullOrEmpty(lblhidden.Text) != true)
                {
                    var list = context.Employees.Where(c => c.EmployeeNumber != lblhidden.Text).ToList();
                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == lblhidden.Text);
                    var check = list.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumber.Text.ToLower());
                    if (check != null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This employee number already exist.');</script>"); }
                    else
                    {

                        selectEmp.DepartmentId = selectDept.DepartmentId;
                        selectEmp.SectionId = selectSec.SectionId;
                        selectEmp.EmployeeNumber = txtBoxEmployeeNumber.Text;
                        selectEmp.FullName = txtFullName.Text;

                        context.SaveChanges();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Employee successfully edited.');</script>");
                        Clear();
                    }
                }
                else
                {
                    var check = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumber.Text.ToLower());
                    if (check != null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This employee number already exist.');</script>"); }
                    else
                    {
                        Employee newEmp = new Employee()
                        {
                            DepartmentId = selectDept.DepartmentId,
                            SectionId = selectSec.SectionId,
                            EmployeeNumber = txtBoxEmployeeNumber.Text,
                            FullName = txtFullName.Text
                        };

                        context.Employees.Add(newEmp);
                        context.SaveChanges();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Employee successfully added.');</script>");
                        Clear();
                    }
                }
            }
        }
    }
}