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
    }

    public class TrainingViews
    {
        public string EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string Status { get; set; }
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

    public class EmployeeTrainingViews
    {
        public string EmployeeNumber { get; set; }
        public int TrainingId { get; set; }
        public string Status { get; set; }
    }


}