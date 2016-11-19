using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using Outlook = Microsoft.Office.Interop.Outlook;
using outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using FileHelpers;

public partial class Admin_Page_ViewStatus : System.Web.UI.Page
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

    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    //required to avoid the run time error "  
    //    //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    //}

    //private void ExportGridToExcel()
    //{
    //    //Response.Clear();
    //    //Response.Buffer = true;
    //    //Response.ClearContent();
    //    //Response.ClearHeaders();
    //    //Response.Charset = "";
    //    //string FileName = "Training" + DateTime.Now + ".xls";
    //    //StringWriter strwritter = new StringWriter();
    //    //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
    //    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    //Response.ContentType = "application/vnd.ms-excel";
    //    //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
    //    //gridView.GridLines = GridLines.Both;
    //    //gridView.HeaderStyle.Font.Bold = true;
    //    //gridView.RenderControl(htmltextwrtter);
    //    //Response.Write(strwritter.ToString());
    //    //Response.End();

    //    ExportToExcel(ExcelReload());
    //}

    //public void ExportToExcel(List<TrainingViews> trainViewList)
    //{
    //    // Load Excel application
    //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

    //    // Create empty workbook
    //    excel.Workbooks.Add();

    //    // Create Worksheet from active sheet
    //    Microsoft.Office.Interop.Excel._Worksheet workSheet = (Excel.Worksheet)excel.ActiveSheet;

    //    // I created Application and Worksheet objects before try/catch,
    //    // so that i can close them in finnaly block.
    //    // It's IMPORTANT to release these COM objects!!
    //    try
    //    {
    //        // ------------------------------------------------
    //        // Creation of header cells
    //        // ------------------------------------------------
    //        workSheet.Cells[1, "A"] = "Employee Number";
    //        workSheet.Cells[1, "B"] = "FullName";
    //        workSheet.Cells[1, "C"] = "Department Name";
    //        workSheet.Cells[1, "D"] = "Section Name";
    //        workSheet.Cells[1, "E"] = "Status";

    //        // ------------------------------------------------
    //        // Populate sheet with some real data from "cars" list
    //        // ------------------------------------------------
    //        int row = 2; // start row (in row 1 are header cells)
    //        foreach (TrainingViews item in trainViewList)
    //        {
    //            workSheet.Cells[row, "A"] = item.EmployeeNumber;
    //            workSheet.Cells[row, "B"] = item.FullName;
    //            workSheet.Cells[row, "C"] = item.DepartmentName;
    //            workSheet.Cells[row, "D"] = item.SectionName;
    //            workSheet.Cells[row, "E"] = item.Statbus;
    //            row++;
    //        }

    //        // Apply some predefined styles for data to look nicely :)
    //        workSheet.Range["A1"].AutoFormat(Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1);

    //        // Define filename
    //        string fileName = string.Format(@"{0}\STATUS OF EMPLOYEES.xlsx", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

    //        // Save this data as a file
    //        workSheet.SaveAs(fileName);

    //        // Display SUCCESS message
    //        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Export to excel successful.');</script>");
    //        //MessageBox.Show(string.Format("The file '{0}' is saved successfully!", fileName));
    //    }
    //    //catch (Exception exception)
    //    //{
    //    //MessageBox.Show("Exception",
    //    //    "There was a PROBLEM saving Excel file!\n" + exception.Message,
    //    //    MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    //}
    //    finally
    //    {
    //        // Quit Excel application
    //        excel.Quit();

    //        // Release COM objects (very important!)
    //        if (excel != null)
    //            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

    //        if (workSheet != null)
    //            System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);

    //        // Empty variables
    //        excel = null;
    //        workSheet = null;

    //        // Force garbage collector cleaning
    //        GC.Collect();
    //    }
    //}

    //protected void bTnExport_Click(object sender, EventArgs e)
    //{
    //    List<TrainingViews> traingList = new List<TrainingViews>();
    //    traingList.Clear();
    //    traingList = ExcelReload();
    //    using (var context = new DatabaseContext())
    //    {
    //        if (traingList.Count() > 0)
    //        {
    //            // Configure open file dialog box
    //            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
    //            dlg.FileName = " STATUS OF EMPLOYEES " + DateTime.Now.ToString("dd-MMM-yyyy"); // Default file name
    //            dlg.DefaultExt = ".csv"; // Default file extension
    //            dlg.Filter = "CSV Files (.csv)|*.csv"; // Filter files by extension

    //            // Show open file dialog box
    //            Nullable<bool> result = dlg.ShowDialog();

    //            if (result == true)
    //            {
    //                FileHelperEngine engine = new FileHelperEngine(typeof(TrainingViews));
    //                engine.HeaderText = "STATUS OF EMPLOYEES";
    //                engine.WriteFile(dlg.FileName, traingList, traingList.Count);
    //                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Export to excel successful.');</script>");
    //            }
    //        }
    //    }
    //}

    //private void SendEmailToOutlook()
    //{
    //    outlook.Application oApp = new outlook.Application();
    //    outlook.MailItem oMsg = (outlook.MailItem)oApp.CreateItem(outlook.OlItemType.olMailItem);

    //    StringBuilder emailBody = new StringBuilder();
    //    StringWriter sw = new StringWriter(emailBody);
    //    HtmlTextWriter hw = new HtmlTextWriter(sw);
    //    gridView.RenderControl(hw);
    //    oMsg.HTMLBody = "Dear Sir, <br /> Please Assign the Priority for Scaffolding Jobs...!!<br />" +
    //    emailBody.ToString();
    //}

    

    //private void SendToOutlookTest()
    //{
    //    try
    //    {
    //        // Create the Outlook application.
    //        Outlook.Application oApp = new Outlook.Application();

    //        // Get the NameSpace and Logon information.
    //        Outlook.NameSpace oNS = oApp.GetNamespace("mapi");

    //        // Log on by using a dialog box to choose the profile.
    //        oNS.Logon(Missing.Value, Missing.Value, true, true);

    //        // Alternate logon method that uses a specific profile.
    //        // TODO: If you use this logon method, 
    //        //  change the profile name to an appropriate value.
    //        //oNS.Logon("YourValidProfile", Missing.Value, false, true); 

    //        // Create a new mail item.
    //        Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

    //        // Set the subject.
    //        oMsg.Subject = "Send grid data to outlook";

    //        // Set HTMLBody.
    //        String sHtml;
    //        sHtml = "<HTML>\n" +
    //           "<HEAD>\n" +
    //           "<TITLE>Sample grid</TITLE>\n" +
    //           "</HEAD>\n" +
    //           "<BODY><P>\n" +
    //           GetGridviewData(gridView) +
    //           "</BODY>\n" +
    //           "</HTML>";
    //        oMsg.HTMLBody = sHtml;

    //        // Add a recipient.
    //        Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
    //        // TODO: Change the recipient in the next line if necessary.
    //        Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add("jbmaningat@gmail.com");
    //        oRecip.Resolve();

    //        // Send.
    //        oMsg.Send();

    //        // Log off.
    //        oNS.Logoff();

    //        // Clean up.
    //        oRecip = null;
    //        oRecips = null;
    //        oMsg = null;
    //        oNS = null;
    //        oApp = null;
    //    }

    //    // Simple error handling.
    //    catch (System.Exception e)
    //    {
    //        //Console.WriteLine("{0} Exception caught.", e);
    //    }
    //}

    public void ReloadDepartment()
    {
        using (var context = new DatabaseContext())
        {
            var deptList = context.Departments.OrderBy(c => c.DepartmentName).ToList();
            if (deptList.Count > 0)
            {
                foreach (var item in deptList) { cmbDepartment.Items.Add(item.DepartmentName); cmbEmailDepartment.Items.Add(item.DepartmentName); }
            }
        }
    }

    public void ReloadEmailManager()
    {
        using (var context = new DatabaseContext())
        {
            var selectEmailDept = context.Departments.First(c => c.DepartmentName == cmbEmailDepartment.Text);
            if (selectEmailDept != null)
            {
                var managerList = context.Users.Where(c => c.DepartmentId == selectEmailDept.DepartmentId && c.AccessType.ToLower() == "manager").OrderBy(c => c.Email).ToList();
                if (managerList.Count > 0)
                {
                    cmbEmailManager.Items.Add("None");
                    foreach (var item in managerList) { cmbEmailManager.Items.Add(item.Email); }
                }
            }
            else
            {
                cmbEmailManager.Text = "Select a department first";
                cmbEmailSupervisor.Text = "Select a department first";
            }
        }
    }

    public void ReloadEmailSupervisor()
    {
        using (var context = new DatabaseContext())
        {
            var selectEmailDept = context.Departments.First(c => c.DepartmentName == cmbEmailDepartment.Text);
            if (selectEmailDept != null)
            {
                var supervisorList = context.Users.Where(c => c.DepartmentId == selectEmailDept.DepartmentId && c.AccessType.ToLower() == "manager").OrderBy(c => c.Email).ToList();
                if (supervisorList.Count > 0)
                {
                    cmbEmailSupervisor.Items.Add("None");
                    foreach (var item in supervisorList) { cmbEmailSupervisor.Items.Add(item.Email); }
                }
            }
            else
            {
                cmbEmailManager.Text = "Select a department first";
                cmbEmailSupervisor.Text = "Select a department first";
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
        if (cmbEmailManager.Text != "None") { email = cmbEmailManager.Text; }

        if (cmbEmailSupervisor.Text != "None")
        {
            if (string.IsNullOrEmpty(email) == true) { email = email + "," + cmbEmailSupervisor.Text; }
            else { email = cmbEmailSupervisor.Text; }
        }
        //string email = "escruz@petron.com";
        string subject = "Subject Here";
        //string body = "body";
        string body = Label5.Text;
        Label5.Text = getHTML(gridView);
        ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "?subject=" + subject + "&body=" + body + "'", true);
    }

    //protected void LinkButton3_Click(object sender, EventArgs e)
    //{
    //    btnEmail1.OnClientClick = "window.location.href = 'mailto:' + someone@something.com + '?subject=' + Email Subject3 + '&body=' + ;";
    //}

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

    //public void SendOutlook()
    //{
    //    //try
    //    //{
    //    // Create the Outlook application.
    //    Outlook.Application oApp = new Outlook.Application();

    //    // Get the NameSpace and Logon information.
    //    Outlook.NameSpace oNS = oApp.GetNamespace("mapi");

    //    // Log on by using a dialog box to choose the profile.
    //    oNS.Logon(Missing.Value, Missing.Value, true, true);

    //    // Alternate logon method that uses a specific profile.
    //    // TODO: If you use this logon method, 
    //    //  change the profile name to an appropriate value.
    //    //oNS.Logon("YourValidProfile", Missing.Value, false, true); 

    //    // Create a new mail item.
    //    Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

    //    // Set the subject.
    //    oMsg.Subject = "Send Using OOM in C#";

    //    // Set HTMLBody.
    //    String sHtml;
    //    sHtml = "<HTML>\n" +
    //       "<HEAD>\n" +
    //       "<TITLE>Sample GIF</TITLE>\n" +
    //       "</HEAD>\n" +
    //       "<BODY><P>\n" +
    //       "<h1><Font Color=Green>Inline graphics</Font></h1></P>\n" +
    //       "</BODY>\n" +
    //       "</HTML>";
    //    oMsg.HTMLBody = sHtml;

    //    // Add a recipient.
    //    Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
    //    // TODO: Change the recipient in the next line if necessary.
    //    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add("jbmaningat@petron.com");
    //    oRecip.Resolve();

    //    // Send.
    //    oMsg.Send();

    //    // Log off.
    //    oNS.Logoff();

    //    // Clean up.
    //    oRecip = null;
    //    oRecips = null;
    //    oMsg = null;
    //    oNS = null;
    //    oApp = null;
    //    //}

    //    // Simple error handling.
    //    //catch (Exception e)
    //    //{
    //    //    Console.WriteLine("{0} Exception caught.", e);
    //    //}  
    //}


    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    /* Verifies that the control is rendered */
    //}
    //protected void btnEmail4_Click(object sender, EventArgs e)
    //{
    //    //SendOutlook();

    //    SendToOutlookTest();
    //}

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
        string FileName = "Training" + DateTime.Now + ".xls";
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

    protected void cmbEmailManager_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadEmailSupervisor();
    }

    protected void cmbEmailDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadEmailManager();
    }
}