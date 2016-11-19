using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditTraining : System.Web.UI.Page
{
    public void Refresh()
    {
        using (var context = new DatabaseContext())
        {
            cmbTrainingCode.Items.Clear();
            var trainingList = context.Trainings.OrderBy(c => c.TrainingTitle).ToList();
            foreach (var item in trainingList) { cmbTrainingCode.Items.Add(item.TrainingCode); }
            if (trainingList.Count > 0)
            {
                var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingCode == cmbTrainingCode.Text);
                if (selectTraining != null)
                {
                    txtTitle.Text = selectTraining.TrainingTitle;
                    txtCode.Text = selectTraining.TrainingCode;
                    txtVenue.Text = selectTraining.Venue;
                    txtDateDuration.Text = selectTraining.DateDuration;
                    txtTimeDuration.Text = selectTraining.TimeDuration;
                    txtProvider.Text = selectTraining.TrainingProvider;
                    txtParticipants.Text = selectTraining.TargetParticipants;
                }
                else
                {
                    txtTitle.Text = string.Empty;
                    txtCode.Text = string.Empty;
                    txtVenue.Text = string.Empty;
                    txtDateDuration.Text = string.Empty;
                    txtTimeDuration.Text = string.Empty;
                    txtProvider.Text = string.Empty;
                    txtParticipants.Text = string.Empty;
                }
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

        if (!Page.IsPostBack) { Refresh(); }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            lblcmbCodeMsg.Text = string.Empty;
            lbltxtCodeMsg.Text = string.Empty;
            lblTitleMsg.Text = string.Empty;

            var list = context.Trainings.Where(c => c.TrainingCode != cmbTrainingCode.Text).ToList();
            var selectTrainTitle = list.FirstOrDefault(c => c.TrainingTitle.ToLower() == txtTitle.Text.ToLower());
            var selectTrainCode = list.FirstOrDefault(c => c.TrainingCode.ToLower() == txtCode.Text.ToLower());

            if (string.IsNullOrEmpty(cmbTrainingCode.Text) == true) { lblcmbCodeMsg.Text = "Please select a training code first."; }
            else if (selectTrainCode != null) { lbltxtCodeMsg.Text = "Cannot accept duplicate training code."; }
            else if (selectTrainTitle != null) { lblTitleMsg.Text = "Cannot accept duplicate training title."; }
            else
            {
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode == cmbTrainingCode.Text);
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Training successfully edited.');</script>");
                Refresh();
            }
        }
    }

    protected void cmbTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            txtTitle.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtVenue.Text = string.Empty;
            txtDateDuration.Text = string.Empty;
            txtTimeDuration.Text = string.Empty;
            txtProvider.Text = string.Empty;
            txtParticipants.Text = string.Empty;

            if (string.IsNullOrEmpty(cmbTrainingCode.Text) != true)
            {
                var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingCode == cmbTrainingCode.Text);
                if (selectTraining != null)
                {
                    txtTitle.Text = selectTraining.TrainingTitle;
                    txtCode.Text = selectTraining.TrainingCode;
                    txtVenue.Text = selectTraining.Venue;
                    txtDateDuration.Text = selectTraining.DateDuration;
                    txtTimeDuration.Text = selectTraining.TimeDuration;
                    txtProvider.Text = selectTraining.TrainingProvider;
                    txtParticipants.Text = selectTraining.TargetParticipants;
                }
                else
                {
                    txtTitle.Text = string.Empty;
                    txtCode.Text = string.Empty;
                    txtVenue.Text = string.Empty;
                    txtDateDuration.Text = string.Empty;
                    txtTimeDuration.Text = string.Empty;
                    txtProvider.Text = string.Empty;
                    txtParticipants.Text = string.Empty;
                }
            }
        }
    }
}