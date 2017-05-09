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

public partial class Home_Supervisor_SupervisorNominate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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

            List<ShopTraining> shopTrainingList = new List<ShopTraining>();
            using (var context = new DatabaseContext())
            {
                string empNo = string.Empty;
                shopTrainingList.Clear();
                empNo = Session["EmpNo"].ToString().ToLower();
                shopTrainingList = context.ShopTrainings.Where(c => c.EmployeeNumber.ToLower() == empNo).ToList();
                int count = 0;
                foreach (var item in shopTrainingList)
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
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
        }
    }

    protected void lnkCode_Click(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                string code = string.Empty;
                LinkButton clickedButton = (LinkButton)sender;
                code = clickedButton.Text;
                Variables.shopTrainingId = int.Parse(clickedButton.CommandName);
                Variables.code = clickedButton.CommandName;
                string header = string.Empty;
                string startMonth = string.Empty;
                string extension = string.Empty;
                int startDay = 0;
                string dateEnd = string.Empty;

                var train = context.Trainings.FirstOrDefault(c => c.TrainingCode == code);
                // create three labels and add them to the mainDiv
                // 1,2,3 are the ordinal positions of the column names, this may need corrected since I have no idea what your table looks like.

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

                var empList = context.Employees.Where(c => c.DepartmentId == deptId && c.SectionId == sectId).ToList();

                foreach (var item in nomineeList)
                {
                    var check = empList.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                    if (check != null)
                    {
                        empList.Remove(check);
                    }
                }

                List<EmployeeNomineeViews> empNomViewList = new List<EmployeeNomineeViews>();
                empNomViewList.Clear();

                foreach (var item in empList)
                {
                    DateTime now = DateTime.Today;
                    int age = now.Year - item.DateHired.Year;
                    age--;
                    int month = now.Month;
                    string service = (age + "." + month).ToString();
                    empNomViewList.Add(new EmployeeNomineeViews()
                    {
                        EmployeeNumber = item.EmployeeNumber,
                        FullName = item.FullName,
                        ServiceYears = service
                    });
                }

                gridNominee.DataSource = null;
                gridNominee.DataSource = empNomViewList.OrderBy(c => c.EmployeeNumber).ToList();
                gridNominee.DataBind();

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
                string empNo = employeeNumber.Text;
                string code = Variables.code;
                int id = Variables.shopTrainingId;

                Nominee newNominee = new Nominee()
                {
                    EmployeeNumber = empNo,
                    ShopTrainingId = id
                };
                context.Nominees.Add(newNominee);
                context.SaveChanges();
                ReloadGrid();
                int count = context.Nominees.Where(c => c.ShopTrainingId == id).ToList().Count;
                lblTotalNominee.Text = count.ToString();
            }
        }
    }

    protected void lnkAddNominee_Click(object sender, EventArgs e)
    {
        gridDiv.Visible = true;
    }
}