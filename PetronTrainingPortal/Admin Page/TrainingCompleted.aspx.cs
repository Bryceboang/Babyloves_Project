using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_TrainingCompleted : System.Web.UI.Page
{
    public void Refresh()
    {
        using (var context = new DatabaseContext())
        {
            cmbTrainingCode.Items.Clear();
            List<int> intList = new List<int>();
            intList.Clear();

            var empTrainList = context.EmployeeTrainings.ToList();
            foreach (var item in empTrainList)
            {
                var check = intList.FirstOrDefault(c => c == item.TrainingId);
                if (check == 0)
                {
                    intList.Add(item.TrainingId);
                }
            }

            foreach (var item in intList)
            {
                var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingId == item);
                cmbTrainingCode.Items.Add(selectTraining.TrainingCode);
            }



            if (intList.Count > 0)
            {
                var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingCode == cmbTrainingCode.Text);
                if (selectTraining != null)
                {
                    //txtTitle.Text = selectTraining.TrainingTitle;
                    //txtCode.Text = selectTraining.TrainingCode;
                    //txtVenue.Text = selectTraining.Venue;
                    //txtDateDuration.Text = selectTraining.DateDuration;
                    //txtTimeDuration.Text = selectTraining.TimeDuration;
                    //txtProvider.Text = selectTraining.TrainingProvider;
                    //txtParticipants.Text = selectTraining.TargetParticipants;
                }
                else
                {
                    //txtTitle.Text = string.Empty;
                    //txtCode.Text = string.Empty;
                    //txtVenue.Text = string.Empty;
                    //txtDateDuration.Text = string.Empty;
                    //txtTimeDuration.Text = string.Empty;
                    //txtProvider.Text = string.Empty;
                    //txtParticipants.Text = string.Empty;
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

            if (string.IsNullOrEmpty(cmbTrainingCode.Text) == true) { lblcmbCodeMsg.Text = "Please select a training code first."; }
            else
            {

                var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingCode == cmbTrainingCode.Text);
                var empTrainList = context.EmployeeTrainings.Where(c => c.TrainingId == selectTraining.TrainingId).ToList();
                if (empTrainList.Count > 0)
                {
                    foreach (var item in empTrainList)
                    {
                        CompleteEmployeeTraining completeTrain = new CompleteEmployeeTraining()
                        {
                            DateComplete = DateTime.Now.Date,
                            EmployeeNumber = item.EmployeeNumber,
                            Status = item.Status,
                            TrainingId = item.TrainingId
                        };
                        context.CompleteEmployeeTrainings.Add(completeTrain);

                    }

                    context.SaveChanges();

                    foreach (var item in empTrainList) { context.EmployeeTrainings.Remove(item); }
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Training successfully completed.');</script>");
                    Refresh();
                }
                else
                {
                    lblcmbCodeMsg.Text = "There are no employees registered in this training.";
                }
            }
        }
    }

    protected void cmbTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            //txtTitle.Text = string.Empty;
            //txtCode.Text = string.Empty;
            //txtVenue.Text = string.Empty;
            //txtDateDuration.Text = string.Empty;
            //txtTimeDuration.Text = string.Empty;
            //txtProvider.Text = string.Empty;
            //txtParticipants.Text = string.Empty;

            if (string.IsNullOrEmpty(cmbTrainingCode.Text) != true)
            {
                var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingCode == cmbTrainingCode.Text);
                if (selectTraining != null)
                {
                    //txtTitle.Text = selectTraining.TrainingTitle;
                    //txtCode.Text = selectTraining.TrainingCode;
                    //txtVenue.Text = selectTraining.Venue;
                    //txtDateDuration.Text = selectTraining.DateDuration;
                    //txtTimeDuration.Text = selectTraining.TimeDuration;
                    //txtProvider.Text = selectTraining.TrainingProvider;
                    //txtParticipants.Text = selectTraining.TargetParticipants;
                }
                else
                {
                    //txtTitle.Text = string.Empty;
                    //txtCode.Text = string.Empty;
                    //txtVenue.Text = string.Empty;
                    //txtDateDuration.Text = string.Empty;
                    //txtTimeDuration.Text = string.Empty;
                    //txtProvider.Text = string.Empty;
                    //txtParticipants.Text = string.Empty;
                }
            }
        }
    }
}