using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Supervisor_SupervisorConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["EmpNo"] == null)
        //{
        //    Response.Redirect("~/Home/Login.aspx");
        //}
        //else if (Session["AccountType"] == "Admin")
        //{
        //    Response.Redirect("~/Administrator/ReportAdmin.aspx");
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Supervisor  only" + "');", true);
        //}
        //else if (Session["AccountType"] == "Manager")
        //{
        //    Response.Redirect("~/Home/Manager/ManagerList.aspx");
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Supervisor only" + "');", true);
        //}
        if (Session["FullName"] != null)
        {
            btnLogout.Visible = true;
            lblHello.Visible = true;
            lblName.Visible = true;
            lblName.Text = Session["FullName"].ToString();
        }
        else
        {
            btnLogout.Visible = false;
            lblHello.Visible = false;
            lblName.Visible = false;
        }
        ReloadCode(null, Variables.code);
    }

    void ReloadCode(object sender, string Code)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                if (Code != string.Empty)
                {
                    string code = string.Empty;
                    string empNo = Session["EmpNo"].ToString().ToLower();
                    code = Code;
                    var selectId = context.ShopTrainings.FirstOrDefault(c => c.TrainingCode == code && c.EmployeeNumber.ToLower() == empNo);
                    Variables.shopTrainingId = selectId.ShopTrainingId;
                    Variables.code = code;
                    string header = string.Empty;
                    string startMonth = string.Empty;
                    string extension = string.Empty;
                    int startDay = 0;
                    string dateEnd = string.Empty;

                    var train = context.Trainings.FirstOrDefault(c => c.TrainingCode == code);
                    startMonth = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(train.DateStart.Date.Month);
                    startDay = train.DateStart.Date.Day;
                    dateEnd = train.DateEnd.Date.ToString("MMMM dd, yyyy");
                    header = train.TrainingCode + ":" + train.TrainingTitle + "(" + startMonth + " " + startDay + "-" + dateEnd + ")";
                    lblHeader.Text = header;
                    lblTrainingVenue.Text = train.Venue;
                    lblFacilitator.Text = train.TrainingProvider;
                    lblTarget.Text = train.TargetParticipants;
                }
                else
                {

                    string code = string.Empty;
                    LinkButton clickedButton = (LinkButton)sender;
                    code = clickedButton.Text;
                    Variables.shopTrainingId = int.Parse(clickedButton.CommandName);
                    Variables.code = code;
                    string header = string.Empty;
                    string startMonth = string.Empty;
                    string extension = string.Empty;
                    int startDay = 0;
                    string dateEnd = string.Empty;

                    var train = context.Trainings.FirstOrDefault(c => c.TrainingCode == code);
                    startMonth = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(train.DateStart.Date.Month);
                    startDay = train.DateStart.Date.Day;
                    dateEnd = train.DateEnd.Date.ToString("MMMM dd, yyyy");
                    header = train.TrainingCode + ":" + train.TrainingTitle + "(" + startMonth + " " + startDay + "-" + dateEnd + ")";
                    lblHeader.Text = header;
                    lblTrainingVenue.Text = train.Venue;
                    lblFacilitator.Text = train.TrainingProvider;
                    lblTarget.Text = train.TargetParticipants;
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    private void Logout()
    {
        Session["EmpNo"] = null;
        Session["FullName"] = null;
        Session["AccountType"] = null;
        Session.Clear();
        Session.Abandon();

        Response.Redirect("~/Home/Login.aspx");
        lblHello.Text = " ";
        lblName.Text = " ";
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Logout();
    }
}