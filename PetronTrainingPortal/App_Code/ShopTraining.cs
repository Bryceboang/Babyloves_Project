using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShopTraining
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class ShopTraining
    {
        [Key]
        public int ShopTrainingId { get; set; }
        public string TrainingCode { get; set; }
        public string EmployeeNumber { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsConfirmedByManger { get; set; }
        public bool IsComfirmedByAdmin { get; set; }
        public int SectionId { get; set; }
    }
}