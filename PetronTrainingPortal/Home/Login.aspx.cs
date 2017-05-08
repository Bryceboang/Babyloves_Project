using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpNo"] != null)
        {
            if (Session["AccountType"] == "Supervisor")
            {
                Response.Redirect("~/Home/Supervisor/SupervisorNominate.aspx");
            }
            else if (Session["AccountType"] == "Manager")
            {
                Response.Redirect("~/Home/Manager/ManagerNominate.aspx");
            }
            else { Response.Redirect("~/Admin Page/AdminReport.aspx"); }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        var empno = txtEmpNum.Text;
        using (var context = new DatabaseContext())
        {
            var selecteduser = context.Users.FirstOrDefault(c => c.EmployeeNumber == empno);
            if (selecteduser != null)
            {
                if (selecteduser.Password == txtPass.Text)
                {
                    Variables.EmployeeNumber = selecteduser.EmployeeNumber;
                    Variables.AccessType = selecteduser.AccessType;
                    if (selecteduser.AccessType == "Supervisor")
                    {
                        Session["EmpNo"] = selecteduser.EmployeeNumber;
                        Session["FullName"] = selecteduser.FullName;
                        Session["AccountType"] = "Supervisor";
                        Response.Redirect("~/Home/Supervisor/SupervisorNominate.aspx");
                    }
                    else if (selecteduser.AccessType == "Manager")
                    {
                        Session["EmpNo"] = selecteduser.EmployeeNumber;
                        Session["FullName"] = selecteduser.FullName;
                        Session["AccountType"] = "Manager";
                        Response.Redirect("~/Home/Manager/ManagerNominate.aspx");
                    }
                    else if (selecteduser.AccessType == "Admin")
                    {
                        Session["EmpNo"] = selecteduser.EmployeeNumber;
                        Session["FullName"] = selecteduser.FullName;
                        Session["AccountType"] = "Admin";
                        //Response.Redirect("~/Admin Page/AdminReport.aspx");
                    }
                }
                else { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Invalid Password" + "');", true); }
            }
            else { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Invalid User');</script>"); }

        }
    }



}