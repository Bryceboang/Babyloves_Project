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

public partial class Home_Manager_ManagerStatus : System.Web.UI.Page
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
            using (var context = new DatabaseContext())
            {
                string empNo = string.Empty;
                empNo = Session["EmpNo"].ToString().ToLower();
                int count = 0;
                int dept = Variables.deptNo;
                Section selectSect = new Section();
                List<ShopTraining> shopList = new List<ShopTraining>();
                shopList.Clear();

                menuPanel.Controls.Clear();
                List<Section> sectionList = new List<Section>();
                sectionList.Clear();
                sectionList = context.Sections.Where(c => c.DepartmentId == dept).ToList();

                foreach (var sec in sectionList)
                {
                    shopList = context.ShopTrainings.Where(c => c.IsConfirmedByManger == true && c.SectionId == sec.SectionId).ToList();

                    if (shopList.Count() > 0)
                    {
                        HtmlGenericControl Div = new HtmlGenericControl("DIV");
                        Div.Attributes.Add("style", "commentBody");
                        Div.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                        Div.Style.Add(HtmlTextWriterStyle.MarginTop, "20px");

                        HtmlGenericControl lblHeader = new HtmlGenericControl("Label");
                        lblHeader.Style.Add(HtmlTextWriterStyle.Color, "Blue");
                        lblHeader.Style.Add(HtmlTextWriterStyle.Height, "100px");
                        lblHeader.Style.Add(HtmlTextWriterStyle.MarginLeft, "15px");
                        lblHeader.Style.Add(HtmlTextWriterStyle.MarginTop, "15px");
                        lblHeader.Style.Add(HtmlTextWriterStyle.FontSize, "20px");
                        lblHeader.Style.Add(HtmlTextWriterStyle.FontFamily, "Corbel");
                        lblHeader.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                        lblHeader.InnerHtml = sec.SectionName;
                        Div.Controls.Add(lblHeader);
                        Div.Controls.Add(new LiteralControl("<br />"));

                        foreach (var item in shopList)
                        {
                            count++;
                            string top = string.Empty;
                            if (count == 1) { top = "17px"; }
                            else { top = "17px"; }
                            HtmlGenericControl mainDiv = new HtmlGenericControl("DIV");
                            mainDiv.Attributes.Add("style", "commentBody");
                            mainDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "30px");
                            mainDiv.Style.Add(HtmlTextWriterStyle.MarginTop, top);

                            LinkButton lnkCode = new LinkButton();
                            lnkCode.Text = item.TrainingCode;
                            lnkCode.CommandName = item.ShopTrainingId.ToString();
                            lnkCode.ID = sec.SectionId.ToString() + "-" + count;
                            lnkCode.ForeColor = Color.Red;
                            lnkCode.Font.Size = FontUnit.Larger;
                            lnkCode.Font.Bold = true;
                            lnkCode.Font.Underline = false;
                            lnkCode.Font.Name = "Goudy Old Style";
                            lnkCode.Click += new System.EventHandler(lnkCode_Click);
                            mainDiv.Controls.Add(lnkCode);
                            Div.Controls.Add(mainDiv);

                            // add the mainDiv to the page somehow, these can be added to any HTML control that can act as a container. I would suggest a plain old mainDiv.
                            menuPanel.Controls.Add(Div);
                        }
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

                        if (Variables.checkOutCode != string.Empty)
                        {
                            ReloadCode(null, Variables.checkOutCode);
                        }
                    }
                    else
                    {
                        btnLogout.Visible = false;
                        lblHello.Visible = false;
                        lblName.Visible = false;
                    }
                }
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
                int deptId = Variables.deptNo;
                int sectId = Variables.secNo;
                var nomineeList = context.Nominees.Where(c => c.ShopTrainingId == id).ToList();
                List<EmployeeNomineeViews> empNomViewList = new List<EmployeeNomineeViews>();
                empNomViewList.Clear();

                var empList = context.Employees.Where(c => c.DepartmentId == deptId).ToList();

                foreach (var item in nomineeList)
                {
                    var check = empList.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                    if (check != null)
                    {
                        empNomViewList.Add(new EmployeeNomineeViews()
                        {
                            Status = item.Status,
                            EmployeeNumber = item.EmployeeNumber,
                            FullName = check.FullName
                        });
                    }
                }

                gridNominee.DataSource = null;
                gridNominee.DataSource = empNomViewList.OrderBy(c => c.EmployeeNumber).ToList();
                gridNominee.DataBind();

            }
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
                if (Code != string.Empty)
                {
                    string code = string.Empty;
                    string empNo = Session["EmpNo"].ToString().ToLower();
                    code = Code;
                    var selectId = context.ShopTrainings.FirstOrDefault(c => c.TrainingCode == code && c.EmployeeNumber.ToLower() == empNo);
                    if (selectId.IsSubmitted == true)
                    {
                        Variables.shopTrainingId = selectId.ShopTrainingId;
                        Variables.code = code;
                        string header = string.Empty;
                        string startMonth = string.Empty;
                        string extension = string.Empty;
                        int startDay = 0;
                        string dateEnd = string.Empty;

                        int secId = 0;
                        secId = Variables.selectedSecId;

                        var selectSec = context.Sections.FirstOrDefault(c => c.SectionId == secId);

                        var train = context.Trainings.FirstOrDefault(c => c.TrainingCode == code);
                        startMonth = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(train.DateStart.Date.Month);
                        startDay = train.DateStart.Date.Day;
                        dateEnd = train.DateEnd.Date.ToString("MMMM dd, yyyy");
                        header = train.TrainingCode + ":" + train.TrainingTitle + "(" + startMonth + " " + startDay + "-" + dateEnd + ") - " + selectSec.SectionName + " (Manager)";
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
                        gridDiv.Visible = false;
                        gridWhole.Visible = false;
                    }
                }
                else
                {
                    string empNo = Session["EmpNo"].ToString().ToLower();
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
                    int secId = 0;

                    var secName = clickedButton.ID.Split('-');
                    secId = int.Parse(secName[0]);

                    var selectSec = context.Sections.FirstOrDefault(c => c.SectionId == secId);

                    var selectShop = context.ShopTrainings.FirstOrDefault(c => c.ShopTrainingId == Variables.shopTrainingId);
                    string isManager = string.Empty;

                    if (selectShop != null)
                    {
                        if (selectShop.EmployeeNumber.ToLower() == empNo)
                        {
                            isManager = "(Manager)";
                        }
                        else
                        {
                            isManager = string.Empty;
                        }
                    }

                    var train = context.Trainings.FirstOrDefault(c => c.TrainingCode == code);
                    startMonth = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(train.DateStart.Date.Month);
                    startDay = train.DateStart.Date.Day;
                    dateEnd = train.DateEnd.Date.ToString("MMMM dd, yyyy");
                    header = train.TrainingCode + ":" + train.TrainingTitle + "(" + startMonth + " " + startDay + "-" + dateEnd + ") - " + selectSec.SectionName + " " + isManager;
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

    protected void lnkAboutTrainer_Click(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingCode == Variables.code);
                string myTitle = "About Trainer";
                string myMessage = selectTraining.AboutTrainer;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertMessage('" + myTitle + "','" + myMessage + "');", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    protected void lnkCourseOutline_Click(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingCode == Variables.code);
                string myTitle = "Course Outline";
                string myMessage = selectTraining.CourseOutline;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertMessage('" + myTitle + "','" + myMessage + "');", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    protected void lnkBackground_Click(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                var selectTraining = context.Trainings.FirstOrDefault(c => c.TrainingCode == Variables.code);
                string myTitle = "Background";
                string myMessage = selectTraining.Background;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertMessage('" + myTitle + "','" + myMessage + "');", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }
}