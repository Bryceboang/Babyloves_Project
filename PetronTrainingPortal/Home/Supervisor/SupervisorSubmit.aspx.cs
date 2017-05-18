using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Supervisor_SupervisorSubmit : System.Web.UI.Page
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
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Supervisor only" + "');", true);
        //}
        //else if (Session["AccountType"] == "Manager")
        //{
        //    Response.Redirect("~/Home/Manager/ManagerList.aspx");
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Supervisor only" + "');", true);
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

        ReloadCode(null, Variables.submitCode);
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
                    ReloadGrid();
                    gridDiv.Visible = true;
                    gridWhole.Visible = true;
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
                    ReloadGrid();
                    gridDiv.Visible = true;
                    gridWhole.Visible = true;
                }
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
                int deptId = Variables.deptNo;
                int sectId = Variables.secNo;
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

    public void gridNominee_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (e.CommandName == "NominateEmployee")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridNominee.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[0];
                string empNo = employeeNumber.Text.ToLower();
                string code = Variables.code;
                int id = Variables.shopTrainingId;

                var selectNom = context.Nominees.FirstOrDefault(c => c.ShopTrainingId == Variables.shopTrainingId && c.EmployeeNumber.ToLower() == empNo);
                context.Nominees.Remove(selectNom);
                context.SaveChanges();
                ReloadGrid();
                int count = context.Nominees.Where(c => c.ShopTrainingId == id).ToList().Count;
                lblTotalNominee.Text = count.ToString();
            }
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                string fullName = txtFullName.Text;
                if (string.IsNullOrWhiteSpace(fullName) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please enter your full name." + "');", true);
                }
                else
                {
                    string empNo = Session["EmpNo"].ToString().ToLower();

                    var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber.ToLower() == empNo);
                    if (selectUser != null)
                    {
                        if (selectUser.FullName == fullName)
                        {
                            var selectShopTraining = context.ShopTrainings.FirstOrDefault(c => c.ShopTrainingId == Variables.shopTrainingId);
                            selectShopTraining.IsSubmitted = true;


                            var nomList = context.Nominees.Where(c => c.ShopTrainingId == Variables.shopTrainingId).ToList();

                            foreach (var item in nomList)
                            {
                                item.Status = "On Waiting List";
                            }

                            context.SaveChanges();
                            Response.Redirect("~/Home/Supervisor/SupervisorConfirmation.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Your fullname is: " + selectUser.FullName + "');", true);
                        }
                    }
                }

            }
        }
        catch (Exception)
        {

            //throw;
        }
    }
}