using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Training
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class Training
    {
        [Key]
        public int TrainingId { get; set; }
        public string TrainingCode { get; set; }
        public string TrainingTitle { get; set; }
        public string Venue { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string TimeDuration { get; set; }
        public string TrainingProvider { get; set; }
        public string TargetParticipants { get; set; }
        public string TrainingObjectives { get; set; }
        public string CourseOutline { get; set; }
        public string TrainingType { get; set; }
        public int IsCompleted { get; set; }
        public string Status { get; set; }
    }
}