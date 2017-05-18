using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Manager_ManagerSubmit : System.Web.UI.Page
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
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Manager only" + "');", true);
        //}
        //else if (Session["AccountType"] == "Supervisor")
        //{
        //    Response.Redirect("~/Home/Supervisor/SupervisorList.aspx");
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Manager only" + "');", true);
        //}
        //if (Session["FullName"] != null)
        //{
        //    btnLogout.Visible = true;
        //    lblHello.Visible = true;
        //    lblName.Visible = true;
        //    lblName.Text = Session["FullName"].ToString();
        //}
        //else
        //{
        //    btnLogout.Visible = false;
        //    lblHello.Visible = false;
        //    lblName.Visible = false;
        //}
        ReloadCode(Variables.shopTrainingId, Variables.code);
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

    void ReloadCode(int id, string Code)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                string code = string.Empty;
                code = Code;
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
                ReloadGrid();
                gridDiv.Visible = true;
                gridWhole.Visible = true;
            }

        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
        }
    }

    void ReloadGrid()
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                int id = Variables.shopTrainingId;
                var nomineeList = context.Nominees.Where(c => c.ShopTrainingId == id).ToList();
                List<EmployeeNomineeViews> empList = new List<EmployeeNomineeViews>();
                empList.Clear();
                foreach (var item in nomineeList)
                {
                    var check = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                    if (check != null)
                    {
                        DateTime now = DateTime.Today;
                        Age age = new Age(check.DateHired, now);
                        string service = (age.Years + "." + age.Months).ToString();
                        empList.Add(new EmployeeNomineeViews()
                        {
                            NomineeId = item.NomineeId,
                            EmployeeNumber = item.EmployeeNumber,
                            FullName = check.FullName,
                            ServiceYears = service
                        });
                    }
                }

                gridNominee.DataSource = null;
                gridNominee.DataSource = empList.OrderBy(c => c.EmployeeNumber).ToList();
                gridNominee.DataBind();
                int count = context.Nominees.Where(c => c.ShopTrainingId == id).ToList().Count;
                lblTotalNominee.Text = count.ToString();
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
        }

    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Logout();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                string message = string.Empty;
                if (string.IsNullOrWhiteSpace(txtFullName.Text) == true)
                {
                    message = "Please enter your full name";
                }
                else
                {
                    string empNo = Session["EmpNo"].ToString();
                    var selectEmp = context.Users.FirstOrDefault(c => c.EmployeeNumber.ToLower() == empNo.ToLower());
                    if (selectEmp.FullName.ToLower() != txtFullName.Text.ToLower())
                    {
                        message = "Your full name is : " + selectEmp.FullName + ".";
                    }
                    else
                    {
                        var selectShopTraining = context.ShopTrainings.FirstOrDefault(c => c.ShopTrainingId == Variables.shopTrainingId);
                        selectShopTraining.IsConfirmedByManger = true;
                        context.SaveChanges();
                        Response.Redirect("~/Home/Manager/ManagerSuccessful.aspx");
                    }
                }

                if (message != string.Empty)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                }
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
        }
    }
}