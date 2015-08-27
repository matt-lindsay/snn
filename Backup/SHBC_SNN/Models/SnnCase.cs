using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHBC_SNN.Models
{
    #region Lookup Values
    public enum CaseType
    {
        Conversion, Demolition, NewBuild, RenamingRenumbering, Retrospective
    }

    public enum CaseStatus
    {
        PlanningApproved, BuildingCommenced, BuildingCompletion, Payment, PostcodeRequest, PreRelease, CompleteNYB, CompleteLIVE, Inactive, InactiveClosed
    }

    public enum Aci
    {
        Application, Planning, BuildingControl, Revenues
    }
    #endregion

    public class SnnCase
    {
        #region Model Properties
        public int Id { get; set; }

        [Display(Name="Case Number")]
        public string CaseNo { get; set; }

        [Display(Name="Case Type")]
        public CaseType? CaseType { get; set; }


        [Display(Name="Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        public string Details { get; set; }

        [Display(Name="Status")]
        public CaseStatus? CaseStatus { get; set; }

        public DateTime? LastUpdate { get; set; }

        [Display(Name="End Date")]
        public DateTime? EndDate { get; set; }

        public Aci? Aci { get; set; }

        [Display(Name="Aci Date")]
        public DateTime? AciDate { get; set; }

        [Display(Name="Planning Ref")]
        public string PlanningRef { get; set; }

        [Display(Name="Building Control Ref")]
        public string BuildingControlRef { get; set; }

        [Display(Name="Revenues Ref")]
        public string RevenuesRef { get; set; }

        public string Address { get; set; }

        public int Uprn { get; set; }

        #endregion

        #region Navigation Properties
        
        public virtual ICollection<SnnContacts> Contacts { get; set; } /* Navigation property: 1 Snn Case > many contacts.
                                                                        * Virtual keyword runs second query 'eagerly' to
                                                                        * load up related records from related table e.g.
                                                                        * Contacts data. As two queries are being run 
                                                                        * there is a performance hit.
                                                                        */
        //public virtual int TariffId { get; set; } 
        
        public virtual List<CaseStatus> Status { get; set; }
        
        #endregion
    }
}