using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_SectionHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void gridSec_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        //using (var context = new DatabaseContext())
        //{
        //    string trainingTitle = lblTrainingTitle.Text;
        //    var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingTitle == trainingTitle);
        //    if (e.CommandName == "Remove")
        //    {
        //        if (selectTrain != null)
        //        {
        //            var checkExisting = context.EmployeeTrainings.FirstOrDefault(c => c.TrainingId == selectTrain.TrainingId);
        //            var checkExistingComplete = context.CompleteEmployeeTrainings.FirstOrDefault(c => c.TrainingId == selectTrain.TrainingId);

        //            if (checkExisting != null || checkExistingComplete != null)
        //            {
        //                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Cannot delete this training because some employees are registered here.');</script>");
        //            }
        //            else
        //            {
        //                context.Trainings.Remove(selectTrain);
        //                context.SaveChanges();

        //                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('The selected training is removed.');</script>");
        //                Clear();

        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (selectTrain != null)
        //        {
        //            lblHiddenTrainingCode.Text = selectTrain.TrainingCode;
        //            txtCode.Text = selectTrain.TrainingCode;
        //            txtTitle.Text = selectTrain.TrainingTitle;
        //            txtVenue.Text = selectTrain.Venue;
        //            txtDateDuration.Text = selectTrain.DateDuration;
        //            txtTimeDuration.Text = selectTrain.TimeDuration;
        //            txtProvider.Text = selectTrain.TrainingProvider;
        //            txtParticipants.Text = selectTrain.TargetParticipants;
        //        }
        //    }
        //}
    }

}