using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_SectionHome : System.Web.UI.Page
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
            List<SectionViews> sectionView = new List<SectionViews>();
            sectionView.Clear();
            var department = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
            var section = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text && c.DepartmentId == department.DepartmentId);
            lblHidden.Text = department.DepartmentId.ToString();
            sectionView.Add(new SectionViews()
            {
                DepartmentId = section.DepartmentId,
                SectionId = section.SectionId,
                SectionName = section.SectionName,
                DepartmentName = department.DepartmentName
            });

            gridSec.DataSource = null;
            gridSec.DataSource = sectionView.ToList();
            gridSec.DataBind();
        }
    }

    public void ReloadDepartment()
    {
        using (var context = new DatabaseContext())
        {
            var deptList = context.Departments.OrderBy(c => c.DepartmentName).ToList();
            if (deptList.Count > 0)
            {
                foreach (var item in deptList) { cmbDepartment.Items.Add(item.DepartmentName); cmbSelectDepartment.Items.Add(item.DepartmentName); }
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

                if (secList.Count() > 0) { foreach (var item in secList) { cmbSection.Items.Add(item.SectionName); } }
            }
        }
    }

    public void gridSec_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            cmbSelectDepartment.Enabled = true;

            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow selectedRow = gridSec.Rows[index];
            TableCell secId = selectedRow.Cells[0];
            int id = int.Parse(secId.Text);
      
            var select = context.Sections.FirstOrDefault(c => c.SectionId == id);
            if (e.CommandName == "RemoveSection")
            {
                if (select != null)
                {
                    var checkExisting = context.Employees.FirstOrDefault(c => c.SectionId == select.SectionId);
                    var checkExistingUser = context.Users.FirstOrDefault(c => c.SectionId == select.SectionId);

                    if (checkExisting != null || checkExistingUser != null)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Cannot delete this section because some employees are registered here.');</script>");
                    }
                    else
                    {
                        context.Sections.Remove(select);
                        context.SaveChanges();

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The selected section is removed.');</script>");
                        ReloadSection();
                        lblHidden.Text = string.Empty;
                        txtBoxSection.Text = string.Empty;
                        gridSec.DataSource = null;
                        gridSec.DataBind();
                    }
                }
            }
            else
            {
                if (select != null)
                {
                    cmbSelectDepartment.Enabled = false;
                    var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == select.DepartmentId);
                    lblHidden.Text = id.ToString();
                    cmbSelectDepartment.Text = selectDept.DepartmentName;
                    //txtBoxDept.Enabled = true;
                    //txtBoxDept.Text = selectDept.DepartmentName;
                    txtBoxSection.Text = select.SectionName;
                }
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        lblHidden.Text = string.Empty;
        cmbSelectDepartment.Enabled = true;
        //txtBoxDept.Enabled = false;
        txtBoxSection.Text = string.Empty;
        txtBoxSection.Text = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (lblHidden.Text != string.Empty)
            {
                var dept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                if (dept == null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a department first.');</script>");
                }
                else
                {
                    int id = int.Parse(lblHidden.Text);
                    var list = context.Sections.Where(c => c.SectionId != id).ToList();
                    var selectSec = context.Sections.FirstOrDefault(c => c.SectionId == id);
                    var check = list.FirstOrDefault(c => c.SectionName.ToLower() == txtBoxSection.Text.ToLower() && c.DepartmentId == dept.DepartmentId);
                    if (check != null)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This section name already exist in this department.');</script>");
                    }
                    else
                    {
                        selectSec.SectionName = txtBoxSection.Text;
                        context.SaveChanges();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Section successfully edited.');</script>");
                        lblHidden.Text = string.Empty;
                        cmbSelectDepartment.Enabled = true;
                        txtBoxSection.Text = string.Empty;
                    }
                }
            }
            else
            {
                var dept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                if (dept == null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a department first.');</script>");
                }
                else
                {
                    var check = context.Sections.FirstOrDefault(c => c.SectionName.ToLower() == txtBoxSection.Text.ToLower() && c.DepartmentId == dept.DepartmentId);
                    if (check != null)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This section name already exist in this department.');</script>");
                    }
                    else
                    {
                        Section newSec = new Section()
                        {
                            DepartmentId = dept.DepartmentId,
                            SectionName = txtBoxSection.Text
                        };
                        context.Sections.Add(newSec);
                        context.SaveChanges();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Section successfully added.');</script>");

                        lblHidden.Text = string.Empty;
                        cmbSelectDepartment.Enabled = true;
                        txtBoxSection.Text = string.Empty;
                    }
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(cmbSection.Text) == true)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a section first.');</script>");
        }
        else { Reload(); }
    }
    
    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadSection();
    }
}