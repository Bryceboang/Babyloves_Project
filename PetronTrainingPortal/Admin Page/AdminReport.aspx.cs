using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Page_AdminReport : System.Web.UI.Page
{

    //public void Refresh()
    //{
    //    List<TrainingViews> trainViewList = new List<TrainingViews>();
    //    trainViewList.Clear();

    //    using (var context = new DatabaseContext())
    //    {
    //        var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
    //        var department = context.Departments.FirstOrDefault(c => c.DepartmentName == cmbDepartment.Text);
    //        if (training == null)
    //        {
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a training first." + "');", true);
    //        }
    //        else if (department == null)
    //        {
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a department first." + "');", true);
    //        }
    //        else
    //        {
    //            var section = context.Sections.FirstOrDefault(c => c.SectionName == cmbSection.Text);
    //            if (cmbSection.Text == "ALL")
    //            {
    //                var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
    //                foreach (var item in empTrainList)
    //                {
    //                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
    //                    if (selectEmp != null)
    //                    {
    //                        var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
    //                        var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
    //                        if (department.DepartmentId == empDept.DepartmentId)
    //                        {
    //                            trainViewList.Add(new TrainingViews()
    //                            {
    //                                DepartmentName = department.DepartmentName,
    //                                EmployeeNumber = item.EmployeeNumber,
    //                                FullName = selectEmp.FullName,
    //                                SectionName = selectedSec.SectionName,
    //                                Status = item.Status
    //                            });
    //                        }
    //                    }
    //                    else
    //                    {
    //                        var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
    //                        var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
    //                        var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
    //                        if (department.DepartmentId == empDept.DepartmentId)
    //                        {
    //                            trainViewList.Add(new TrainingViews()
    //                            {
    //                                DepartmentName = department.DepartmentName,
    //                                EmployeeNumber = item.EmployeeNumber,
    //                                FullName = selectUser.FullName,
    //                                SectionName = selectedSec.SectionName,
    //                                Status = item.Status
    //                            });
    //                        }
    //                    }


    //                }
    //            }
    //            else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
    //            else
    //            {
    //                var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
    //                foreach (var item in empTrainList)
    //                {
    //                    var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
    //                    if (selectEmp != null)
    //                    {
    //                        var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
    //                        var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
    //                        if (department.DepartmentId == empDept.DepartmentId)
    //                        {
    //                            trainViewList.Add(new TrainingViews()
    //                            {
    //                                DepartmentName = department.DepartmentName,
    //                                EmployeeNumber = item.EmployeeNumber,
    //                                FullName = selectEmp.FullName,
    //                                SectionName = selectedSec.SectionName,
    //                                Status = item.Status
    //                            });
    //                        }
    //                    }
    //                    else
    //                    {
    //                        var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
    //                        var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
    //                        var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
    //                        if (department.DepartmentId == empDept.DepartmentId)
    //                        {
    //                            trainViewList.Add(new TrainingViews()
    //                            {
    //                                DepartmentName = department.DepartmentName,
    //                                EmployeeNumber = item.EmployeeNumber,
    //                                FullName = selectUser.FullName,
    //                                SectionName = selectedSec.SectionName,
    //                                Status = item.Status
    //                            });
    //                        }
    //                    }

    //                }
    //                trainViewList = trainViewList.Where(c => c.SectionName == cmbSection.Text).ToList();
    //            }
    //        }

    //        gridView.DataSource = null;
    //        gridView.DataSource = trainViewList.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
    //        gridView.DataBind();

    //        if (cmbStatus.Text == "PENDING") { this.gridView.Columns[5].Visible = true; this.gridView.Columns[4].Visible = false; this.gridView.Columns[3].Visible = false; }
    //        else if (cmbStatus.Text == "APPROVED") { this.gridView.Columns[4].Visible = true; this.gridView.Columns[5].Visible = false; this.gridView.Columns[3].Visible = false; }
    //        else { this.gridView.Columns[3].Visible = true; this.gridView.Columns[4].Visible = false; this.gridView.Columns[5].Visible = false; }
    //    }
    //}

    public struct DateTimeSpan
    {
        private readonly int years;
        private readonly int months;
        private readonly int days;
        private readonly int hours;
        private readonly int minutes;
        private readonly int seconds;
        private readonly int milliseconds;

        public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
        {
            this.years = years;
            this.months = months;
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;
        }

        public int Years { get { return years; } }
        public int Months { get { return months; } }
        public int Days { get { return days; } }
        public int Hours { get { return hours; } }
        public int Minutes { get { return minutes; } }
        public int Seconds { get { return seconds; } }
        public int Milliseconds { get { return milliseconds; } }

        enum Phase { Years, Months, Days, Done }

        public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
        {
            if (date2 < date1)
            {
                var sub = date1;
                date1 = date2;
                date2 = sub;
            }

            DateTime current = date1;
            int years = 0;
            int months = 0;
            int days = 0;

            Phase phase = Phase.Years;
            DateTimeSpan span = new DateTimeSpan();
            int officialDay = current.Day;

            while (phase != Phase.Done)
            {
                switch (phase)
                {
                    case Phase.Years:
                        if (current.AddYears(years + 1) > date2)
                        {
                            phase = Phase.Months;
                            current = current.AddYears(years);
                        }
                        else
                        {
                            years++;
                        }
                        break;
                    case Phase.Months:
                        if (current.AddMonths(months + 1) > date2)
                        {
                            phase = Phase.Days;
                            current = current.AddMonths(months);
                            if (current.Day < officialDay && officialDay <= DateTime.DaysInMonth(current.Year, current.Month))
                                current = current.AddDays(officialDay - current.Day);
                        }
                        else
                        {
                            months++;
                        }
                        break;
                    case Phase.Days:
                        if (current.AddDays(days + 1) > date2)
                        {
                            current = current.AddDays(days);
                            var timespan = date2 - current;
                            span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                            phase = Phase.Done;
                        }
                        else
                        {
                            days++;
                        }
                        break;
                }
            }

            return span;
        }
    }

    public void Refresh()
    {
        List<TrainingViews> trainViewList = new List<TrainingViews>();
        trainViewList.Clear();

        using (var context = new DatabaseContext())
        {
            var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
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

                if (cmbStatus.Text == "APPROVED")
                {
                    if (cmbSection.Text == "ALL")
                    {
                        var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
                        foreach (var item in empTrainList)
                        {
                            var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            if (selectEmp != null)
                            {
                                var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
                                var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
                                if (department.DepartmentId == empDept.DepartmentId)
                                {

                                    #region Service Year Computations
                                    DateTime start = selectEmp.DateHired;
                                    DateTime now = DateTime.Now.Date;
                                    string serviceYears = string.Empty;
                                    var dateSpan = DateTimeSpan.CompareDates(start, now);
                                    string yearString = string.Empty;
                                    string monthString = string.Empty;
                                    int years = dateSpan.Years;
                                    int months = dateSpan.Months;

                                    if (years > 0)
                                    {
                                        if (years > 1) { yearString = "years"; } else { yearString = "year"; }
                                        if (months > 1) { monthString = "months"; } else { monthString = "years"; }

                                        if (months > 0) { serviceYears = years + " " + yearString + " and " + months + " " + monthString; }
                                        else { serviceYears = years + " " + yearString; }
                                    }
                                    else
                                    {
                                        if (months > 1) { monthString = "months"; } else { monthString = "years"; }
                                        if (months > 0) { serviceYears = months + " " + monthString; }
                                    }
                                    #endregion

                                    trainViewList.Add(new TrainingViews()
                                    {
                                        DepartmentName = department.DepartmentName,
                                        EmployeeNumber = item.EmployeeNumber,
                                        FullName = selectEmp.FullName,
                                        SectionName = selectedSec.SectionName,
                                        Status = item.Status,
                                        ServiceYears = serviceYears
                                    });
                                }
                            }
                            else
                            {
                                var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                                var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
                                var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
                                if (department.DepartmentId == empDept.DepartmentId)
                                {

                                    trainViewList.Add(new TrainingViews()
                                    {
                                        DepartmentName = department.DepartmentName,
                                        EmployeeNumber = item.EmployeeNumber,
                                        FullName = selectUser.FullName,
                                        SectionName = selectedSec.SectionName,
                                        Status = item.Status
                                    });
                                }
                            }


                        }
                    }
                    else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                    else // kapag isang section lang ang selected
                    {
                        var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
                        foreach (var item in empTrainList)
                        {
                            var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            if (selectEmp != null)
                            {
                                var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
                                var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
                                if (department.DepartmentId == empDept.DepartmentId)
                                {
                                    #region Service Year Computations
                                    DateTime start = selectEmp.DateHired;
                                    DateTime now = DateTime.Now.Date;
                                    string serviceYears = string.Empty;
                                    var dateSpan = DateTimeSpan.CompareDates(start, now);
                                    string yearString = string.Empty;
                                    string monthString = string.Empty;
                                    int years = dateSpan.Years;
                                    int months = dateSpan.Months;

                                    if (years > 0)
                                    {
                                        if (years > 1) { yearString = "years"; } else { yearString = "year"; }
                                        if (months > 1) { monthString = "months"; } else { monthString = "years"; }

                                        if (months > 0) { serviceYears = years + " " + yearString + " and " + months + " " + monthString; }
                                        else { serviceYears = years + " " + yearString; }
                                    }
                                    else
                                    {
                                        if (months > 1) { monthString = "months"; } else { monthString = "years"; }
                                        if (months > 0) { serviceYears = months + " " + monthString; }
                                    }
                                    #endregion

                                    trainViewList.Add(new TrainingViews()
                                    {
                                        DepartmentName = department.DepartmentName,
                                        EmployeeNumber = item.EmployeeNumber,
                                        FullName = selectEmp.FullName,
                                        SectionName = selectedSec.SectionName,
                                        Status = item.Status,
                                        ServiceYears = serviceYears
                                    });
                                }
                            }
                            else
                            {
                                var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                                var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
                                var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
                                if (department.DepartmentId == empDept.DepartmentId)
                                {
                                    trainViewList.Add(new TrainingViews()
                                    {
                                        DepartmentName = department.DepartmentName,
                                        EmployeeNumber = item.EmployeeNumber,
                                        FullName = selectUser.FullName,
                                        SectionName = selectedSec.SectionName,
                                        Status = item.Status
                                    });
                                }
                            }

                        }
                        trainViewList = trainViewList.Where(c => c.SectionName == cmbSection.Text).ToList();
                    }
                }
                else if (cmbStatus.Text == "PENDING")
                {
                    if (cmbSection.Text == "ALL")
                    {
                        var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
                        foreach (var item in empTrainList)
                        {
                            var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            if (selectEmp != null)
                            {
                                var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
                                var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
                                if (department.DepartmentId == empDept.DepartmentId)
                                {
                                    #region Service Year Computations
                                    DateTime start = selectEmp.DateHired;
                                    DateTime now = DateTime.Now.Date;
                                    string serviceYears = string.Empty;
                                    var dateSpan = DateTimeSpan.CompareDates(start, now);
                                    string yearString = string.Empty;
                                    string monthString = string.Empty;
                                    int years = dateSpan.Years;
                                    int months = dateSpan.Months;

                                    if (years > 0)
                                    {
                                        if (years > 1) { yearString = "years"; } else { yearString = "year"; }
                                        if (months > 1) { monthString = "months"; } else { monthString = "years"; }

                                        if (months > 0) { serviceYears = years + " " + yearString + " and " + months + " " + monthString; }
                                        else { serviceYears = years + " " + yearString; }
                                    }
                                    else
                                    {
                                        if (months > 1) { monthString = "months"; } else { monthString = "years"; }
                                        if (months > 0) { serviceYears = months + " " + monthString; }
                                    }
                                    #endregion

                                    trainViewList.Add(new TrainingViews()
                                    {
                                        DepartmentName = department.DepartmentName,
                                        EmployeeNumber = item.EmployeeNumber,
                                        FullName = selectEmp.FullName,
                                        SectionName = selectedSec.SectionName,
                                        Status = item.Status,
                                        ServiceYears = serviceYears
                                    });
                                }
                            }
                            else
                            {
                                var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                                var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
                                var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
                                if (department.DepartmentId == empDept.DepartmentId)
                                {
                                    trainViewList.Add(new TrainingViews()
                                    {
                                        DepartmentName = department.DepartmentName,
                                        EmployeeNumber = item.EmployeeNumber,
                                        FullName = selectUser.FullName,
                                        SectionName = selectedSec.SectionName,
                                        Status = item.Status
                                    });
                                }
                            }


                        }
                    }
                    else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                    else // kapag isang section lang ang selected
                    {
                        var empTrainList = context.EmployeeTrainings.Where(c => c.Status == cmbStatus.Text && c.TrainingId == training.TrainingId).ToList();
                        foreach (var item in empTrainList)
                        {
                            var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                            if (selectEmp != null)
                            {
                                var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);
                                var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectEmp.DepartmentId);
                                if (department.DepartmentId == empDept.DepartmentId)
                                {
                                    #region Service Year Computations
                                    DateTime start = selectEmp.DateHired;
                                    DateTime now = DateTime.Now.Date;
                                    string serviceYears = string.Empty;
                                    var dateSpan = DateTimeSpan.CompareDates(start, now);
                                    string yearString = string.Empty;
                                    string monthString = string.Empty;
                                    int years = dateSpan.Years;
                                    int months = dateSpan.Months;

                                    if (years > 0)
                                    {
                                        if (years > 1) { yearString = "years"; } else { yearString = "year"; }
                                        if (months > 1) { monthString = "months"; } else { monthString = "years"; }

                                        if (months > 0) { serviceYears = years + " " + yearString + " and " + months + " " + monthString; }
                                        else { serviceYears = years + " " + yearString; }
                                    }
                                    else
                                    {
                                        if (months > 1) { monthString = "months"; } else { monthString = "years"; }
                                        if (months > 0) { serviceYears = months + " " + monthString; }
                                    }
                                    #endregion
                                    trainViewList.Add(new TrainingViews()
                                    {
                                        DepartmentName = department.DepartmentName,
                                        EmployeeNumber = item.EmployeeNumber,
                                        FullName = selectEmp.FullName,
                                        SectionName = selectedSec.SectionName,
                                        Status = item.Status,
                                        ServiceYears = serviceYears
                                    });
                                }
                            }
                            else
                            {
                                var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                                var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);
                                var empDept = context.Departments.FirstOrDefault(c => c.DepartmentId == selectUser.DepartmentId);
                                if (department.DepartmentId == empDept.DepartmentId)
                                {
                                    trainViewList.Add(new TrainingViews()
                                    {
                                        DepartmentName = department.DepartmentName,
                                        EmployeeNumber = item.EmployeeNumber,
                                        FullName = selectUser.FullName,
                                        SectionName = selectedSec.SectionName,
                                        Status = item.Status
                                    });
                                }
                            }

                        }
                        trainViewList = trainViewList.Where(c => c.SectionName == cmbSection.Text).ToList();
                    }
                }
                else // NO Status 
                {
                    if (cmbSection.Text == "ALL")
                    {
                        var listEmpTrain = context.EmployeeTrainings.Where(c => c.TrainingId == training.TrainingId).Select(c => c.EmployeeNumber).ToList();

                        var allEmp = context.Employees.Where(c => c.DepartmentId == department.DepartmentId).Select(c => c.EmployeeNumber).ToList();

                        var newListEmp = allEmp.Except(listEmpTrain).ToList();

                        foreach (var item in newListEmp)
                        {
                            var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);

                            #region Service Year Computations
                            DateTime start = selectEmp.DateHired;
                            DateTime now = DateTime.Now.Date;
                            string serviceYears = string.Empty;
                            var dateSpan = DateTimeSpan.CompareDates(start, now);
                            string yearString = string.Empty;
                            string monthString = string.Empty;
                            int years = dateSpan.Years;
                            int months = dateSpan.Months;

                            if (years > 0)
                            {
                                if (years > 1) { yearString = "years"; } else { yearString = "year"; }
                                if (months > 1) { monthString = "months"; } else { monthString = "years"; }

                                if (months > 0) { serviceYears = years + " " + yearString + " and " + months + " " + monthString; }
                                else { serviceYears = years + " " + yearString; }
                            }
                            else
                            {
                                if (months > 1) { monthString = "months"; } else { monthString = "years"; }
                                if (months > 0) { serviceYears = months + " " + monthString; }
                            }
                            #endregion

                            trainViewList.Add(new TrainingViews()
                                  {
                                      DepartmentName = department.DepartmentName,
                                      EmployeeNumber = selectEmp.EmployeeNumber,
                                      FullName = selectEmp.FullName,
                                      SectionName = selectedSec.SectionName,
                                      Status = "",
                                      ServiceYears = serviceYears
                                  });
                        }

                        var selectSupervisorList = context.Users.Where(c => c.DepartmentId == department.DepartmentId && c.AccessType.ToLower() == "supervisor").Select(c => c.EmployeeNumber).ToList();

                        var newListSuper = selectSupervisorList.Except(listEmpTrain).ToList();

                        foreach (var item in newListSuper)
                        {
                            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);

                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = selectUser.EmployeeNumber,
                                FullName = selectUser.FullName,
                                SectionName = selectedSec.SectionName,
                                Status = ""
                            });
                        }

                    }
                    else if (section == null) { Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a section first." + "');", true); }
                    else // kapag isang section lang ang selected
                    {

                        var listEmpTrain = context.EmployeeTrainings.Where(c => c.TrainingId == training.TrainingId).Select(c => c.EmployeeNumber).ToList();

                        var allEmp = context.Employees.Where(c => c.DepartmentId == department.DepartmentId && c.SectionId == section.SectionId).Select(c => c.EmployeeNumber).ToList();

                        var newListEmp = allEmp.Except(listEmpTrain).ToList();

                        foreach (var item in newListEmp)
                        {
                            var selectEmp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectEmp.SectionId);

                            #region Service Year Computations
                            DateTime start = selectEmp.DateHired;
                            DateTime now = DateTime.Now.Date;
                            string serviceYears = string.Empty;
                            var dateSpan = DateTimeSpan.CompareDates(start, now);
                            string yearString = string.Empty;
                            string monthString = string.Empty;
                            int years = dateSpan.Years;
                            int months = dateSpan.Months;

                            if (years > 0)
                            {
                                if (years > 1) { yearString = "years"; } else { yearString = "year"; }
                                if (months > 1) { monthString = "months"; } else { monthString = "years"; }

                                if (months > 0) { serviceYears = years + " " + yearString + " and " + months + " " + monthString; }
                                else { serviceYears = years + " " + yearString; }
                            }
                            else
                            {
                                if (months > 1) { monthString = "months"; } else { monthString = "years"; }
                                if (months > 0) { serviceYears = months + " " + monthString; }
                            }
                            #endregion

                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = selectEmp.EmployeeNumber,
                                FullName = selectEmp.FullName,
                                SectionName = selectedSec.SectionName,
                                Status = "",
                                ServiceYears = serviceYears
                            });
                        }

                        var selectSupervisorList = context.Users.Where(c => c.DepartmentId == department.DepartmentId && c.SectionId == section.SectionId && c.AccessType.ToLower() == "supervisor").Select(c => c.EmployeeNumber).ToList();

                        var newListSuper = selectSupervisorList.Except(listEmpTrain).ToList();

                        foreach (var item in newListSuper)
                        {
                            var selectUser = context.Users.FirstOrDefault(c => c.EmployeeNumber == item);
                            var selectedSec = context.Sections.FirstOrDefault(c => c.SectionId == selectUser.SectionId);

                            trainViewList.Add(new TrainingViews()
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeNumber = selectUser.EmployeeNumber,
                                FullName = selectUser.FullName,
                                SectionName = selectedSec.SectionName,
                                Status = ""
                            });
                        }
                    }
                }
            }

            gridView.DataSource = null;
            gridView.DataSource = trainViewList.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
            gridView.DataBind();

            if (cmbStatus.Text == "PENDING") { this.gridView.Columns[5].Visible = true; this.gridView.Columns[4].Visible = false; this.gridView.Columns[3].Visible = false; }
            else if (cmbStatus.Text == "APPROVED") { this.gridView.Columns[4].Visible = true; this.gridView.Columns[5].Visible = false; this.gridView.Columns[3].Visible = false; }
            else { this.gridView.Columns[3].Visible = true; this.gridView.Columns[4].Visible = false; this.gridView.Columns[5].Visible = false; }
        }

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

    public void ReloadTraining()
    {
        lblEmpNoMsg.Text = string.Empty;
        using (var context = new DatabaseContext())
        {
            List<TrainingReportViews> trainView = new List<TrainingReportViews>();
            trainView.Clear();
            lblTrainingTitle.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtTrainingCode.Text) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Please enter a training code.');</script>");
            }
            else
            {
                var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (training == null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('This training code doesn't exist.');</script>");
                    lblEmpNoMsg.Text = "This employee number doesn't exist.";
                }
                else
                {
                    lblTrainingTitle.Text = training.TrainingTitle;


                    trainView.Add(new TrainingReportViews()
                    {
                        //DateDuration = training.DateStart,
                        TargetParticipants = training.TargetParticipants,
                        TimeDuration = training.TimeDuration,
                        TrainingProvider = training.TrainingProvider,
                        TrainingVenue = training.Venue
                    });

                }
            }

            gridTraining.DataSource = null;
            gridTraining.DataSource = trainView.ToList();
            gridTraining.DataBind();
        }
    }

    public void gridView_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            if (e.CommandName == "Nominate") // Kapag combobox ay no status
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridView.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[1];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (selectTrain != null)
                {
                    EmployeeTraining empTraining = new EmployeeTraining()
                    {
                        EmployeeNumber = empNo,
                        Status = "PENDING",
                        TrainingId = selectTrain.TrainingId
                    };
                    context.EmployeeTrainings.Add(empTraining);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Selected employee is now Nominated.');</script>");
                    Refresh();
                }
            }
            else if (e.CommandName == "Reject") // kapag combobox ay reject
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridView.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[1];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (selectTrain != null)
                {
                    var empTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == empNo && c.TrainingId == selectTrain.TrainingId);
                    empTrain.Status = "REJECTED";
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Selected employee status is now REJECTED.');</script>");
                    Refresh();
                }
            }
            else // kapag status nya ay pending
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gridView.Rows[index];
                TableCell employeeNumber = selectedRow.Cells[1];
                string empNo = employeeNumber.Text;
                var selectTrain = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());
                if (selectTrain != null)
                {
                    var empTrain = context.EmployeeTrainings.FirstOrDefault(c => c.EmployeeNumber == empNo && c.TrainingId == selectTrain.TrainingId);
                    context.EmployeeTrainings.Remove(empTrain);
                    context.SaveChanges();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Selected employee is removed.');</script>");
                    Refresh();
                }
            }
        }
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
        gridView.DataSource = null;
        gridView.DataBind();
        Refresh();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            using (var context = new DatabaseContext())
            {
                ReloadDepartment();
                ReloadSection();
                //Refresh();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ReloadTraining();
        Refresh();
    }
}