using System;
using System.ComponentModel.DataAnnotations;

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
        [DisplayFormat(NullDisplayText = "N/A")]
        public int? CaseTypeID { get; set; }
        public virtual CaseType CaseType { get; set; }

        [Display(Name = "Address")]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        // TODO Details - basic details.

        // TODO Last Updated.

        // TODO End Date - nullable.

        // TODO ACI - nullable.
        [Display(Name = "ACI")]
        public int? AddressChangeIntelligenceID { get; set; }
        public virtual AddressChangeIntelligence AddressChangeIntelligence { get; set; }

        // TODO ACI Date - nullable.

        // TODO Planning Ref - nullable.

        // TODO Building Control Ref - nullable.

        // TODO Revenues Ref - nullable.

        // TODO Contacts - nullable.
    }
}