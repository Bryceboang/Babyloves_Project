using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_DeleteEmployee : System.Web.UI.Page
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
        lblEmpNoMsg.Text = string.Empty;
        using (var context = new DatabaseContext())
        {
            var checkEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == Variables.empNo.ToLower());
            if (checkEmp == null) { lblEmpNoMsg.Text = "Please search employee number first."; }
            else
            {
                var checkExisting = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == checkEmp.EmployeeNumber);
                var checkExistingComplete = context.CompleteEmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == checkEmp.EmployeeNumber);

                if (checkExisting != null || checkExistingComplete != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Cannot delete this employee because it is registered to a training.');</script>");
                }
                else
                {
                    context.Employees.Remove(checkEmp);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Employee record successfully removed.');</script>");
                    txtBoxEmployeeNumber.Text = string.Empty;
                    lblFullName.Text = string.Empty;
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblEmpNoMsg.Text = string.Empty;
        lblFullName.Text = string.Empty;
        using (var context = new DatabaseContext())
        {
            var checkEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber.ToLower() == txtBoxEmployeeNumber.Text.ToLower());
            if (checkEmp == null) { lblEmpNoMsg.Text = "This employee number doesn't exist."; }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This employee number exist.');</script>");
                lblFullName.Text = checkEmp.FullName;
                Variables.empNo = checkEmp.EmployeeNumber;
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtBoxEmployeeNumber.Text = string.Empty;
        lblEmpNoMsg.Text = string.Empty;
        lblFullName.Text = string.Empty;
        Variables.empNo = string.Empty;
    }
}