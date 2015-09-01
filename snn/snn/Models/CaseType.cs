using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace snn.Models
{
    public class CaseType
    {
        [Key]
        public int CaseTypeID { get; set; }

        [Display(Name = "Type")]
        public string TypeDescription { get; set; }

        public virtual List<Case> Case { get; set; }
    }
}