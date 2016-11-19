using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteUser : System.Web.UI.Page
{
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

            Variables.empNo = string.Empty;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ErrorEmpNo.Text = string.Empty;
        var empNo = Session["EmpNo"].ToString().ToLower();
        using (var context = new DatabaseContext())
        {
            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == txtBoxEmployeeNumber.Text);
            if (string.IsNullOrEmpty(Variables.empNo) == true)
            {
                ErrorEmpNo.Text = "Please search an employee number first.";
            }
            else if (Variables.empNo.ToString().ToLower() == empNo)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This account is currently logged in.           Delete unsuccesful.');</script>");
            }
            else
            {
                var checkExisting = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == selectUser.EmployeeNumber);
                var checkExistingComplete = context.CompleteEmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == selectUser.EmployeeNumber);

                if (checkExisting != null || checkExistingComplete != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Cannot delete this user because it is registered to a training.');</script>");
                }
                else
                {
                    var listEmp = context.EmployeeTrainings.Where(c => c.EmployeeNumber == selectUser.EmployeeNumber).ToList();
                    if (listEmp.Count > 0) { foreach (var item in listEmp) { context.EmployeeTrainings.Remove(item); } }


                    context.Users.Remove(selectUser);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('User successfully removed.');</script>");
                    Clear();
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {

            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == txtBoxEmployeeNumber.Text);
            if (string.IsNullOrWhiteSpace(txtBoxEmployeeNumber.Text) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please enter an employee number.');</script>");
                ErrorEmpNo.Text = string.Empty;
            }
            else if (selectUser == null)
            {
                ErrorEmpNo.Text = "This employee number doesn't exist.";
            }
            else
            {
                Variables.empNo = selectUser.EmployeeNumber;
                var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == selectUser.EmployeeNumber);
                if (selectEmp != null)
                {
                    //lblEmp.Text = selectEmp.FirstName + " " + selectEmp.LastName;
                }
                else { lblEmp.Text = selectUser.EmployeeNumber; }
                ErrorEmpNo.Text = string.Empty;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "This employee number exists." + "');", true);
                btnClear.Enabled = true;
                btnDelete.Enabled = true;

            }
        }
    }

    public void Clear()
    {
        Variables.empNo = string.Empty;
        txtBoxEmployeeNumber.Text = string.Empty;
        lblEmp.Text = string.Empty;
        ErrorEmpNo.Text = string.Empty;
        btnClear.Enabled = true;
        btnDelete.Enabled = false;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
}