using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace snn.Models
{
    public class Case
    {
        [Key]
        public int CaseID { get; set; }

        [Display(Name = "Case Number")]
        public string CaseNumber
        {
            get
            {
                return string.Format("SNN/{0}", CaseID);
            }
        }

        [Display(Name = "Case Status")]
        public int CaseStatusID { get; set; }
        public virtual CaseStatus CaseStatus { get; set; }

        [Display(Name = "Case Type")]
        public int CaseTypeID { get; set; }
        public virtual CaseType CaseType { get; set; }
    }
}