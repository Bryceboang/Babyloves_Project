using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteTraining : System.Web.UI.Page
{
    public void Refresh()
    {
        using (var context = new DatabaseContext())
        {
            List<TrainingReportViews> trainView = new List<TrainingReportViews>();
            trainView.Clear();

            lblTrainingTitle.Text = string.Empty;
            var trainingSelect = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
            if (trainingSelect != null)
            {
                lblTrainingTitle.Text = trainingSelect.TrainingTitle;

                trainView.Add(new TrainingReportViews()
                {
                    //DateDuration = trainingSelect.DateDuration,
                    TargetParticipants = trainingSelect.TargetParticipants,
                    TimeDuration = trainingSelect.TimeDuration,
                    TrainingProvider = trainingSelect.TrainingProvider,
                    TrainingVenue = trainingSelect.Venue
                });

                gridTraining.DataSource = null;
                gridTraining.DataSource = trainView.ToList();
                gridTraining.DataBind();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please enter a training code first." + "');", true);
            }
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
            //Refresh();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (string.IsNullOrEmpty(txtTrainingCode.Text) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please select a training to deleted.');</script>");
            }
            else
            {
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode == txtTrainingCode.Text);
                var checkExisting = context.EmployeeTrainings.FirstOrDefault(c => c.TrainingId == selectTrain.TrainingId);
                var checkExistingComplete = context.CompleteEmployeeTrainings.FirstOrDefault(c => c.TrainingId == selectTrain.TrainingId);

                if (checkExisting != null || checkExistingComplete != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Cannot delete this training because some employees are registered here.');</script>");
                }
                else
                {
                    context.Trainings.Remove(selectTrain);
                    context.SaveChanges();
                    Refresh();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Training successfully deleted.');</script>");
                }
            }
        }
    }

    public void gridTraining_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (e.CommandName == "Remove") 
            {
                string title = lblTrainingTitle.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingTitle == title);
                if (selectTrain != null)
                {
                    var checkExisting = context.EmployeeTrainings.FirstOrDefault(c => c.TrainingId == selectTrain.TrainingId);
                    var checkExistingComplete = context.CompleteEmployeeTrainings.FirstOrDefault(c => c.TrainingId == selectTrain.TrainingId);

                    if (checkExisting != null || checkExistingComplete != null)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Cannot delete this training because some employees are registered here.');</script>");
                    }
                    else
                    {
                        context.Trainings.Remove(selectTrain);
                        context.SaveChanges();
                        Refresh();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Training successfully deleted.');</script>");
                    }
                }
                else { }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Refresh();
    }

}