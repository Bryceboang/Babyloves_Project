using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_TrainingHome : System.Web.UI.Page
{

    public void ReloadTraining(string keyword)
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
                if (keyword != string.Empty)
                {
                    var training = context.Trainings.FirstOrDefault(c => c.TrainingCode == keyword);
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
            }

            gridTraining.DataSource = null;
            gridTraining.DataSource = trainView.ToList();
            gridTraining.DataBind();
        }
    }

    public void gridTraining_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            string trainingTitle = lblTrainingTitle.Text;
            var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingTitle == trainingTitle);
            if (e.CommandName == "Remove")
            {
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

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The selected training is removed.');</script>");
                        Clear();

                    }
                }
            }
            else
            {
                if (selectTrain != null)
                {
                    lblHiddenTrainingCode.Text = selectTrain.TrainingCode;
                    txtCode.Text = selectTrain.TrainingCode;
                    txtTitle.Text = selectTrain.TrainingTitle;
                    txtVenue.Text = selectTrain.Venue;
                    txtDateDuration.Text = selectTrain.DateDuration;
                    txtTimeDuration.Text = selectTrain.TimeDuration;
                    txtProvider.Text = selectTrain.TrainingProvider;
                    txtParticipants.Text = selectTrain.TargetParticipants;
                }
            }
        }
    }

    public void Clear()
    {
        lblHiddenTrainingCode.Text = string.Empty;
        lblTrainingTitle.Text = string.Empty;
        txtCode.Text = string.Empty;
        txtTitle.Text = string.Empty;
        txtVenue.Text = string.Empty;
        txtDateDuration.Text = string.Empty;
        txtTimeDuration.Text = string.Empty;
        txtProvider.Text = string.Empty;
        txtParticipants.Text = string.Empty;
        lblCodeMsg.Text = string.Empty;
        lblTitleMsg.Text = string.Empty;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Clear();
        ReloadTraining(string.Empty);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCode.Text = string.Empty;
        txtTitle.Text = string.Empty;
        txtVenue.Text = string.Empty;
        txtDateDuration.Text = string.Empty;
        txtTimeDuration.Text = string.Empty;
        txtProvider.Text = string.Empty;
        txtParticipants.Text = string.Empty;
        lblCodeMsg.Text = string.Empty;
        lblTitleMsg.Text = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            lblCodeMsg.Text = string.Empty;
            lblTitleMsg.Text = string.Empty;

            if (lblHiddenTrainingCode.Text != string.Empty)
            {
                var list = context.Trainings.Where(c => c.TrainingCode != lblHiddenTrainingCode.Text).ToList();
                var selectTrainTitle = list.FirstOrDefault(c => c.TrainingTitle.ToLower() == txtTitle.Text.ToLower());
                var selectTrainCode = list.FirstOrDefault(c => c.TrainingCode.ToLower() == txtCode.Text.ToLower());

                if (selectTrainCode != null) { lblCodeMsg.Text = "Cannot accept duplicate training code."; }
                else if (selectTrainTitle != null) { lblTitleMsg.Text = "Cannot accept duplicate training title."; }
                else
                {
                    var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode == lblHiddenTrainingCode.Text);
                    selectTrain.TrainingCode = txtCode.Text;
                    selectTrain.TrainingTitle = txtTitle.Text;
                    selectTrain.Venue = txtVenue.Text;
                    selectTrain.DateDuration = txtDateDuration.Text;
                    selectTrain.TimeDuration = txtTimeDuration.Text;
                    selectTrain.TrainingProvider = txtProvider.Text;
                    selectTrain.TargetParticipants = txtParticipants.Text;
                    context.SaveChanges();
                    txtCode.Text = string.Empty;
                    txtTitle.Text = string.Empty;
                    txtVenue.Text = string.Empty;
                    txtDateDuration.Text = string.Empty;
                    txtTimeDuration.Text = string.Empty;
                    txtProvider.Text = string.Empty;
                    txtParticipants.Text = string.Empty;
                    lblHiddenTrainingCode.Text = string.Empty;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Training successfully edited.');</script>");
                    ReloadTraining(selectTrain.TrainingCode);
                }
            }
            else
            {
                var selectTrainTitle = context.Trainings.FirstOrDefault(c => c.TrainingTitle.ToLower() == txtTitle.Text.ToLower());
                var selectTrainCode = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtCode.Text.ToLower());

                if (string.IsNullOrWhiteSpace(txtCode.Text) == true) { lblCodeMsg.Text = "Please enter a training code."; }
                else if (string.IsNullOrWhiteSpace(txtTitle.Text) == true) { lblTitleMsg.Text = "Please enter a training title."; }
                else if (selectTrainCode != null) { lblCodeMsg.Text = "Cannot accept duplicate training code."; }
                else if (selectTrainTitle != null) { lblTitleMsg.Text = "Cannot accept duplicate training title."; }
                else
                {
                    Training newTrain = new Training()
                    {
                        TrainingCode = txtCode.Text,
                        TrainingTitle = txtTitle.Text,
                        Venue = txtVenue.Text,
                        DateDuration = txtDateDuration.Text,
                        TimeDuration = txtTimeDuration.Text,
                        TrainingProvider = txtProvider.Text,
                        TargetParticipants = txtParticipants.Text
                    };
                    context.Trainings.Add(newTrain);
                    context.SaveChanges();
                    txtCode.Text = string.Empty;
                    txtTitle.Text = string.Empty;
                    txtVenue.Text = string.Empty;
                    txtDateDuration.Text = string.Empty;
                    txtTimeDuration.Text = string.Empty;
                    txtProvider.Text = string.Empty;
                    txtParticipants.Text = string.Empty;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Training successfully added.');</script>");
                }
            }
        }
    }
}