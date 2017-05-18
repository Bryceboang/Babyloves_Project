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

public partial class Home_Manager_ManagerApprove : System.Web.UI.Page
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
        try
        {
            List<ShopTraining> shopTrainingList = new List<ShopTraining>();
            using (var context = new DatabaseContext())
            {
                string empNo = string.Empty;
                shopTrainingList.Clear();
                empNo = Session["EmpNo"].ToString().ToLower();
                int dept = Variables.deptNo;
                var empList = context.Employees.Where(c => c.DepartmentId == dept).ToList();

                //foreach (var item in collection)
                //{
                //    var selectShop = context.ShopTrainings.FirstOrDefault(c => c.EmployeeNumber == )
                //}

                var shopList = context.ShopTrainings.Where(c => c.IsSubmitted == true && c.IsConfirmedByManger == false).ToList();
                List<ShopTraining> newShopList = new List<ShopTraining>();
                newShopList.Clear();
                foreach (var item in shopList)
                {
                    var check = empList.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                    if (check != null)
                    {
                        newShopList.Add(item);
                    }
                    else
                    {
                        var checkUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        if (checkUser != null)
                        {
                            newShopList.Add(item);
                        }
                    }
                }

                int count = 0;
                foreach (var item in newShopList)
                {
                    count++;
                    string top = string.Empty;
                    if (count == 1) { top = "15px"; }
                    else { top = "30px"; }
                    HtmlGenericControl mainDiv = new HtmlGenericControl("DIV");
                    mainDiv.Attributes.Add("style", "commentBody");
                    mainDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    mainDiv.Style.Add(HtmlTextWriterStyle.MarginTop, top);

                    LinkButton lnkCode = new LinkButton();
                    lnkCode.Text = item.TrainingCode;
                    lnkCode.CommandName = item.ShopTrainingId.ToString();
                    lnkCode.ForeColor = Color.Red;
                    lnkCode.Font.Size = FontUnit.Larger;
                    lnkCode.Font.Bold = true;
                    lnkCode.Font.Underline = false;
                    lnkCode.Font.Name = "Goudy Old Style";
                    lnkCode.Click += new System.EventHandler(lnkCode_Click);
                    mainDiv.Controls.Add(lnkCode);

                    // add the mainDiv to the page somehow, these can be added to any HTML control that can act as a container. I would suggest a plain old mainDiv.
                    menuPanel.Controls.Add(mainDiv);
                }
            }

            if (!Page.IsPostBack)
            {

                if (Session["FullName"] != null)
                {
                    btnLogout.Visible = true;
                    lblHello.Visible = true;
                    lblName.Visible = true;
                    lblName.Text = Session["FullName"].ToString();
                    gridDiv.Visible = false;
                    gridWhole.Visible = false;
                }
                else
                {
                    btnLogout.Visible = false;
                    lblHello.Visible = false;
                    lblName.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
        }
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
                    gridDiv.Visible = false;
                    gridWhole.Visible = true;
                }
                else
                {

                    string code = string.Empty;
                    LinkButton clickedButton = (LinkButton)sender;
                    code = clickedButton.Text;
                    Variables.shopTrainingId = int.Parse(clickedButton.CommandName);
                    Variables.submitShopTrainingId = int.Parse(clickedButton.CommandName);
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
                    gridDiv.Visible = false;
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

                List<EmployeeNomineeViews> empNomViewList = new List<EmployeeNomineeViews>();
                empNomViewList.Clear();

                foreach (var item in nomineeList)
                {
                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                    DateTime now = DateTime.Now;
                    Age age = new Age(selectEmp.DateHired, now);
                    string service = (age.Years + "." + age.Months).ToString();
                    empNomViewList.Add(new EmployeeNomineeViews()
                    {
                        EmployeeNumber = item.EmployeeNumber,
                        Status = item.Status,
                        FullName = selectEmp.FullName,
                        ServiceYears = service
                    });
                }

                gridNominee.DataSource = null;
                gridNominee.DataSource = empNomViewList.OrderBy(c => c.EmployeeNumber).ToList();
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

    protected void lnkCode_Click(object sender, EventArgs e)
    {
        Variables.checkOutCode = string.Empty;
        ReloadCode(sender, string.Empty);
    }


    public void gridNominee_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (e.CommandName == "ConfirmEmployee")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridNominee.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[0];
                string empNo = employeeNumber.Text;
                string code = Variables.code;
                int id = Variables.shopTrainingId;


                var selectNominee = context.Nominees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == empNo.ToLower() && c.ShopTrainingId == id);
                if (selectNominee != null)
                {
                    selectNominee.Status = "For registration (for confirmation of TTD)";
                    context.SaveChanges();
                }

                ReloadGrid();
                int count = context.Nominees.Where(c => c.ShopTrainingId == id).ToList().Count;
                lblTotalNominee.Text = count.ToString();
            }
            else if (e.CommandName == "DeclineEmployee")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridNominee.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[0];
                string empNo = employeeNumber.Text;
                string code = Variables.code;
                int id = Variables.shopTrainingId;

                var selectNominee = context.Nominees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == empNo.ToLower() && c.ShopTrainingId == id);
                if (selectNominee != null)
                {
                    selectNominee.Status = "Declined";
                    context.SaveChanges();
                }
                ReloadGrid();
                int count = context.Nominees.Where(c => c.ShopTrainingId == id).ToList().Count;
                lblTotalNominee.Text = count.ToString();
            }
        }
    }

    protected void lnkConfirm_Click(object sender, EventArgs e)
    {
        gridDiv.Visible = true;
    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        //Variables.submitShopTrainingId
        Response.Redirect("~/Home/Manager/ManagerSubmit.aspx");
    }

    protected void lnkDecline_Click(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                bool yesCliked = true;

                if (yesCliked == true)
                {
                    var list = context.Nominees.Where(c => c.ShopTrainingId == Variables.shopTrainingId).ToList();
                    foreach (var item in list)
                    {
                        context.Nominees.Remove(item);
                    }
                    var selectShopTraining = context.ShopTrainings.FirstOrDefault(c => c.ShopTrainingId == Variables.shopTrainingId);
                    context.ShopTrainings.Remove(selectShopTraining);
                    context.SaveChanges();
                    gridDiv.Visible = false;
                    gridWhole.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Training declined." + "');", true);
                }
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
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