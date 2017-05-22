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
        if (!Page.IsPostBack)
        {
            if (Session["EmpNo"] != null)
            {
                if (Session["AccountType"] == "Supervisor")
                {
                    Response.Redirect("~/Home/Supervisor/SupervisorList.aspx");
                }
                else if (Session["AccountType"] == "Manager")
                {
                    Response.Redirect("~/Home/Manager/ManagerList.aspx");
                }
                else { Response.Redirect("~/Admin Page/AdminReport.aspx"); }
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            var empno = txtEmpNum.Text.ToLower();
            using (var context = new DatabaseContext())
            {
                if (string.IsNullOrWhiteSpace(txtEmpNum.Text) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertInfo('" + "Please enter a username." + "');", true);
                }
                else
                {
                    var selecteduser = context.Users.FirstOrDefault(c => c.EmployeeNumber.ToLower() == empno);
                    if (selecteduser != null)
                    {
                        if (selecteduser.Password == txtPass.Text)
                        {
                            Variables.EmployeeNumber = selecteduser.EmployeeNumber;
                            Variables.AccessType = selecteduser.AccessType;
                            Variables.deptNo = selecteduser.DepartmentId;
                            Variables.secNo = selecteduser.SectionId;
                            if (selecteduser.AccessType == "Supervisor")
                            {
                                Session["EmpNo"] = selecteduser.EmployeeNumber;
                                Session["FullName"] = selecteduser.FullName;
                                Session["AccountType"] = "Supervisor";
                                string code = Variables.code;

                                if (string.IsNullOrWhiteSpace(Variables.checkOutCode) == true)
                                {
                                    if (string.IsNullOrWhiteSpace(code) != true)
                                    {
                                        var checkDuplicate = context.ShopTrainings.FirstOrDefault(c => c.EmployeeNumber.ToLower() == empno && c.TrainingCode == code);
                                        if (checkDuplicate == null)
                                        {
                                            ShopTraining newShopTraining = new ShopTraining()
                                            {
                                                EmployeeNumber = selecteduser.EmployeeNumber,
                                                TrainingCode = code,
                                                IsComfirmedByAdmin = false,
                                                IsConfirmedByManger = false,
                                                IsSubmitted = false,
                                            };
                                            context.ShopTrainings.Add(newShopTraining);
                                            context.SaveChanges();
                                        }
                                    }
                                    Response.Redirect("~/Home/Supervisor/SupervisorList.aspx");
                                }
                                else
                                {
                                    var checkDuplicate = context.ShopTrainings.FirstOrDefault(c => c.EmployeeNumber.ToLower() == empno && c.TrainingCode == code);
                                    if (checkDuplicate == null)
                                    {
                                        ShopTraining newShopTraining = new ShopTraining()
                                        {
                                            EmployeeNumber = selecteduser.EmployeeNumber,
                                            TrainingCode = code,
                                            IsComfirmedByAdmin = false,
                                            IsConfirmedByManger = false,
                                            IsSubmitted = false,
                                        };
                                        context.ShopTrainings.Add(newShopTraining);
                                        context.SaveChanges();
                                    }
                                    Variables.checkOutCode = code;
                                    Response.Redirect("~/Home/Supervisor/SupervisorNominate.aspx");
                                }
                            }
                            else if (selecteduser.AccessType == "Manager")
                            {
                                Session["EmpNo"] = selecteduser.EmployeeNumber;
                                Session["FullName"] = selecteduser.FullName;
                                Session["AccountType"] = "Manager";
                                string code = Variables.code;

                                if (string.IsNullOrWhiteSpace(Variables.checkOutCode) == true)
                                {

                                    if (string.IsNullOrWhiteSpace(code) != true)
                                    {
                                        int dept = Variables.deptNo;
                                        var empList = context.Employees.Where(c => c.DepartmentId == dept).ToList();
                                        var shopList = context.ShopTrainings.ToList();
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


                                        var checkDuplicate = newShopList.FirstOrDefault(c => c.TrainingCode == code);
                                        if (checkDuplicate == null)
                                        {
                                            ShopTraining newShopTraining = new ShopTraining()
                                            {
                                                EmployeeNumber = selecteduser.EmployeeNumber,
                                                TrainingCode = code,
                                                IsComfirmedByAdmin = false,
                                                IsConfirmedByManger = false,
                                                IsSubmitted = false,
                                            };
                                            context.ShopTrainings.Add(newShopTraining);
                                            context.SaveChanges();
                                        }

                                    }
                                    Response.Redirect("~/Home/Manager/ManagerList.aspx");
                                }
                                else
                                {

                                    int dept = Variables.deptNo;
                                    var empList = context.Employees.Where(c => c.DepartmentId == dept).ToList();
                                    var shopList = context.ShopTrainings.ToList();
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


                                    var checkDuplicate = newShopList.FirstOrDefault(c => c.TrainingCode == code);
                                    if (checkDuplicate == null)
                                    {
                                        ShopTraining newShopTraining = new ShopTraining()
                                        {
                                            EmployeeNumber = selecteduser.EmployeeNumber,
                                            TrainingCode = code,
                                            IsComfirmedByAdmin = false,
                                            IsConfirmedByManger = false,
                                            IsSubmitted = true,
                                        };
                                        context.ShopTrainings.Add(newShopTraining);
                                        context.SaveChanges();
                                    }
                                    Variables.checkOutCode = code;
                                    Response.Redirect("~/Home/Manager/ManagerNominate.aspx");
                                }
                            }
                            else if (selecteduser.AccessType == "Admin")
                            {
                                Session["EmpNo"] = selecteduser.EmployeeNumber;
                                Session["FullName"] = selecteduser.FullName;
                                Session["AccountType"] = "Admin";
                                //Response.Redirect("~/Admin Page/AdminReport.aspx");
                            }
                        }
                        else { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + "Invalid Password" + "');", true); }
                    }
                    else { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertError('" + "Invalid User" + "');", true); }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

}