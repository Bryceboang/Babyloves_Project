using FileHelpers;
using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_ViewStatusTraining : System.Web.UI.Page
{

    public void Refresh()
    {
        List<TrainingViews> trainViewList = new List<TrainingViews>();
        List<EmployeeTrainingViews> empListView = new List<EmployeeTrainingViews>();
        List<CompleteTrainingViews> completeListView = new List<CompleteTrainingViews>();
        trainViewList.Clear();
        empListView.Clear();
        completeListView.Clear();

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

                if (cmbStatus.Text == "COMPLETED")
                {
                    if (string.IsNullOrEmpty(cmbDate.Text) == true)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a date first." + "');", true);
                    }
                    else
                    {
                        #region COMPLETED
                        var section = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text);
                        if (cmbSection.Text == "ALL")
                        {
                            var secList = context.Sections.Where(c => c.DepartmentId == department.DepartmentId).ToList();
                            DateTime date = Convert.ToDateTime(cmbDate.Text).Date;
                            foreach (var sec in secList)
                            {
                                var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                                var empTrainList = context.CompleteEmployeeTrainings.Where(c => c.DateComplete == date).ToList();

                                foreach (var emp in empList)
                                {
                                    foreach (var item in empTrainList)
                                    {
                                        if (item.EmployeeNumber == emp.EmployeeNumber && item.TrainingId == training.TrainingId)
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
                                        if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.TrainingId == training.TrainingId)
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

                            var grouped = trainViewList.GroupBy(c => c.SectionName).Select(g => new
                            {
                                SectionName = g.Key,
                                Count = g.Count(),
                                TApproved = g.Where(a => a.Status == "APPROVED").ToList().Count(),
                                TPending = g.Where(a => a.Status == "PENDING").ToList().Count(),
                                TDeclined = g.Where(a => a.Status == "DECLINED").ToList().Count(),
                            });


                            foreach (var item in grouped)
                            {
                                int countEmp = 0;
                                int countSuper = 0;
                                foreach (var selectItem in trainViewList.Where(c => c.SectionName == item.SectionName))
                                {
                                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == selectItem.EmployeeNumber);
                                    if (selectEmp != null) { countEmp++; }
                                    else { countSuper++; }
                                }

                                completeListView.Add(new CompleteTrainingViews()
                                {
                                    NoOfEmployees = countEmp.ToString("n0"),
                                    NoOfSupervisor = countSuper.ToString("n0"),
                                    SectionName = item.SectionName,
                                    TotalApproved = item.TApproved.ToString("n0"),
                                    TotalDeclined = item.TDeclined.ToString("n0"),
                                    TotalPending = item.TPending.ToString("n0")
                                });
                            }

                            gridView.DataSource = null;
                            gridView.DataSource = completeListView.OrderBy(c => c.SectionName).ToList();
                            gridView.DataBind();

                        }
                        else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                        else // kapag isa lang pinili na section
                        {
                            var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == department.DepartmentId && c.SectionName == cmbSection.Text);
                            DateTime date = Convert.ToDateTime(cmbDate.Text).Date;
                            var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                            var empTrainList = context.CompleteEmployeeTrainings.Where(c => c.DateComplete == date).ToList();

                            foreach (var emp in empList)
                            {
                                foreach (var item in empTrainList)
                                {
                                    if (item.EmployeeNumber == emp.EmployeeNumber && item.TrainingId == training.TrainingId)
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

                            var grouped = trainViewList.GroupBy(c => c.SectionName).Select(g => new
                            {
                                SectionName = g.Key,
                                Count = g.Count(),
                                TApproved = g.Where(a => a.Status == "APPROVED").ToList().Count(),
                                TPending = g.Where(a => a.Status == "PENDING").ToList().Count(),
                                TDeclined = g.Where(a => a.Status == "DECLINED").ToList().Count(),
                            });

                            foreach (var item in grouped)
                            {
                                int countEmp = 0;
                                int countSuper = 0;
                                foreach (var selectItem in trainViewList.Where(c => c.SectionName == item.SectionName))
                                {
                                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == selectItem.EmployeeNumber);
                                    if (selectEmp != null) { countEmp++; }
                                    else { countSuper++; }
                                }

                                completeListView.Add(new CompleteTrainingViews()
                                {
                                    NoOfEmployees = countEmp.ToString("n0"),
                                    NoOfSupervisor = countSuper.ToString("n0"),
                                    SectionName = item.SectionName,
                                    TotalApproved = item.TApproved.ToString("n0"),
                                    TotalDeclined = item.TDeclined.ToString("n0"),
                                    TotalPending = item.TPending.ToString("n0")
                                });
                            }

                            gridView.DataSource = null;
                            gridView.DataSource = completeListView.OrderBy(c => c.SectionName).ToList();
                            gridView.DataBind();
                        }
                        #endregion
                    }
                }
                else // from old emptrain
                {
                    #region NO GOING
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
                                    if (item.EmployeeNumber == emp.EmployeeNumber && item.TrainingId == training.TrainingId)
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
                                    if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.TrainingId == training.TrainingId)
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

                        var grouped = trainViewList.GroupBy(c => c.SectionName).Select(g => new
                        {
                            SectionName = g.Key,
                            Count = g.Count(),
                            TApproved = g.Where(a => a.Status == "APPROVED").ToList().Count(),
                            TPending = g.Where(a => a.Status == "PENDING").ToList().Count(),
                            TDeclined = g.Where(a => a.Status == "DECLINED").ToList().Count(),
                        });


                        foreach (var item in grouped)
                        {
                            int countEmp = 0;
                            int countSuper = 0;
                            foreach (var selectItem in trainViewList.Where(c => c.SectionName == item.SectionName))
                            {
                                var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == selectItem.EmployeeNumber);
                                if (selectEmp != null) { countEmp++; }
                                else { countSuper++; }
                            }

                            completeListView.Add(new CompleteTrainingViews()
                            {
                                NoOfEmployees = countEmp.ToString("n0"),
                                NoOfSupervisor = countSuper.ToString("n0"),
                                SectionName = item.SectionName,
                                TotalApproved = item.TApproved.ToString("n0"),
                                TotalDeclined = item.TDeclined.ToString("n0"),
                                TotalPending = item.TPending.ToString("n0")
                            });
                        }

                        gridView.DataSource = null;
                        gridView.DataSource = completeListView.OrderBy(c => c.SectionName).ToList();
                        gridView.DataBind();

                    }
                    else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                    else // kapag isa lang pinili na section
                    {
                        var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == department.DepartmentId && c.SectionName == cmbSection.Text);

                        var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                        var empTrainList = context.EmployeeTrainings.ToList();

                        foreach (var emp in empList)
                        {
                            foreach (var item in empTrainList)
                            {
                                if (item.EmployeeNumber == emp.EmployeeNumber && item.TrainingId == training.TrainingId)
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
                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = item.EmployeeNumber,
                                FullName = emp.FullName,
                                SectionName = sec.SectionName,
                                Status = item.Status
                            });
                        }

                        var grouped = trainViewList.GroupBy(c => c.SectionName).Select(g => new
                        {
                            SectionName = g.Key,
                            Count = g.Count(),
                            TApproved = g.Where(a => a.Status == "APPROVED").ToList().Count(),
                            TPending = g.Where(a => a.Status == "PENDING").ToList().Count(),
                            TDeclined = g.Where(a => a.Status == "DECLINED").ToList().Count(),
                        });

                        foreach (var item in grouped)
                        {
                            int countEmp = 0;
                            int countSuper = 0;
                            foreach (var selectItem in trainViewList.Where(c => c.SectionName == item.SectionName))
                            {
                                var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == selectItem.EmployeeNumber);
                                if (selectEmp != null) { countEmp++; }
                                else { countSuper++; }
                            }

                            completeListView.Add(new CompleteTrainingViews()
                            {
                                NoOfEmployees = countEmp.ToString("n0"),
                                NoOfSupervisor = countSuper.ToString("n0"),
                                SectionName = item.SectionName,
                                TotalApproved = item.TApproved.ToString("n0"),
                                TotalDeclined = item.TDeclined.ToString("n0"),
                                TotalPending = item.TPending.ToString("n0")
                            });
                        }
                        gridView.DataSource = null;
                        gridView.DataSource = completeListView.OrderBy(c => c.SectionName).ToList();
                        gridView.DataBind();

                    }
                    #endregion
                }
            }
        }
    }

    // eto yung lalagay mo pang completed na training
    public void RefreshEmployee() 
    {
        List<TrainingViews> empViewList = new List<TrainingViews>();
        empViewList.Clear();

        using (var context = new DatabaseContext())
        {
            var training = context.Trainings.FirstOrDefault(c => c.TrainingTitle == cmbTraining.Text);
            if (training == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a training first." + "');", true);
            }
            else
            {
                var list = context.CompleteEmployeeTrainings.Where(c => c.TrainingId == training.TrainingId).ToList();
                if (list.Count() > 0)
                {
                    foreach (var item in list)
                    {
                        string fullName = string.Empty;
                        var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                        if (emp == null)
                        {
                            var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            fullName = user.FullName;
                        }
                        else { fullName = emp.FullName; }

                        empViewList.Add(new TrainingViews()
                        {
                            EmployeeNumber = item.EmployeeNumber,
                            FullName = fullName,
                            Status = item.Status
                        });
                    }
                }
            }

            gridViewEmployee.DataSource = null;
            gridViewEmployee.DataSource = empViewList.OrderBy(c => c.EmployeeNumber).ToList();
            gridViewEmployee.DataBind();
        }
    }

    public List<CompleteTrainingViews> ExcelReload()
    {
        List<TrainingViews> trainViewList = new List<TrainingViews>();
        List<EmployeeTrainingViews> empListView = new List<EmployeeTrainingViews>();
        List<CompleteTrainingViews> completeListView = new List<CompleteTrainingViews>();
        trainViewList.Clear();
        empListView.Clear();
        completeListView.Clear();

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

                if (cmbStatus.Text == "COMPLETED")
                {
                    if (string.IsNullOrEmpty(cmbDate.Text) == true)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a date first." + "');", true);
                    }
                    else
                    {
                        #region COMPLETED
                        var section = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text);
                        if (cmbSection.Text == "ALL")
                        {
                            var secList = context.Sections.Where(c => c.DepartmentId == department.DepartmentId).ToList();
                            DateTime date = Convert.ToDateTime(cmbDate.Text).Date;
                            foreach (var sec in secList)
                            {
                                var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                                var empTrainList = context.CompleteEmployeeTrainings.Where(c => c.DateComplete == date).ToList();

                                foreach (var emp in empList)
                                {
                                    foreach (var item in empTrainList)
                                    {
                                        if (item.EmployeeNumber == emp.EmployeeNumber && item.TrainingId == training.TrainingId)
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
                                        if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.TrainingId == training.TrainingId)
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

                            var grouped = trainViewList.GroupBy(c => c.SectionName).Select(g => new
                            {
                                SectionName = g.Key,
                                Count = g.Count(),
                                TApproved = g.Where(a => a.Status == "APPROVED").ToList().Count(),
                                TPending = g.Where(a => a.Status == "PENDING").ToList().Count(),
                                TDeclined = g.Where(a => a.Status == "DECLINED").ToList().Count(),
                            });


                            foreach (var item in grouped)
                            {
                                int countEmp = 0;
                                int countSuper = 0;
                                foreach (var selectItem in trainViewList.Where(c => c.SectionName == item.SectionName))
                                {
                                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == selectItem.EmployeeNumber);
                                    if (selectEmp != null) { countEmp++; }
                                    else { countSuper++; }
                                }

                                completeListView.Add(new CompleteTrainingViews()
                                {
                                    NoOfEmployees = countEmp.ToString("n0"),
                                    NoOfSupervisor = countSuper.ToString("n0"),
                                    SectionName = item.SectionName,
                                    TotalApproved = item.TApproved.ToString("n0"),
                                    TotalDeclined = item.TDeclined.ToString("n0"),
                                    TotalPending = item.TPending.ToString("n0")
                                });
                            }

                            gridView.DataSource = null;
                            gridView.DataSource = completeListView.OrderBy(c => c.SectionName).ToList();
                            gridView.DataBind();

                        }
                        else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                        else // kapag isa lang pinili na section
                        {
                            var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == department.DepartmentId && c.SectionName == cmbSection.Text);
                            DateTime date = Convert.ToDateTime(cmbDate.Text).Date;
                            var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                            var empTrainList = context.CompleteEmployeeTrainings.Where(c => c.DateComplete == date).ToList();

                            foreach (var emp in empList)
                            {
                                foreach (var item in empTrainList)
                                {
                                    if (item.EmployeeNumber == emp.EmployeeNumber && item.TrainingId == training.TrainingId)
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

                            var grouped = trainViewList.GroupBy(c => c.SectionName).Select(g => new
                            {
                                SectionName = g.Key,
                                Count = g.Count(),
                                TApproved = g.Where(a => a.Status == "APPROVED").ToList().Count(),
                                TPending = g.Where(a => a.Status == "PENDING").ToList().Count(),
                                TDeclined = g.Where(a => a.Status == "DECLINED").ToList().Count(),
                            });

                            foreach (var item in grouped)
                            {
                                int countEmp = 0;
                                int countSuper = 0;
                                foreach (var selectItem in trainViewList.Where(c => c.SectionName == item.SectionName))
                                {
                                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == selectItem.EmployeeNumber);
                                    if (selectEmp != null) { countEmp++; }
                                    else { countSuper++; }
                                }

                                completeListView.Add(new CompleteTrainingViews()
                                {
                                    NoOfEmployees = countEmp.ToString("n0"),
                                    NoOfSupervisor = countSuper.ToString("n0"),
                                    SectionName = item.SectionName,
                                    TotalApproved = item.TApproved.ToString("n0"),
                                    TotalDeclined = item.TDeclined.ToString("n0"),
                                    TotalPending = item.TPending.ToString("n0")
                                });
                            }

                            gridView.DataSource = null;
                            gridView.DataSource = completeListView.OrderBy(c => c.SectionName).ToList();
                            gridView.DataBind();
                        }
                        #endregion
                    }
                }
                else // from old emptrain
                {
                    #region NO GOING
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
                                    if (item.EmployeeNumber == emp.EmployeeNumber && item.TrainingId == training.TrainingId)
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
                                    if (item.EmployeeNumber == empTrain.EmployeeNumber && empTrain.TrainingId == training.TrainingId)
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

                        var grouped = trainViewList.GroupBy(c => c.SectionName).Select(g => new
                        {
                            SectionName = g.Key,
                            Count = g.Count(),
                            TApproved = g.Where(a => a.Status == "APPROVED").ToList().Count(),
                            TPending = g.Where(a => a.Status == "PENDING").ToList().Count(),
                            TDeclined = g.Where(a => a.Status == "DECLINED").ToList().Count(),
                        });


                        foreach (var item in grouped)
                        {
                            int countEmp = 0;
                            int countSuper = 0;
                            foreach (var selectItem in trainViewList.Where(c => c.SectionName == item.SectionName))
                            {
                                var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == selectItem.EmployeeNumber);
                                if (selectEmp != null) { countEmp++; }
                                else { countSuper++; }
                            }

                            completeListView.Add(new CompleteTrainingViews()
                            {
                                NoOfEmployees = countEmp.ToString("n0"),
                                NoOfSupervisor = countSuper.ToString("n0"),
                                SectionName = item.SectionName,
                                TotalApproved = item.TApproved.ToString("n0"),
                                TotalDeclined = item.TDeclined.ToString("n0"),
                                TotalPending = item.TPending.ToString("n0")
                            });
                        }

                        gridView.DataSource = null;
                        gridView.DataSource = completeListView.OrderBy(c => c.SectionName).ToList();
                        gridView.DataBind();

                    }
                    else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                    else // kapag isa lang pinili na section
                    {
                        var sec = context.Sections.FirstOrDefault(c => c.DepartmentId == department.DepartmentId && c.SectionName == cmbSection.Text);

                        var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                        var empTrainList = context.EmployeeTrainings.ToList();

                        foreach (var emp in empList)
                        {
                            foreach (var item in empTrainList)
                            {
                                if (item.EmployeeNumber == emp.EmployeeNumber && item.TrainingId == training.TrainingId)
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
                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = item.EmployeeNumber,
                                FullName = emp.FullName,
                                SectionName = sec.SectionName,
                                Status = item.Status
                            });
                        }

                        var grouped = trainViewList.GroupBy(c => c.SectionName).Select(g => new
                        {
                            SectionName = g.Key,
                            Count = g.Count(),
                            TApproved = g.Where(a => a.Status == "APPROVED").ToList().Count(),
                            TPending = g.Where(a => a.Status == "PENDING").ToList().Count(),
                            TDeclined = g.Where(a => a.Status == "DECLINED").ToList().Count(),
                        });

                        foreach (var item in grouped)
                        {
                            int countEmp = 0;
                            int countSuper = 0;
                            foreach (var selectItem in trainViewList.Where(c => c.SectionName == item.SectionName))
                            {
                                var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == selectItem.EmployeeNumber);
                                if (selectEmp != null) { countEmp++; }
                                else { countSuper++; }
                            }

                            completeListView.Add(new CompleteTrainingViews()
                            {
                                NoOfEmployees = countEmp.ToString("n0"),
                                NoOfSupervisor = countSuper.ToString("n0"),
                                SectionName = item.SectionName,
                                TotalApproved = item.TApproved.ToString("n0"),
                                TotalDeclined = item.TDeclined.ToString("n0"),
                                TotalPending = item.TPending.ToString("n0")
                            });
                        }
                        gridView.DataSource = null;
                        gridView.DataSource = completeListView.OrderBy(c => c.SectionName).ToList();
                        gridView.DataBind();

                    }
                    #endregion
                }
            }

            return completeListView.OrderBy(c => c.SectionName).ToList(); ;
        }
    }

    // eto yung lalagay mo pang completed na training
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

    public void ReloadDate()
    {
        using (var context = new DatabaseContext())
        {
            cmbDate.Items.Clear();
            if (cmbStatus.Text == "COMPLETED")
            {
                var trainList = context.Trainings.OrderBy(c => c.TrainingTitle).ToList();
                if (trainList.Count > 0)
                {
                    var select = context.Trainings.FirstOrDefault(c => c.TrainingTitle == cmbTraining.Text);
                    var list = context.CompleteEmployeeTrainings.Where(c => c.TrainingId == select.TrainingId).ToList();
                    var reducedList = list.Select(e => new { e.DateComplete }).Distinct().ToList();
                    foreach (var item in reducedList) { cmbDate.Items.Add(item.DateComplete.ToString("MMMM dd, yyyy")); }
                }
            }
        }
    }

    public void ReloadTraining()
    {
        using (var context = new DatabaseContext())
        {
            cmbTraining.Items.Clear();
            if (cmbStatus.Text == "COMPLETED")
            {
                var compList = context.CompleteEmployeeTrainings.ToList();
                var reducedList = compList.Select(e => new { e.TrainingId }).Distinct().ToList();

                foreach (var item in reducedList)
                {
                    var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingId == item.TrainingId);
                    cmbTraining.Items.Add(selectTrain.TrainingTitle);
                }
            }
            else
            {
                var trainList = context.Trainings.OrderBy(c => c.TrainingTitle).ToList();
                if (trainList.Count > 0) { foreach (var item in trainList) { cmbTraining.Items.Add(item.TrainingTitle); } }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ReloadTraining();   // eto yung lalagay mo pang completed na training
            ReloadDate();
            ReloadDepartment();
            ReloadSection();
            Refresh();
            RefreshEmployee(); // eto yung lalagay mo pang completed na training
        }
    }
    // eto yung lalagay mo pang completed na training
    protected void cmbTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadDate();
        Refresh();
        RefreshEmployee();   // eto yung lalagay mo pang completed na training
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
        ReloadTraining();
        ReloadDate();
        Refresh();
    }

    protected void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Refresh();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        List<CompleteTrainingViews> completeListView = new List<CompleteTrainingViews>();
        completeListView.Clear();
        completeListView = ExcelReload();
        using (var context = new DatabaseContext())
        {
            if (completeListView.Count() > 0)
            {
                // Configure open file dialog box
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = " STATUS OF TRAININGS " + DateTime.Now.ToString("dd-MMM-yyyy"); // Default file name
                dlg.DefaultExt = ".csv"; // Default file extension
                dlg.Filter = "CSV Files (.csv)|*.csv"; // Filter files by extension

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    FileHelperEngine engine = new FileHelperEngine(typeof(TrainingViews));
                    engine.HeaderText = "STATUS OF TRAININGS";
                    engine.WriteFile(dlg.FileName, completeListView, completeListView.Count);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Export to excel successful.');</script>");
                }
            }
        }
    }
}