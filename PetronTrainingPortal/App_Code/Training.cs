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
        public string DateDuration { get; set; }
        public string TimeDuration { get; set; }
        public string TrainingProvider { get; set; }
        public string TargetParticipants { get; set; }

    }
}