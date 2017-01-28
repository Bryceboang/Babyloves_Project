using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_TrainingCompleted : System.Web.UI.Page
{

    public void ReloadTraining(string keyword)
    {
        using (var context = new DatabaseContext())
        {
            List<TrainingReportViews> trainView = new List<TrainingReportViews>();
            trainView.Clear();
            lblTrainingTitle.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(cmbTrainingCode.Text) == true)
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

                        ReloadEmp(training.TrainingId);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This training code doesn't exist.');</script>");
                }
            }

            gridTraining.DataSource = null;
            gridTraining.DataSource = trainView.ToList();
            gridTraining.DataBind();
        }
    }

    public void ReloadTrainingCode()
    {
        using (var context = new DatabaseContext())
        {
            var trainList = context.Trainings.OrderBy(c => c.TrainingCode).ToList();
            if (trainList.Count > 0)
            {
                foreach (var item in trainList) { cmbTrainingCode.Items.Add(item.TrainingCode); }
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

        if (!Page.IsPostBack) { ReloadTrainingCode(); }
    }


    public void ReloadEmp(int id)
    {
        using (var context = new DatabaseContext())
        {
            var list = context.EmployeeTrainings.Where(c => c.TrainingId == id).ToList();

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("EmployeeNumber"), new DataColumn("FullName"), new DataColumn("Comment") });

            foreach (var item in list)
            {
                var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                if (emp != null) { dt.Rows.Add(emp.EmployeeNumber, emp.FullName); }
                else
                {
                    var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                    if (user != null) { dt.Rows.Add(user.EmployeeNumber, user.FullName); }
                }
            }
            gridEmp.DataSource = dt;
            gridEmp.DataBind();

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            foreach (GridViewRow row in gridEmp.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[2].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string empNo = row.Cells[0].Text;
                        string comment = (row.Cells[2].FindControl("txtComment") as TextBox).Text;
                    }
                    else
                    {
                        string empNo = row.Cells[0].Text;
                        string comment = (row.Cells[2].FindControl("txtComment") as TextBox).Text;
                    }
                }
            }

            #region MyRegion
            //lblcmbCodeMsg.Text = string.Empty;

            //if (string.IsNullOrEmpty(cmbTrainingCode.Text) == true) { lblcmbCodeMsg.Text = "Please select a training code first."; }
            //else
            //{
            //    var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingCode == cmbTrainingCode.Text);
            //    var empTrainList = context.EmployeeTrainings.Where(c => c.TrainingId == selectTraining.TrainingId).ToList();
            //    if (empTrainList.Count > 0)
            //    {
            //        foreach (var item in empTrainList)
            //        {
            //            CompleteEmployeeTraining completeTrain = new CompleteEmployeeTraining()
            //            {
            //                DateComplete = DateTime.Now.Date,
            //                EmployeeNumber = item.EmployeeNumber,
            //                Status = item.Status,
            //                TrainingId = item.TrainingId
            //            };
            //            context.CompleteEmployeeTrainings.Add(completeTrain);

            //        }

            //        context.SaveChanges();

            //        foreach (var item in empTrainList) { context.EmployeeTrainings.Remove(item); }
            //        context.SaveChanges();
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Training successfully completed.');</script>");
            //        ReloadTraining(string.Empty);
            //    }
            //    else
            //    {
            //        lblcmbCodeMsg.Text = "There are no employees registered in this training.";
            //    }
            //} 
            #endregion
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ReloadTraining(cmbTrainingCode.Text);
    }

}