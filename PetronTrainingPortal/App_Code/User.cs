using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class User
    {
        [Key]
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public string AccessType { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public string Email { get; set; }
    }
}