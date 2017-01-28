using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TrainingCapacity
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class TrainingCapacity
    {
        [Key]
        public int TrainingCapacityId { get; set; }
        public int TrainingId { get; set; }
        public int DepartmentId { get; set; }
        public int Capacity { get; set; }
        public int CurrentCount { get; set; }
    }
}