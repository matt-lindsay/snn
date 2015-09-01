using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace snn.Models
{
    public class CaseStatus
    {
        [Key]
        public int CaseStatusID { get; set; }

        [Display(Name = "Status")]
        public string StatusDescription { get; set; }

        public virtual List<Case> Case { get; set; }
    }
}