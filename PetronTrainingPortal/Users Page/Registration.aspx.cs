using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpNo"] == null)
        {
            Response.Redirect("~/Main Page/Login.aspx");
        }
        else if (Session["AccountType"] == "Admin")
        {
            Response.Redirect("~/Admin Page/ReportAdmin.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Users only" + "');", true);
        }

        if (!Page.IsPostBack)
        {
            using (var context = new DatabaseContext())
            {
                lblEmployeeNumber.Text = Variables.EmployeeNumber;
                var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == Variables.EmployeeNumber);
                if (emp != null)
                {
                    lblTitle.Text = "EMPLOYEE DETAILS";
                    //txtFirstName.Text = emp.FirstName;
                    //txtMiddleInitial.Text = emp.MiddleInitial;
                    //txtLastName.Text = emp.LastName;
                    //txtEmailAddress.Text = emp.EmailAddress;
                    //txtContactNumber.Text = emp.ContactNumber;
                }
                else { lblTitle.Text = "REGISTRATION FORM"; }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        using (var context = new DatabaseContext())
        {
            var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == Variables.EmployeeNumber);

            if (string.IsNullOrEmpty(txtFirstName.Text) == true || string.IsNullOrWhiteSpace(txtFirstName.Text) == true) { message = "Please enter a first name."; }
            else if (string.IsNullOrEmpty(txtLastName.Text) == true || string.IsNullOrWhiteSpace(txtLastName.Text) == true) { message = "Please enter a last name."; }
            else if (string.IsNullOrEmpty(txtEmailAddress.Text) == true || string.IsNullOrWhiteSpace(txtEmailAddress.Text) == true) { message = "Please enter an email address."; }
            else if (string.IsNullOrEmpty(txtContactNumber.Text) == true || string.IsNullOrWhiteSpace(txtContactNumber.Text) == true) { message = "Please enter a contact number."; }
            else
            {
                // for adding
                if (emp == null)
                {
                    //Employee newEmployee = new Employee()
                    //{
                    //    EmployeeNumber = Variables.EmployeeNumber,
                    //    FirstName = txtFirstName.Text,
                    //    MiddleInitial = txtMiddleInitial.Text,
                    //    LastName = txtLastName.Text,
                    //    ContactNumber = txtContactNumber.Text,
                    //    EmailAddress = txtEmailAddress.Text
                    //};
                    //context.Employees.Add(newEmployee);
                    //context.SaveChanges();
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Successfully added');</script>");
                    //Session["FirstName"] = newEmployee.FirstName;
                    //Response.Redirect("~/Users Page/TrainingTitle.aspx");
                }
                // for editing
                else
                {
                    //var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == Variables.EmployeeNumber);
                    //selectEmp.FirstName = txtFirstName.Text;
                    //selectEmp.MiddleInitial = txtMiddleInitial.Text;
                    //selectEmp.LastName = txtLastName.Text;
                    //selectEmp.ContactNumber = txtContactNumber.Text;
                    //selectEmp.EmailAddress = txtEmailAddress.Text;
                    //context.SaveChanges();
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Successfully edited');</script>");
                    //Session["FirstName"] = selectEmp.FirstName;
                    //Response.Redirect("~/Users Page/TrainingTitle.aspx");
                }
            }

            if (message != string.Empty) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true); }

        }
    }
}