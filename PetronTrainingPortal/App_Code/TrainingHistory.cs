using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TrainingHistory
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class TrainingHistory
    {
        [Key]
        [Column(Order = 1)]
        public string EmployeeNumber { get; set; }

        [Key]
        [Column(Order = 2)]
        public int TrainingId { get; set; }
        public string Comment { get; set; }
        public DateTime DateComplete { get; set; }
    }
}