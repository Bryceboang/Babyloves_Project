using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_TrainingApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpNo"] == null)
        {
            Response.Redirect("~/Main Page/Login.aspx");
        }
        else if (Session["AccountType"] == "Admin")
        {
            Response.Redirect("~/Admin Page/ReportAdmin.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Administrator only" + "');", true);
        }
        else if (Session["AccountType"] == "Supervisor")
        {
            Response.Redirect("~/Supervisor/TrainingRegister.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Administrator only" + "');", true);
        }

        if (!Page.IsPostBack)
        {
            using (var context = new DatabaseContext())
            {
                var empNo = Session["EmpNo"].ToString();
                var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == empNo);
                if (user != null)
                {
                    var dept = context.Departments.FirstOrDefault(c => c.DepartmentId == user.DepartmentId);
                    lblDepartment.Text = dept.DepartmentName;

                    var secList = context.Sections.Where(c => c.DepartmentId == dept.DepartmentId).ToList();
                    if (secList.Count() > 0)
                    {
                        cmbSection.Items.Add("ALL");
                        foreach (var item in secList)
                        {
                            cmbSection.Items.Add(item.SectionName);
                        }
                        cmbSection.SelectedIndex = 0;
                    }
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

    public void EmployeeReload()
    {
        using (var context = new DatabaseContext())
        {
            List<EmployeeTrainingViews> empListView = new List<EmployeeTrainingViews>();
            empListView.Clear();
            List<TrainingViews> trainListView = new List<TrainingViews>();
            trainListView.Clear();

            var empNo = Session["EmpNo"].ToString();
            var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == empNo);
            if (user != null)
            {
                var dept = context.Departments.FirstOrDefault(c => c.DepartmentId == user.DepartmentId);

                if (cmbSection.Text == "ALL")
                {
                    var secList = context.Sections.Where(c => c.DepartmentId == dept.DepartmentId).ToList();
                    foreach (var sec in secList)
                    {
                        var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                        var empTrainList = context.EmployeeTrainings.ToList();
                        var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());

                        foreach (var emp in empList)
                        {
                            foreach (var item in empTrainList)
                            {
                                if (item.EmployeeNumber == emp.EmployeeNumber && item.Status == "PENDING" && item.TrainingId == training.TrainingId)
                                {
                                    empListView.Add(new EmployeeTrainingViews()
                                    {
                                        EmployeeNumber = item.EmployeeNumber,
                                        Status = item.Status,
                                        TrainingId = item.TrainingId
                                    });
                                }
                            }
                        }

                        var userList = context.Users.Where(c => c.DepartmentId == dept.DepartmentId && c.AccessType.ToLower() == "supervisor").ToList();
                        foreach (var item in userList)
                        {
                            foreach (var empTrain in empTrainList)
                            {
                                if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.Status == "PENDING" && empTrain.TrainingId == training.TrainingId)
                                {
                                    empListView.Add(new EmployeeTrainingViews()
                                    {
                                        EmployeeNumber = item.EmployeeNumber,
                                        Status = empTrain.Status,
                                        TrainingId = empTrain.TrainingId
                                    });
                                }
                            }
                        }
                    }

                    foreach (var item in empListView)
                    {
                        var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == emp.DepartmentId && c.SectionId == emp.SectionId);
                        trainListView.Add(new TrainingViews()
                        {
                            DepartmentName = dept.DepartmentName,
                            EmployeeNumber = item.EmployeeNumber,
                            FullName = emp.FullName,
                            SectionName = sec.SectionName,
                            Status = item.Status
                        });
                    }
                }
                else
                {
                    var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == dept.DepartmentId && c.SectionName == cmbSection.Text);

                    var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                    var empTrainList = context.EmployeeTrainings.ToList();
                    var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());

                    foreach (var emp in empList)
                    {
                        foreach (var item in empTrainList)
                        {
                            if (item.EmployeeNumber == emp.EmployeeNumber && item.Status == "PENDING" && item.TrainingId == training.TrainingId)
                            {
                                empListView.Add(new EmployeeTrainingViews()
                                {
                                    EmployeeNumber = item.EmployeeNumber,
                                    Status = item.Status,
                                    TrainingId = item.TrainingId
                                });
                            }
                        }
                    }


                    var userList = context.Users.Where(c => c.DepartmentId == dept.DepartmentId && c.AccessType.ToLower() == "supervisor").ToList();
                    foreach (var item in userList)
                    {
                        foreach (var empTrain in empTrainList)
                        {
                            if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.Status == "PENDING" && empTrain.TrainingId == training.TrainingId)
                            {
                                empListView.Add(new EmployeeTrainingViews()
                                {
                                    EmployeeNumber = item.EmployeeNumber,
                                    Status = empTrain.Status,
                                    TrainingId = empTrain.TrainingId
                                });
                            }
                        }
                    }

                    foreach (var item in empListView)
                    {
                        var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        trainListView.Add(new TrainingViews()
                        {
                            DepartmentName = dept.DepartmentName,
                            EmployeeNumber = item.EmployeeNumber,
                            FullName = emp.FullName,
                            SectionName = sec.SectionName,
                            Status = item.Status
                        });
                    }
                }
            }

            gridEmployee.DataSource = null;
            gridEmployee.DataSource = trainListView.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
            gridEmployee.DataBind();
        }
    }

    public void gridEmployee_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (e.CommandName == "Approve")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridEmployee.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[0];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (selectTrain == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Search a training code first.');</script>"); }
                else
                {
                    var selectEmpTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == empNo && c.TrainingId == selectTrain.TrainingId);
                    if (selectEmpTrain != null)
                    {
                        selectEmpTrain.Status = "APPROVED";
                        context.SaveChanges();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The selected employee's status is now APPROVED.');</script>");
                    }
                }
                EmployeeReload();
            }
            else if (e.CommandName == "Decline")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridEmployee.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[0];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (selectTrain == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Search a training code first.');</script>"); }
                else
                {
                    var selectEmpTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == empNo && c.TrainingId == selectTrain.TrainingId);
                    if (selectEmpTrain != null)
                    {
                        selectEmpTrain.Status = "DECLINED";
                        context.SaveChanges();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The selected employee's status is now DECLINED.');</script>");
                    }
                }
                EmployeeReload();
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ReloadTraining();
        if (string.IsNullOrEmpty(lblTrainingTitle.Text) != true)
        {
            EmployeeReload();
        }
        else
        {
            gridEmployee.DataSource = null;
            gridEmployee.DataBind();
        }

    }

    protected void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblTrainingTitle.Text) != true)
        {
            EmployeeReload();
        }
        else
        {
            gridEmployee.DataSource = null;
            gridEmployee.DataBind();
        }
    }
}