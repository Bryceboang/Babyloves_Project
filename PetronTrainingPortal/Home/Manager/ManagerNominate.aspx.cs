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

public partial class Home_Manager_ManagerNominate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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


            if (!Page.IsPostBack)
            {
                Variables.currentcmbSec = string.Empty;
                cmbSections.Items.Clear();
                var list = context.Sections.Where(c => c.DepartmentId == Variables.deptNo).ToList();
                foreach (var item in list) { cmbSections.Items.Add(item.SectionName); }
                if (list.Count() > 0)
                {
                    cmbSections.SelectedIndex = 0;
                }

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
                        var select = context.Sections.FirstOrDefault(c => c.SectionId == Variables.selectedSecId);
                        cmbSections.Text = select.SectionName;
                    }
                }
                else
                {
                    btnLogout.Visible = false;
                    lblHello.Visible = false;
                    lblName.Visible = false;
                }
            }


            if (string.IsNullOrWhiteSpace(Variables.currentcmbSec) != true)
            {
                selectSect = context.Sections.FirstOrDefault(c => c.SectionName == Variables.currentcmbSec);
                shopList = context.ShopTrainings.Where(c => c.IsConfirmedByManger == false && c.EmployeeNumber.ToLower() == empNo && c.SectionId == selectSect.SectionId).ToList();
            }
            else
            {
                var selectId = context.Sections.FirstOrDefault(c => c.SectionName == cmbSections.Text);
                shopList = context.ShopTrainings.Where(c => c.IsConfirmedByManger == false && c.EmployeeNumber.ToLower() == empNo && c.SectionId == selectId.SectionId).ToList();
            }

            menuPanel.Controls.Clear();
            foreach (var item in shopList)
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

        //if (!Page.IsPostBack)
        //{

        //    if (Session["FullName"] != null)
        //    {
        //        btnLogout.Visible = true;
        //        lblHello.Visible = true;
        //        lblName.Visible = true;
        //        lblName.Text = Session["FullName"].ToString();
        //        gridDiv.Visible = false;
        //        gridWhole.Visible = false;

        //        if (Variables.checkOutCode != string.Empty)
        //        {
        //            ReloadCode(null, Variables.checkOutCode);
        //        }
        //    }
        //    else
        //    {
        //        btnLogout.Visible = false;
        //        lblHello.Visible = false;
        //        lblName.Visible = false;
        //    }
        //}
    }

    void ReloadTraining()
    {

        using (var context = new DatabaseContext())
        {
            string empNo = string.Empty;
            empNo = Session["EmpNo"].ToString().ToLower();
            int count = 0;
            int dept = Variables.deptNo;
            var empList = context.Employees.Where(c => c.DepartmentId == dept).ToList();
            var shopList = context.ShopTrainings.Where(c => c.IsConfirmedByManger == false).ToList();
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

    }

    void ReloadTraining(string filter)
    {

        using (var context = new DatabaseContext())
        {
            string empNo = string.Empty;
            empNo = Session["EmpNo"].ToString().ToLower();
            int count = 0;
            int dept = Variables.deptNo;
            var selectSect = context.Sections.FirstOrDefault(c => c.SectionName == filter);
            List<ShopTraining> shopList = new List<ShopTraining>();
            shopList.Clear();
            shopList = context.ShopTrainings.Where(c => c.IsConfirmedByManger == false && c.EmployeeNumber.ToLower() == empNo && c.SectionId == selectSect.SectionId).ToList();
            menuPanel.Controls.Clear();
            foreach (var item in shopList)
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

                    int dept = Variables.deptNo;
                    List<ShopTraining> shopList = new List<ShopTraining>();
                    shopList.Clear();
                    shopList = context.ShopTrainings.Where(c => c.IsConfirmedByManger == false && c.EmployeeNumber.ToLower() == empNo && c.SectionId == Variables.selectedSecId).ToList();
                    var selectId = shopList.FirstOrDefault(c => c.TrainingCode == code);

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
                var nomineeList = context.Nominees.Where(c => c.ShopTrainingId == id).ToList();

                var empList = context.Employees.Where(c => c.DepartmentId == deptId).ToList();

                List<Employee> newEmpList = new List<Employee>();
                newEmpList.Clear();
                foreach (var item in empList)
                {
                    var check = nomineeList.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                    if (check == null)
                    {
                        newEmpList.Add(item);
                    }
                }

                List<EmployeeNomineeViews> empNomViewList = new List<EmployeeNomineeViews>();
                empNomViewList.Clear();

                foreach (var item in newEmpList)
                {
                    DateTime now = DateTime.Now;
                    Age age = new Age(item.DateHired, now);
                    string service = (age.Years + "." + age.Months).ToString();
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

                int count = context.Nominees.Where(c => c.ShopTrainingId == id).ToList().Count;
                lblTotalNominee.Text = count.ToString();

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
            Variables.selectedSecId = 0;
            ReloadCode(sender, string.Empty);
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
                    string empNo = employeeNumber.Text;
                    string code = Variables.code;
                    int id = Variables.shopTrainingId;

                    Nominee newNominee = new Nominee()
                    {
                        EmployeeNumber = empNo,
                        ShopTrainingId = id,
                        Status = "On Waiting List"
                    };
                    context.Nominees.Add(newNominee);
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

    protected void lnkAddNominee_Click(object sender, EventArgs e)
    {
        gridDiv.Visible = true;
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
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
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertSuccess('" + "Shopped Training deleted." + "');", true);
                    ReloadTraining(cmbSections.Text);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                int id = Variables.shopTrainingId;
                var nomineeList = context.Nominees.Where(c => c.ShopTrainingId == id).ToList();
                if (nomineeList.Count() > 0)
                {
                    Response.Redirect("~/Home/Manager/ManagerSubmit.aspx");
                }
                else { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + "Please nominate an employee first." + "');", true); }
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

    protected void gridNominee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                GridViewRow row = gridNominee.SelectedRow;
                TableCell employeeNumber = row.Cells[0];
                string empNo = employeeNumber.Text;
                var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == empNo);

                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
                var selectSect = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);

                lblDepartment.Text = selectDept.DepartmentName;
                lblSection.Text = selectSect.SectionName;
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    protected void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < 2; i++)
        //{
        //    if (i == 0)
        //    {
        Variables.checkOutCode = string.Empty;
        Variables.selectedSecId = 0;
        gridDiv.Visible = false;
        gridWhole.Visible = false;
        Variables.currentcmbSec = cmbSections.Text;
        Page_Load(sender, e);
        //ReloadTraining(cmbSections.Text);
        //Response.Redirect(Request.Url.AbsoluteUri);
        //    }
        //    else
        //    {
        //        Variables.checkOutCode = string.Empty;
        //        Variables.selectedSecId = 0;
        //        gridDiv.Visible = false;
        //        gridWhole.Visible = false;
        //        Variables.currentcmbSec = cmbSections.Text;
        //        Response.Redirect(Request.RawUrl);
        //    }
        //}
    }
}