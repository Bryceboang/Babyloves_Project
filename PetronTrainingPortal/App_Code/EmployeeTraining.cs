using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeTraining
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class EmployeeTraining
    {
        [Key]
        [Column(Order = 1)]
        public string EmployeeNumber { get; set; }

        [Key]
        [Column(Order = 2)]
        public int TrainingId { get; set; }
        public string Status { get; set; }
    }
}