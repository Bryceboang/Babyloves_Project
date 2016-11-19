using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Section
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int DepartmentId { get; set; }
    }
}