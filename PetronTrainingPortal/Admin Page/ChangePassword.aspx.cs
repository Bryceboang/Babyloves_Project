using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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

    }
    protected void btnChangePass_Click(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            ErrorEmpNo.Text = string.Empty;
            ErrorEmpNo2.Text = string.Empty;
            var empNo = Session["EmpNo"].ToString();
            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == empNo);
            if (selectUser != null)
            {
                if (selectUser.Password != txtBoxOldPass.Text)
                {
                    ErrorEmpNo.Text = "Your old password doesn't match.";
                    ErrorEmpNo2.Text = string.Empty;
                }
                else if (selectUser.Password == txtBoxNewPass.Text)
                {
                    ErrorEmpNo2.Text = "Please enter a different password. This is your old password";
                    ErrorEmpNo.Text = string.Empty;
                }
                else
                {
                    selectUser.Password = txtBoxNewPass.Text;
                    context.SaveChanges();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Change password successful.');</script>");
                    txtBoxOldPass.Text = string.Empty;
                    txtBoxNewPass.Text = string.Empty;
                    ErrorEmpNo.Text = string.Empty;
                    ErrorEmpNo2.Text = string.Empty;
                }
            }
        }
    }
}