using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_DepartmentHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReloadDepartment();
    }

    public void Reload()
    {
        using (var context = new DatabaseContext())
        {
            List<DepartmentViews> departmentView = new List<DepartmentViews>();
            departmentView.Clear();
            var department = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);

            departmentView.Add(new DepartmentViews()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            });

            gridDept.DataSource = null;
            gridDept.DataSource = departmentView.ToList();
            gridDept.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblHidden.Text = string.Empty;
        if (string.IsNullOrEmpty(cmbDepartment.Text) != true) { Reload(); }
        else { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a department.');</script>"); btnClear.Enabled = true; }

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

    public void gridDept_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow selectedRow = gridDept.Rows[index];
            TableCell deptId = selectedRow.Cells[0];
            int id = int.Parse(deptId.Text);

            var select = context.Departments.FirstOrDefault(c => c.DepartmentId == id);
            if (e.CommandName == "RemoveDepartment")
            {
                if (select != null)
                {
                    var checkExisting = context.Sections.FirstOrDefault(c => c.DepartmentId == select.DepartmentId);
                    var checkExistingEmp = context.Employees.FirstOrDefault(c => c.DepartmentId == select.DepartmentId);
                    var checkExistingUser = context.Users.FirstOrDefault(c => c.DepartmentId == select.DepartmentId);

                    if (checkExisting != null || checkExistingEmp != null || checkExistingUser != null)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Cannot delete this department because some records are registered here.');</script>");
                    }
                    else
                    {
                        context.Departments.Remove(select);
                        context.SaveChanges();

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The selected department is removed.');</script>");

                        gridDept.DataSource = null;
                        gridDept.DataBind();
                        ReloadDepartment();
                        txtBoxDepartment.Text = string.Empty;
                        lblHidden.Text = string.Empty;

                    }
                }
            }
            else
            {
                if (select != null) { lblHidden.Text = id.ToString(); txtBoxDepartment.Text = select.DepartmentName; }
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        lblHidden.Text = string.Empty;
        txtBoxDepartment.Text = string.Empty;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (lblHidden.Text != string.Empty)
            {
                int id = int.Parse(lblHidden.Text);
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == id);
                var list = context.Departments.Where(c => c.DepartmentId != id).ToList();
                var checkDup = list.FirstOrDefault(c => c.DepartmentName.ToLower() == txtBoxDepartment.Text.ToLower());
                if (checkDup != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The department name already exist.');</script>");
                }
                else
                {
                    selectDept.DepartmentName = txtBoxDepartment.Text;
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Department successfully edited.');</script>");
                    gridDept.DataSource = null;
                    gridDept.DataBind();
                    ReloadDepartment();
                    txtBoxDepartment.Text = string.Empty;
                    lblHidden.Text = string.Empty;
                }
            }
            else
            {
                var checkDup = context.Departments.FirstOrDefault(c => c.DepartmentName.ToLower() == txtBoxDepartment.Text.ToLower());
                if (checkDup != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The department name already exist.');</script>");
                }
                else
                {

                    Department dept = new Department();
                    dept.DepartmentName = txtBoxDepartment.Text;
                    context.Departments.Add(dept);
                    context.SaveChanges();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Department successfully added.');</script>");
                    gridDept.DataSource = null;
                    gridDept.DataBind();
                    ReloadDepartment();
                    txtBoxDepartment.Text = string.Empty;
                    lblHidden.Text = string.Empty;
                }
            }
        }
    }
}