using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class Employee
    {
        [Key]
        public string EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public DateTime DateHired { get; set; }
    }
}