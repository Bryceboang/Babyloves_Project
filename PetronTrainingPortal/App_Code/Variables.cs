using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Variables
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class Variables
    {
        public static string EmployeeNumber { get; set; }
        public static string AccessType { get; set; }
        public static string empNo { get; set; }
        public static int deptNo { get; set; }
        public static int secNo { get; set; }
        //public static string OnsiteCode { get; set; }
        public static string code { get; set; }
        public static string submitCode { get; set; }
        public static int submitShopTrainingId { get; set; }
        public static string checkOutCode { get; set; }
        public static int shopTrainingId { get; set; }
        public static int queryNum { get; set; }
        public static int selectedSecId { get; set; }
        public static string currentcmbSec { get; set; }
    }

    public class EmployeeNomineeViews
    {
        public int NomineeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string ServiceYears { get; set; }
        public string Status { get; set; }
    }


    public class TrainingViews
    {
        public string EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string AccessType { get; set; }
        public string DateHired { get; set; }
        public string ServiceYears { get; set; }
    }

    public class CompleteTrainingViews
    {
        public string SectionName { get; set; }
        public string NoOfEmployees { get; set; }
        public string NoOfSupervisor { get; set; }
        public string TotalApproved { get; set; }
        public string TotalDeclined { get; set; }
        public string TotalPending { get; set; }
    }

    public class TrainingReportViews
    {
        public string TrainingTitle { get; set; }
        public string TrainingVenue { get; set; }
        public string DateDuration { get; set; }
        public string TimeDuration { get; set; }
        public string TrainingProvider { get; set; }
        public string TargetParticipants { get; set; }
    }

    public class DepartmentViews
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class CapacityRemainingViews
    {
        public string MaxNumber { get; set; }
        public string Remaining { get; set; }
    }

    public class TrainingCapacityViews
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Capacity { get; set; }
    }

    public class SectionViews
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
    }


    public class EmployeeTrainingViews
    {
        public string EmployeeNumber { get; set; }
        public int TrainingId { get; set; }
        public string Status { get; set; }
    }


    public class Age
    {
        public int Years;
        public int Months;
        public int Days;

        public Age(DateTime Bday)
        {
            this.Count(Bday);
        }

        public Age(DateTime Bday, DateTime Cday)
        {
            this.Count(Bday, Cday);
        }

        public Age Count(DateTime Bday)
        {
            return this.Count(Bday, DateTime.Today);
        }

        public Age Count(DateTime Bday, DateTime Cday)
        {
            if ((Cday.Year - Bday.Year) > 0 ||
                (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||
                  ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);

                if (Cday.Month > Bday.Month)
                {
                    this.Years = Cday.Year - Bday.Year;
                    this.Months = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (Cday.Month == Bday.Month)
                {
                    if (Cday.Day >= Bday.Day)
                    {
                        this.Years = Cday.Year - Bday.Year;
                        this.Months = 0;
                        this.Days = Cday.Day - Bday.Day;
                    }
                    else
                    {
                        this.Years = (Cday.Year - 1) - Bday.Year;
                        this.Months = 11;
                        this.Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
                    }
                }
                else
                {
                    this.Years = (Cday.Year - 1) - Bday.Year;
                    this.Months = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
            }
            else
            {
                throw new ArgumentException("Birthday date must be earlier than current date");
            }
            return this;
        }
    }


}