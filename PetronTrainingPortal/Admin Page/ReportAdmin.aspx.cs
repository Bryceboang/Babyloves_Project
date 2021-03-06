﻿using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class ReportAdmin : System.Web.UI.Page
{

    public void Refresh()
    {
        List<TrainingViews> trainViewList = new List<TrainingViews>();
        trainViewList.Clear();

        using (var context = new DatabaseContext())
        {
            var training = context.Trainings.FirstOrDefault(c => c.TrainingTitle == cmbTraining.Text);
            var department = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
            if (training == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a training first." + "');", true);
            }
            else if (department == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a department first." + "');", true);
            }
            else
            {
                var section = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text);
                if (cmbSection.Text == "ALL")
                {
                    var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
                    foreach (var item in empTrainList)
                    {
                        var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        if (selectEmp != null)
                        {
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
                            var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
                            if (department.DepartmentId == empDept.DepartmentId)
                            {
                                trainViewList.Add(new TrainingViews()
                                {
                                    DepartmentName = department.DepartmentName,
                                    EmployeeNumber = item.EmployeeNumber,
                                    FullName = selectEmp.FullName,
                                    SectionName = selectedSec.SectionName,
                                    Status = item.Status
                                });
                            }
                        }
                        else
                        {
                            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
                            var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
                            if (department.DepartmentId == empDept.DepartmentId)
                            {
                                trainViewList.Add(new TrainingViews()
                                {
                                    DepartmentName = department.DepartmentName,
                                    EmployeeNumber = item.EmployeeNumber,
                                    FullName = selectUser.FullName,
                                    SectionName = selectedSec.SectionName,
                                    Status = item.Status
                                });
                            }
                        }


                    }
                }
                else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                else
                {
                    var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
                    foreach (var item in empTrainList)
                    {
                        var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        if (selectEmp != null)
                        {
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
                            var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
                            if (department.DepartmentId == empDept.DepartmentId)
                            {
                                trainViewList.Add(new TrainingViews()
                                {
                                    DepartmentName = department.DepartmentName,
                                    EmployeeNumber = item.EmployeeNumber,
                                    FullName = selectEmp.FullName,
                                    SectionName = selectedSec.SectionName,
                                    Status = item.Status
                                });
                            }
                        }
                        else
                        {
                            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
                            var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
                            if (department.DepartmentId == empDept.DepartmentId)
                            {
                                trainViewList.Add(new TrainingViews()
                                {
                                    DepartmentName = department.DepartmentName,
                                    EmployeeNumber = item.EmployeeNumber,
                                    FullName = selectUser.FullName,
                                    SectionName = selectedSec.SectionName,
                                    Status = item.Status
                                });
                            }
                        }

                    }
                    trainViewList = trainViewList.Where(c => c.SectionName == cmbSection.Text).ToList();
                }
            }

            gridView.DataSource = null;
            gridView.DataSource = trainViewList.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
            gridView.DataBind();

            if (cmbStatus.Text == "APPROVED") { this.gridView.Columns[5].Visible = true; }
            else { this.gridView.Columns[5].Visible = false; }
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
            using (var context = new DatabaseContext())
            {
                var trainList = context.Trainings.OrderBy(c => c.TrainingTitle).ToList();
                if (trainList.Count > 0) { foreach (var item in trainList) { cmbTraining.Items.Add(item.TrainingTitle); } }
                ReloadDepartment();
                ReloadSection();
                Refresh();
            }
        }
    }

    protected void cmbBoxTraining_TextChanged(object sender, EventArgs e)
    {
        Refresh();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }

    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Training" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        gridView.GridLines = GridLines.Both;
        gridView.HeaderStyle.Font.Bold = true;
        gridView.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    //protected void bTnExport_Click(object sender, EventArgs e)
    //{
    //    ExportGridToExcel();
    //}

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

    public void gridView_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (e.CommandName == "Reject")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridView.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[0];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingTitle == cmbTraining.Text);
                if (selectTrain != null)
                {
                    var empTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == empNo && c.TrainingId == selectTrain.TrainingId);
                    empTrain.Status = "DECLINED";
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Selected employee status is now DECLINED.');</script>");
                    Refresh();
                }
            }
        }
    }

    protected void cmbTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        Refresh();
    }
    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadSection();
        Refresh();
    }
    protected void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        Refresh();
    }
    protected void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Refresh();
    }
}