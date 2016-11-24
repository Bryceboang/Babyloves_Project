using Microsoft.Office.Interop.Outlook;
using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_StatusOnGoingTraining : System.Web.UI.Page
{

    public void Refresh()
    {
        List<TrainingViews> trainViewList = new List<TrainingViews>();
        List<EmployeeTrainingViews> empListView = new List<EmployeeTrainingViews>();
        trainViewList.Clear();
        empListView.Clear();

        using (var context = new DatabaseContext())
        {
            var training = context.Trainings.FirstOrDefault(c => c.TrainingTitle == cmbTraining.Text);
            var department = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
            if (training == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a training first." + "');", true);
            }
            else if (department == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a department first." + "');", true);
            }
            else
            {
                var section = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text);
                if (cmbSection.Text == "ALL")
                {
                    var secList = context.Sections.Where(c => c.DepartmentId == department.DepartmentId).ToList();
                    foreach (var sec in secList)
                    {
                        var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                        var empTrainList = context.EmployeeTrainings.ToList();

                        foreach (var emp in empList)
                        {
                            foreach (var item in empTrainList)
                            {
                                if (item.EmployeeNumber == emp.EmployeeNumber && item.Status == cmbStatus.Text && item.TrainingId == training.TrainingId)
                                {
                                    empListView.Add(new EmployeeTrainingViews()
                                    {
                                        EmployeeNumber = item.EmployeeNumber,
                                        Status = item.Status,
                                        TrainingId = item.TrainingId
                                    });
                                }
                            }
                        }

                        var userList = context.Users.Where(c => c.DepartmentId == department.DepartmentId && c.AccessType.ToLower() == "supervisor").ToList();
                        foreach (var item in userList)
                        {
                            foreach (var empTrain in empTrainList)
                            {
                                if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.Status == cmbStatus.Text && empTrain.TrainingId == training.TrainingId)
                                {

                                    var checkDup = empListView.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber && c.TrainingId == empTrain.TrainingId);
                                    if (checkDup == null)
                                    {
                                        empListView.Add(new EmployeeTrainingViews()
                                        {
                                            EmployeeNumber = item.EmployeeNumber,
                                            Status = empTrain.Status,
                                            TrainingId = empTrain.TrainingId
                                        });
                                    }
                                }
                            }
                        }
                    }

                    foreach (var item in empListView)
                    {
                        var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        if (emp != null)
                        {
                            var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == emp.DepartmentId && c.SectionId == emp.SectionId);
                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = item.EmployeeNumber,
                                FullName = emp.FullName,
                                SectionName = sec.SectionName,
                                Status = item.Status
                            });
                        }
                        else
                        {
                            var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == user.DepartmentId && c.SectionId == user.SectionId);
                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = item.EmployeeNumber,
                                FullName = user.FullName,
                                SectionName = sec.SectionName,
                                Status = item.Status
                            });
                        }
                    }


                }
                else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                else
                {
                    var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == department.DepartmentId && c.SectionName == cmbSection.Text);

                    var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                    var empTrainList = context.EmployeeTrainings.ToList();

                    foreach (var emp in empList)
                    {
                        foreach (var item in empTrainList)
                        {
                            if (item.EmployeeNumber == emp.EmployeeNumber && item.Status == cmbStatus.Text && item.TrainingId == training.TrainingId)
                            {
                                empListView.Add(new EmployeeTrainingViews()
                                {
                                    EmployeeNumber = item.EmployeeNumber,
                                    Status = item.Status,
                                    TrainingId = item.TrainingId
                                });
                            }
                        }
                    }

                    var userList = context.Users.Where(c => c.SectionId == sec.SectionId && c.AccessType.ToLower() == "supervisor").ToList();
                    foreach (var item in userList)
                    {
                        foreach (var empTrain in empTrainList)
                        {
                            if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.Status == cmbStatus.Text && empTrain.TrainingId == training.TrainingId)
                            {
                                empListView.Add(new EmployeeTrainingViews()
                                {
                                    EmployeeNumber = item.EmployeeNumber,
                                    Status = empTrain.Status,
                                    TrainingId = empTrain.TrainingId
                                });
                            }
                        }
                    }

                    foreach (var item in empListView)
                    {
                        var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        if (emp != null)
                        {
                            var sectionSelect = context.Sections.FirstOrDefault(c => c.DepartmentId == emp.DepartmentId && c.SectionId == emp.SectionId);
                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = item.EmployeeNumber,
                                FullName = emp.FullName,
                                SectionName = sectionSelect.SectionName,
                                Status = item.Status
                            });
                        }
                        else
                        {
                            var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            var sectionSelect = context.Sections.FirstOrDefault(c => c.DepartmentId == user.DepartmentId && c.SectionId == user.SectionId);
                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = item.EmployeeNumber,
                                FullName = user.FullName,
                                SectionName = sectionSelect.SectionName,
                                Status = item.Status
                            });
                        }
                    }
                }
            }

            gridView.DataSource = null;
            gridView.DataSource = trainViewList.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
            gridView.DataBind();

            //if (cmbStatus.Text == "APPROVED") { this.gridView.Columns[5].Visible = true; }
            //else { this.gridView.Columns[5].Visible = false; }
        }
    }

    public List<TrainingViews> ExcelReload()
    {
        List<TrainingViews> trainViewList = new List<TrainingViews>();
        List<EmployeeTrainingViews> empListView = new List<EmployeeTrainingViews>();
        trainViewList.Clear();
        empListView.Clear();

        using (var context = new DatabaseContext())
        {
            var training = context.Trainings.FirstOrDefault(c => c.TrainingTitle == cmbTraining.Text);
            var department = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
            if (training == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a training first." + "');", true);
            }
            else if (department == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a department first." + "');", true);
            }
            else
            {
                var section = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text);
                if (cmbSection.Text == "ALL")
                {
                    var secList = context.Sections.Where(c => c.DepartmentId == department.DepartmentId).ToList();
                    foreach (var sec in secList)
                    {
                        var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                        var empTrainList = context.EmployeeTrainings.ToList();

                        foreach (var emp in empList)
                        {
                            foreach (var item in empTrainList)
                            {
                                if (item.EmployeeNumber == emp.EmployeeNumber && item.Status == cmbStatus.Text && item.TrainingId == training.TrainingId)
                                {
                                    empListView.Add(new EmployeeTrainingViews()
                                    {
                                        EmployeeNumber = item.EmployeeNumber,
                                        Status = item.Status,
                                        TrainingId = item.TrainingId
                                    });
                                }
                            }
                        }

                        var userList = context.Users.Where(c => c.SectionId == sec.SectionId && c.AccessType.ToLower() == "supervisor").ToList();
                        foreach (var item in userList)
                        {
                            foreach (var empTrain in empTrainList)
                            {
                                if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.Status == cmbStatus.Text && empTrain.TrainingId == training.TrainingId)
                                {
                                    empListView.Add(new EmployeeTrainingViews()
                                    {
                                        EmployeeNumber = item.EmployeeNumber,
                                        Status = empTrain.Status,
                                        TrainingId = empTrain.TrainingId
                                    });
                                }
                            }
                        }
                    }

                    foreach (var item in empListView)
                    {
                        string secName = string.Empty;
                        string fullName = string.Empty;
                        var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        if (emp != null)
                        {
                            var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == emp.DepartmentId && c.SectionId == emp.SectionId);
                            secName = sec.SectionName;
                            fullName = emp.FullName;
                        }
                        else
                        {
                            var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == user.DepartmentId && c.SectionId == user.SectionId);
                            secName = sec.SectionName;
                            fullName = user.FullName;
                        }

                        trainViewList.Add(new TrainingViews()
                        {
                            DepartmentName = department.DepartmentName,
                            EmployeeNumber = item.EmployeeNumber,
                            FullName = fullName,
                            SectionName = secName,
                            Status = item.Status
                        });
                    }
                }
                else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                else
                {
                    var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == department.DepartmentId && c.SectionName == cmbSection.Text);

                    var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                    var empTrainList = context.EmployeeTrainings.ToList();

                    foreach (var emp in empList)
                    {
                        foreach (var item in empTrainList)
                        {
                            if (item.EmployeeNumber == emp.EmployeeNumber && item.Status == cmbStatus.Text && item.TrainingId == training.TrainingId)
                            {
                                empListView.Add(new EmployeeTrainingViews()
                                {
                                    EmployeeNumber = item.EmployeeNumber,
                                    Status = item.Status,
                                    TrainingId = item.TrainingId
                                });
                            }
                        }
                    }

                    var userList = context.Users.Where(c => c.SectionId == sec.SectionId && c.AccessType.ToLower() == "supervisor").ToList();
                    foreach (var item in userList)
                    {
                        foreach (var empTrain in empTrainList)
                        {
                            if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.Status == cmbStatus.Text && empTrain.TrainingId == training.TrainingId)
                            {
                                empListView.Add(new EmployeeTrainingViews()
                                {
                                    EmployeeNumber = item.EmployeeNumber,
                                    Status = empTrain.Status,
                                    TrainingId = empTrain.TrainingId
                                });
                            }
                        }
                    }

                    foreach (var item in empListView)
                    {
                        string secName = string.Empty;
                        string fullName = string.Empty;
                        var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        if (emp != null)
                        {
                            var sect = context.Sections.FirstOrDefault(c => c.DepartmentId == emp.DepartmentId && c.SectionId == emp.SectionId);
                            secName = sect.SectionName;
                            fullName = emp.FullName;
                        }
                        else
                        {
                            var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            var sect = context.Sections.FirstOrDefault(c => c.DepartmentId == user.DepartmentId && c.SectionId == user.SectionId);
                            secName = sect.SectionName;
                            fullName = user.FullName;
                        }
                        trainViewList.Add(new TrainingViews()
                        {
                            DepartmentName = department.DepartmentName,
                            EmployeeNumber = item.EmployeeNumber,
                            FullName = fullName,
                            SectionName = secName,
                            Status = item.Status
                        });
                    }
                }
            }

            //gridView.DataSource = null;
            //gridView.DataSource = trainViewList.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
            //gridView.DataBind();

            return trainViewList.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList(); ;

            //if (cmbStatus.Text == "APPROVED") { this.gridView.Columns[5].Visible = true; }
            //else { this.gridView.Columns[5].Visible = false; }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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

            using (var context = new DatabaseContext())
            {
                var trainList = context.Trainings.OrderBy(c => c.TrainingTitle).ToList();
                if (trainList.Count > 0) { foreach (var item in trainList) { cmbTraining.Items.Add(item.TrainingTitle); } }
                ReloadDepartment();
                ReloadSection();
                Refresh();
                ReloadEmailManager();
                ReloadEmailSupervisor();
            }
        }
    }

    protected void cmbBoxTraining_TextChanged(object sender, EventArgs e)
    {
        Refresh();
    }

    public void ReloadDepartment()
    {
        using (var context = new DatabaseContext())
        {
            var deptList = context.Departments.OrderBy(c => c.DepartmentName).ToList();
            if (deptList.Count > 0)
            {
                foreach (var item in deptList) { cmbDepartment.Items.Add(item.DepartmentName); }
            }
        }
    }

    public void ReloadEmailManager()
    {
        using (var context = new DatabaseContext())
        {
            var selectEmailDept = context.Departments.First(c => c.DepartmentName == cmbDepartment.Text);
            if (selectEmailDept != null)
            {
                var managerList = context.Users.Where(c => c.DepartmentId == selectEmailDept.DepartmentId && c.AccessType.ToLower() == "manager").OrderBy(c => c.Email).ToList();
                if (managerList.Count > 0)
                {
                    foreach (var item in managerList) { cmbManager.Items.Add(item.Email); }
                }
            }
            else
            {
                cmbManager.Text = "Select a department first";
            }
        }
    }

    public void ReloadEmailSupervisor()
    {
        using (var context = new DatabaseContext())
        {
            var selectEmailDept = context.Departments.First(c => c.DepartmentName == cmbDepartment.Text);
            if (selectEmailDept != null)
            {
                var supervisorList = context.Users.Where(c => c.DepartmentId == selectEmailDept.DepartmentId && c.AccessType.ToLower() == "supervisor").OrderBy(c => c.Email).ToList();
                if (supervisorList.Count > 0)
                {
                    foreach (var item in supervisorList) { cmbSupervisor.Items.Add(item.Email); }
                }
            }
            else
            {
                cmbSupervisor.Text = "Select a department first";
            }
        }
    }

    public void ReloadSection()
    {
        cmbSection.Items.Clear();
        using (var context = new DatabaseContext())
        {
            if (string.IsNullOrEmpty(cmbDepartment.Text) != true)
            {
                var selectDept = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
                var secList = context.Sections.OrderBy(c => c.SectionName).Where(c => c.DepartmentId == selectDept.DepartmentId);
                if (secList.Count() > 0)
                {
                    cmbSection.Items.Add("ALL");
                    foreach (var item in secList) { cmbSection.Items.Add(item.SectionName); }
                }
            }
        }
    }

    protected void cmbTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        Refresh();
    }

    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadSection();
        Refresh();
    }

    protected void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        Refresh();
    }

    protected void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Refresh();
    }

    private string getHTML(GridView gv)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter textwriter = new StringWriter(sb);
        HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
        gv.RenderControl(htmlwriter);
        htmlwriter.Flush();
        textwriter.Flush();
        htmlwriter.Dispose();
        textwriter.Dispose();
        return sb.ToString();
    }

    public void DataBody()
    {
        StringBuilder strBuilder = new StringBuilder();
        StringWriter strWriter = new StringWriter(strBuilder);
        HtmlTextWriter htw = new HtmlTextWriter(strWriter);
        gridView.GridLines = GridLines.Both;
        gridView.HeaderStyle.Font.Bold = true;
        gridView.RenderControl(htw);
        Response.Write(strWriter.ToString());
        Response.End();
    }

    protected void btnEmail1_Click(object sender, EventArgs e)
    {

        string email = string.Empty;
        if (cmbManager.Text != "None") { email = cmbManager.Text; }

        if (cmbSupervisor.Text != "None")
        {
            if (string.IsNullOrEmpty(email) == true) { email = email + "," + cmbSupervisor.Text; }
            else { email = cmbSupervisor.Text; }
        }
        //string email = "escruz@petron.com";
        string subject = "Subject Here";
        //string body = "body";
        string body = Label5.Text;
        Label5.Text = getHTML(gridView);
        ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "?subject=" + subject + "&body=" + body + "'", true);
    }

    public bool SendEmailViaOutLook()
    {
        //try
        //{
        // Create a Outlook Application and connect to outlook 
        Application OutlookApplication = new Application();

        // create the MailItem which we want to send 
        MailItem message = (MailItem)OutlookApplication.CreateItem(OlItemType.olMailItem);

        MailAddress toAddress = new MailAddress("escruz@gmail.com");
        MailAddress ccAddress = new MailAddress("jbmaningat@gmail.com");

        message.To = toAddress.ToString();
        message.CC = ccAddress.ToString();
        message.Subject = "Mail Subject2";
        message.Body = "Mail Body2";
        message.HTMLBody = getHTML(gridView);
        message.BodyFormat = OlBodyFormat.olFormatHTML;

        //Send email
        message.Send();

        return true;
        //}
        //catch (System.Exception ex)
        //{
        //    return false;
        //}
    }

    protected void SendEmail2_Click(object sender, EventArgs e)
    {
        SendEmailViaOutLook();
    }

    protected void bTnExport1_Click(object sender, EventArgs e)
    {
        ExportGridToExcel2();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }

    private void ExportGridToExcel2()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "OnGoingTraining" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        gridView.GridLines = GridLines.Both;
        gridView.HeaderStyle.Font.Bold = true;
        gridView.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    protected void cmbSupervisor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadEmailSupervisor();
    }

    protected void cmbManager_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadEmailManager();
    }
    protected void btnEmailManager_Click(object sender, EventArgs e)
    {
        string email = cmbManager.Text;

        //string email = "escruz@petron.com";
        string subject = "Subject Here";
        //string body = "body";
        string body = "There are still pending request.";
        ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "?subject=" + subject + "&body=" + body + "'", true);
    }
    protected void btnEmailSupervisor_Click(object sender, EventArgs e)
    {
        string email = cmbSupervisor.Text;

        //string email = "escruz@petron.com";
        string subject = "Subject Here";
        //string body = "body";
        string body = "There are still pending request.";
        ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "?subject=" + subject + "&body=" + body + "'", true);
    }
    protected void bTnExport1_Click1(object sender, EventArgs e)
    {
        ExportGridToExcel2();
    }
}