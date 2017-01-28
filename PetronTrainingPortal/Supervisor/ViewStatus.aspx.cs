using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Supervisor_ViewStatus : System.Web.UI.Page
{

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

    public void ReloadTraining()
    {
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
                }
                else
                {
                    lblTrainingTitle.Text = training.TrainingTitle;


                    trainView.Add(new TrainingReportViews()
                    {
                        DateDuration = training.DateDuration,
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

    public void EmployeeReload()
    {
        using (var context = new DatabaseContext())
        {
            List<EmployeeTrainingViews> empListView = new List<EmployeeTrainingViews>();
            empListView.Clear();
            List<TrainingViews> trainListView = new List<TrainingViews>();
            trainListView.Clear();

            var empNo = Session["EmpNo"].ToString();
            var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == empNo);
            if (user != null)
            {
                var dept = context.Departments.FirstOrDefault(c => c.DepartmentId == user.DepartmentId);
                var sec = context.Sections.FirstOrDefault(c => c.SectionId == user.SectionId);

                var empList = context.Employees.Where(c => c.SectionId == sec.SectionId).ToList();
                var empTrainList = context.EmployeeTrainings.ToList();
                var training = context.Trainings.FirstOrDefault(c => c.TrainingCode.ToLower() == txtTrainingCode.Text.ToLower());

                foreach (var emp in empList)
                {
                    foreach (var item in empTrainList)
                    {
                        if (item.EmployeeNumber == emp.EmployeeNumber && item.Status == "PENDING" && item.TrainingId == training.TrainingId)
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

                foreach (var item in empListView)
                {
                    var emp = context.Employees.FirstOrDefault(c => c.EmployeeNumber == item.EmployeeNumber);
                    #region Service Year Computations
                    DateTime start = emp.DateHired;
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
                    trainListView.Add(new TrainingViews()
                    {
                        DepartmentName = dept.DepartmentName,
                        EmployeeNumber = item.EmployeeNumber,
                        FullName = emp.FullName,
                        SectionName = sec.SectionName,
                        Status = item.Status,
                        ServiceYears = serviceYears
                    });
                }
            }

            gridEmployee.DataSource = null;
            gridEmployee.DataSource = trainListView.OrderBy(c => c.DepartmentName).ThenBy(c => c.SectionName).ThenBy(c => c.FullName).ToList();
            gridEmployee.DataBind();
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpNo"] == null)
        {
            Response.Redirect("~/Main Page/Login.aspx");
        }
        else if (Session["AccountType"] == "Admin")
        {
            Response.Redirect("~/Admin Page/ReportAdmin.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Administrator only" + "');", true);
        }
        else if (Session["AccountType"] == "Manager")
        {
            Response.Redirect("~/Manager/TrainingApproval.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Administrator only" + "');", true);
        }

        if (!Page.IsPostBack)
        {
            using (var context = new DatabaseContext())
            {
                var empNo = Session["EmpNo"].ToString();
                var user = context.Users.FirstOrDefault(c => c.EmployeeNumber == empNo);
                if (user != null)
                {
                    var dept = context.Departments.FirstOrDefault(c => c.DepartmentId == user.DepartmentId);
                    var sec = context.Sections.FirstOrDefault(c => c.SectionId == user.SectionId);
                    lblDepartment.Text = dept.DepartmentName;
                    lblSection.Text = sec.SectionName;
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ReloadTraining();
        if (string.IsNullOrEmpty(lblTrainingTitle.Text) != true)
        {
            EmployeeReload();
        }
        else
        {
            gridEmployee.DataSource = null;
            gridEmployee.DataBind();
        }
    }
}