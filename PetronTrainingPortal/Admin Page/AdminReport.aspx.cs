﻿using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_AdminReport : System.Web.UI.Page
{

    //public void Refresh()
    //{
    //    List<TrainingViews> trainViewList = new List<TrainingViews>();
    //    trainViewList.Clear();

    //    using (var context = new DatabaseContext())
    //    {
    //        var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
    //        var department = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
    //        if (training == null)
    //        {
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a training first." + "');", true);
    //        }
    //        else if (department == null)
    //        {
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a department first." + "');", true);
    //        }
    //        else
    //        {
    //            var section = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text);
    //            if (cmbSection.Text == "ALL")
    //            {
    //                var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
    //                foreach (var item in empTrainList)
    //                {
    //                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
    //                    if (selectEmp != null)
    //                    {
    //                        var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
    //                        var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
    //                        if (department.DepartmentId == empDept.DepartmentId)
    //                        {
    //                            trainViewList.Add(new TrainingViews()
    //                            {
    //                                DepartmentName = department.DepartmentName,
    //                                EmployeeNumber = item.EmployeeNumber,
    //                                FullName = selectEmp.FullName,
    //                                SectionName = selectedSec.SectionName,
    //                                Status = item.Status
    //                            });
    //                        }
    //                    }
    //                    else
    //                    {
    //                        var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
    //                        var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
    //                        var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
    //                        if (department.DepartmentId == empDept.DepartmentId)
    //                        {
    //                            trainViewList.Add(new TrainingViews()
    //                            {
    //                                DepartmentName = department.DepartmentName,
    //                                EmployeeNumber = item.EmployeeNumber,
    //                                FullName = selectUser.FullName,
    //                                SectionName = selectedSec.SectionName,
    //                                Status = item.Status
    //                            });
    //                        }
    //                    }


    //                }
    //            }
    //            else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
    //            else
    //            {
    //                var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
    //                foreach (var item in empTrainList)
    //                {
    //                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
    //                    if (selectEmp != null)
    //                    {
    //                        var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
    //                        var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
    //                        if (department.DepartmentId == empDept.DepartmentId)
    //                        {
    //                            trainViewList.Add(new TrainingViews()
    //                            {
    //                                DepartmentName = department.DepartmentName,
    //                                EmployeeNumber = item.EmployeeNumber,
    //                                FullName = selectEmp.FullName,
    //                                SectionName = selectedSec.SectionName,
    //                                Status = item.Status
    //                            });
    //                        }
    //                    }
    //                    else
    //                    {
    //                        var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
    //                        var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
    //                        var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
    //                        if (department.DepartmentId == empDept.DepartmentId)
    //                        {
    //                            trainViewList.Add(new TrainingViews()
    //                            {
    //                                DepartmentName = department.DepartmentName,
    //                                EmployeeNumber = item.EmployeeNumber,
    //                                FullName = selectUser.FullName,
    //                                SectionName = selectedSec.SectionName,
    //                                Status = item.Status
    //                            });
    //                        }
    //                    }

    //                }
    //                trainViewList = trainViewList.Where(c => c.SectionName == cmbSection.Text).ToList();
    //            }
    //        }

    //        gridView.DataSource = null;
    //        gridView.DataSource = trainViewList.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
    //        gridView.DataBind();

    //        if (cmbStatus.Text == "PENDING") { this.gridView.Columns[5].Visible = true; this.gridView.Columns[4].Visible = false; this.gridView.Columns[3].Visible = false; }
    //        else if (cmbStatus.Text == "APPROVED") { this.gridView.Columns[4].Visible = true; this.gridView.Columns[5].Visible = false; this.gridView.Columns[3].Visible = false; }
    //        else { this.gridView.Columns[3].Visible = true; this.gridView.Columns[4].Visible = false; this.gridView.Columns[5].Visible = false; }
    //    }
    //}

    public void Refresh()
    {
        List<TrainingViews> trainViewList = new List<TrainingViews>();
        trainViewList.Clear();

        using (var context = new DatabaseContext())
        {
            var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
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

                if (cmbStatus.Text == "APPROVED")
                {
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
                    else // kapag isang section lang ang selected
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
                else if (cmbStatus.Text == "PENDING")
                {
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
                    else // kapag isang section lang ang selected
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
                else // NO Status 
                {
                    if (cmbSection.Text == "ALL")
                    {
                        var listEmpTrain = context.EmployeeTrainings.Where(c => c.TrainingId == training.TrainingId).Select(c => c.EmployeeNumber).ToList();

                        var allEmp = context.Employees.Where(c => c.DepartmentId == department.DepartmentId).Select(c => c.EmployeeNumber).ToList();

                        var newListEmp = allEmp.Except(listEmpTrain).ToList();

                        foreach (var item in newListEmp)
                        {
                            var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);

                            trainViewList.Add(new TrainingViews()
                                  {
                                      DepartmentName = department.DepartmentName,
                                      EmployeeNumber = selectEmp.EmployeeNumber,
                                      FullName = selectEmp.FullName,
                                      SectionName = selectedSec.SectionName,
                                      Status = ""
                                  });
                        }

                        var selectSupervisorList = context.Users.Where(c => c.DepartmentId == department.DepartmentId && c.AccessType.ToLower() == "supervisor").Select(c => c.EmployeeNumber).ToList();

                        var newListSuper = selectSupervisorList.Except(listEmpTrain).ToList();

                        foreach (var item in newListSuper)
                        {
                            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);

                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = selectUser.EmployeeNumber,
                                FullName = selectUser.FullName,
                                SectionName = selectedSec.SectionName,
                                Status = ""
                            });
                        }

                    }
                    else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                    else // kapag isang section lang ang selected
                    {
                        
                        var listEmpTrain = context.EmployeeTrainings.Where(c => c.TrainingId == training.TrainingId).Select(c => c.EmployeeNumber).ToList();

                        var allEmp = context.Employees.Where(c => c.DepartmentId == department.DepartmentId && c.SectionId == section.SectionId).Select(c => c.EmployeeNumber).ToList();

                        var newListEmp = allEmp.Except(listEmpTrain).ToList();

                        foreach (var item in newListEmp)
                        {
                            var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);

                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = selectEmp.EmployeeNumber,
                                FullName = selectEmp.FullName,
                                SectionName = selectedSec.SectionName,
                                Status = ""
                            });
                        }

                        var selectSupervisorList = context.Users.Where(c => c.DepartmentId == department.DepartmentId && c.SectionId == section.SectionId && c.AccessType.ToLower() == "supervisor").Select(c => c.EmployeeNumber).ToList();

                        var newListSuper = selectSupervisorList.Except(listEmpTrain).ToList();

                        foreach (var item in newListSuper)
                        {
                            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);

                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = selectUser.EmployeeNumber,
                                FullName = selectUser.FullName,
                                SectionName = selectedSec.SectionName,
                                Status = ""
                            });
                        }
                    }
                }
            }

            gridView.DataSource = null;
            gridView.DataSource = trainViewList.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
            gridView.DataBind();

            if (cmbStatus.Text == "PENDING") { this.gridView.Columns[5].Visible = true; this.gridView.Columns[4].Visible = false; this.gridView.Columns[3].Visible = false; }
            else if (cmbStatus.Text == "APPROVED") { this.gridView.Columns[4].Visible = true; this.gridView.Columns[5].Visible = false; this.gridView.Columns[3].Visible = false; }
            else { this.gridView.Columns[3].Visible = true; this.gridView.Columns[4].Visible = false; this.gridView.Columns[5].Visible = false; }
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

    public void ReloadTraining()
    {
        using (var context = new DatabaseContext())
        {
            List<TrainingReportViews> trainView = new List<TrainingReportViews>();
            trainView.Clear();
            lblTrainingTitle.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtTrainingCode.Text) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please enter a training code.');</script>");
            }
            else
            {
                var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (training == null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This training code doesn't exist.');</script>");
                }
                else
                {
                    lblTrainingTitle.Text = training.TrainingTitle;


                    trainView.Add(new TrainingReportViews()
                    {
                        DateDuration = training.DateDuration,
                        TargetParticipants = training.TargetParticipants,
                        TimeDuration = training.TimeDuration,
                        TrainingProvider = training.TrainingProvider,
                        TrainingVenue = training.Venue
                    });

                }
            }

            gridTraining.DataSource = null;
            gridTraining.DataSource = trainView.ToList();
            gridTraining.DataBind();
        }
    }

    public void gridView_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (e.CommandName == "Nominate") // Kapag combobox ay no status
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridView.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[1];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (selectTrain != null)
                {
                    EmployeeTraining empTraining = new EmployeeTraining()
                    {
                        EmployeeNumber = empNo,
                        Status = "PENDING",
                        TrainingId = selectTrain.TrainingId
                    };
                    context.EmployeeTrainings.Add(empTraining);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Selected employee is now Nominated.');</script>");
                    Refresh();
                }
            }
            else if (e.CommandName == "Reject") // kapag combobox ay reject
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridView.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[1];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (selectTrain != null)
                {
                    var empTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == empNo && c.TrainingId == selectTrain.TrainingId);
                    empTrain.Status = "REJECTED";
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Selected employee status is now REJECTED.');</script>");
                    Refresh();
                }
            }
            else // kapag status nya ay pending
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridView.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[1];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (selectTrain != null)
                {
                    var empTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == empNo && c.TrainingId == selectTrain.TrainingId);
                    context.EmployeeTrainings.Remove(empTrain);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Selected employee is removed.');</script>");
                    Refresh();
                }
            }
        }
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
        gridView.DataSource = null;
        gridView.DataBind();
        Refresh();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            using (var context = new DatabaseContext())
            {
                ReloadDepartment();
                ReloadSection();
                //Refresh();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ReloadTraining();
        Refresh();
    }
}