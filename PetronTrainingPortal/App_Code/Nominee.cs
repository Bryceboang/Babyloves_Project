using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Nominee
/// </summary>
namespace PetronTrainingPortal.App_Code
{
    public class Nominee
    {
        [Key]
        public int NomineeId { get; set; }

        public string EmployeeNumber { get; set; }
        public int ShopTrainingId { get; set; }
        public string Status { get; set; }
    }
}