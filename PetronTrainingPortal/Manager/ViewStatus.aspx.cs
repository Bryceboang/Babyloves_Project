using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ViewStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpNo"] == null)
        {
            Response.Redirect("~/Main Page/Login.aspx");
        }
        else if (Session["AccountType"] == "Admin")
        {
            Response.Redirect("~/Admin Page/AdminReport.aspx");
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
                    var secList = context.Sections.Where(c => c.DepartmentId == dept.DepartmentId);
                    foreach (var sec in secList)
                    {
                        var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                        var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());

                        foreach (var item in empList)
                        {
                            var selectEmpTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber && c.TrainingId == training.TrainingId);
                            if (selectEmpTrain != null)
                            {
                                var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                                trainListView.Add(new TrainingViews()
                                {
                                    DepartmentName = dept.DepartmentName,
                                    EmployeeNumber = item.EmployeeNumber,
                                    FullName = emp.FullName,
                                    SectionName = sec.SectionName,
                                    Status = selectEmpTrain.Status
                                });
                            }
                        }

                        var userList = context.Users.Where(c => c.DepartmentId == dept.DepartmentId && c.AccessType.ToLower() == "supervisor").ToList();
                        foreach (var item in userList)
                        {
                            var selectEmpTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber && c.TrainingId == training.TrainingId);
                            if (selectEmpTrain != null)
                            {
                                var checkDup = trainListView.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                                if (checkDup == null)
                                {
                                    var userSelect = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                                    trainListView.Add(new TrainingViews()
                                    {
                                        DepartmentName = dept.DepartmentName,
                                        EmployeeNumber = item.EmployeeNumber,
                                        FullName = userSelect.FullName,
                                        SectionName = sec.SectionName,
                                        Status = selectEmpTrain.Status
                                    });
                                }
                            }
                        }
                    }
                }
                else
                {
                    var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == dept.DepartmentId && c.SectionName == cmbSection.Text);

                    var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                    var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());

                    foreach (var item in empList)
                    {
                        var selectEmpTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber && c.TrainingId == training.TrainingId);
                        if (selectEmpTrain != null)
                        {
                            var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            trainListView.Add(new TrainingViews()
                            {
                                DepartmentName = dept.DepartmentName,
                                EmployeeNumber = item.EmployeeNumber,
                                FullName = emp.FullName,
                                SectionName = sec.SectionName,
                                Status = selectEmpTrain.Status
                            });
                        }
                    }

                    var userList = context.Users.Where(c => c.SectionId == sec.SectionId && c.AccessType.ToLower() == "supervisor").ToList();
                    foreach (var item in userList)
                    {
                        var selectEmpTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber && c.TrainingId == training.TrainingId);
                        if (selectEmpTrain != null)
                        {
                            var checkDup = trainListView.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            if (checkDup == null)
                            {
                                var userSelect = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                                trainListView.Add(new TrainingViews()
                                {
                                    DepartmentName = dept.DepartmentName,
                                    EmployeeNumber = item.EmployeeNumber,
                                    FullName = userSelect.FullName,
                                    SectionName = sec.SectionName,
                                    Status = selectEmpTrain.Status
                                });
                            }
                        }
                    }
                }
            }

            gridEmployee.DataSource = null;
            gridEmployee.DataSource = trainListView.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
            gridEmployee.DataBind();
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