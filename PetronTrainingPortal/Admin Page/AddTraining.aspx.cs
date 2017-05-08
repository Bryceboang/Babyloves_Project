using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddTraining : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            lblCodeMsg.Text = string.Empty;
            lblTitleMsg.Text = string.Empty;
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
                    //DateDuration = txtDateDuration.Text,
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