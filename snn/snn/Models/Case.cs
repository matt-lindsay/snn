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

        // TODO Start Date.

        // TODO Details - basic details.

        // TODO Last Updated.

        // TODO End Date - nullable.

        // TODO ACI - nullable.

        // TODO ACI Date - nullable.

        // TODO Planning Ref - nullable.

        // TODO Building Control Ref - nullable.

        // TODO Revenues Ref - nullable.

        // TODO Contacts - nullable.
    }
}