using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
        //if (!Page.IsPostBack)
        //{
        try
        {
            if (Session["FullName"] != null)
            {
                btnLogout.Visible = true;
                lblHello.Visible = true;
                lblName.Visible = true;
                lblName.Text = Session["FullName"].ToString();
                using (var context = new DatabaseContext())
                {
                    string empNo = string.Empty;
                    empNo = Session["EmpNo"].ToString().ToLower();
                    var shopTraning = context.ShopTrainings.FirstOrDefault(c => c.ShopTrainingId == Variables.shopTrainingId);
                    int count = 0;

                    count++;
                    string top = string.Empty;
                    if (count == 1) { top = "15px"; }
                    else { top = "30px"; }
                    HtmlGenericControl mainDiv = new HtmlGenericControl("DIV");
                    mainDiv.Attributes.Add("style", "commentBody");
                    mainDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    mainDiv.Style.Add(HtmlTextWriterStyle.MarginTop, top);

                    LinkButton lnkCode = new LinkButton();
                    lnkCode.Text = shopTraning.TrainingCode;
                    lnkCode.CommandName = shopTraning.ShopTrainingId.ToString();
                    lnkCode.ForeColor = Color.Red;
                    lnkCode.Font.Size = FontUnit.Larger;
                    lnkCode.Font.Bold = true;
                    lnkCode.Font.Underline = false;
                    lnkCode.Font.Name = "Goudy Old Style";
                    lnkCode.Click += new System.EventHandler(lnkCode_Click);
                    mainDiv.Controls.Add(lnkCode);
                    ReloadCode(Variables.shopTrainingId, Variables.code);
                    // add the mainDiv to the page somehow, these can be added to any HTML control that can act as a container. I would suggest a plain old mainDiv.
                    menuPanel.Controls.Add(mainDiv);
                }
            }
            else
            {
                btnLogout.Visible = false;
                lblHello.Visible = false;
                lblName.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    protected void lnkCode_Click(object sender, EventArgs e)
    {
        try
        {

            Variables.checkOutCode = string.Empty;
            ReloadCode(sender, string.Empty);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    void ReloadCode(object sender, string Code)
    {
        try
        {
            using (var context = new DatabaseContext())
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
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
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
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
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

                        var listnom = context.Nominees.Where(c => c.ShopTrainingId == Variables.shopTrainingId).ToList();
                        if (listnom.Count() > 0)
                        {
                            if (selectShopTraining.EmployeeNumber != empNo)
                            {
                                selectShopTraining.IsConfirmedByManger = true;
                            }
                            else
                            {
                                selectShopTraining.IsSubmitted = true;
                                selectShopTraining.IsConfirmedByManger = true;

                                var list = context.Nominees.Where(c => c.ShopTrainingId == Variables.shopTrainingId).ToList();
                                foreach (var item in list)
                                {
                                    item.Status = "For registration (for confirmation of TTD)";
                                }
                            }

                            context.SaveChanges();
                            Response.Redirect("~/Home/Manager/ManagerSuccessful.aspx");
                        }
                        else { message = "There are no nominees in this training. Please nominate an employee first."; }
                    }
                }

                if (message != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertInfo('" + message + "');", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    public void gridNominee_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }
}