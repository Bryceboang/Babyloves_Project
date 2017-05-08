using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_TrainingSchedule : System.Web.UI.Page
{

    public void ReloadTraining()
    {
        using (var context = new DatabaseContext())
        {
            List<TrainingReportViews> trainView = new List<TrainingReportViews>();
            trainView.Clear();

            var listTraining = context.Trainings.ToList();
            foreach (var item in listTraining)
            {
                var check = context.EmployeeTrainings.FirstOrDefault(c => c.TrainingId == item.TrainingId);
                if (check != null)
                {
                    var training = context.Trainings.FirstOrDefault(c => c.TrainingId == item.TrainingId);
                    trainView.Add(new TrainingReportViews()
                    {
                        TrainingTitle = training.TrainingTitle,
                        //DateDuration = training.DateDuration,
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


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ReloadTraining();
        }
    }
}