using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Supervisor_TrainingRegister : System.Web.UI.Page
{
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
            string empNo = Session["EmpNo"].ToString();
            var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == empNo);
            if (user != null)
            {
                var dept = context.Departments.FirstOrDefault(c => c.DepartmentId == user.DepartmentId);
                var sec = context.Sections.FirstOrDefault(c => c.SectionId == user.SectionId);

                var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());

                foreach (var item in empList)
                {
                    var selectEmp = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber && c.TrainingId == training.TrainingId);
                    if (selectEmp == null)
                    {
                        var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        trainListView.Add(new TrainingViews()
                        {
                            DepartmentName = dept.DepartmentName,
                            EmployeeNumber = item.EmployeeNumber,
                            FullName = emp.FullName,
                            SectionName = sec.SectionName,
                            Status = ""
                        });
                    }
                }
            }

            gridEmployee.DataSource = null;
            gridEmployee.DataSource = trainListView.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
            gridEmployee.DataBind();
        }
    }

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
        else if (Session["AccountType"] == "Manager")
        {
            Response.Redirect("~/Manager/TrainingApproval.aspx");
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
                    var sec = context.Sections.FirstOrDefault(c => c.SectionId == user.SectionId);
                    lblDepartment.Text = dept.DepartmentName;
                    lblSection.Text = sec.SectionName;
                }
            }
        }
    }

    public void gridEmployee_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (e.CommandName == "Nominate")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridEmployee.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[0];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (selectTrain == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Search a training code first.');</script>"); }
                else
                {
                    EmployeeTraining empTrain = new EmployeeTraining()
                    {
                        EmployeeNumber = empNo,
                        Status = "PENDING",
                        TrainingId = selectTrain.TrainingId
                    };
                    context.EmployeeTrainings.Add(empTrain);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The selected employee's status is now PENDING.');</script>");

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

}