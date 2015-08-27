using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHBC_SNN.Models
{
    public enum ContactType
    {
        Applicant, Agent, Consultee
    }
    
    public enum Title
    {
        Mr, Mrs, Miss, Ms, Dr, Prof, Rev
    }

    public enum ContactMethod
    {
        Phone, Post, Email
    }

    public class SnnContacts
    {
        public int Id { get; set; }

        [Display(Name="Contact Type")]
        public ContactType? ContactType { get; set; }

        public Title? Title { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        public string ContAdd1 { get; set; }

        public string ContAdd2 { get; set; }

        public string Street { get; set; }

        public string PostTown { get; set; }

        public string PostCode { get; set; }

        public int Uprn { get; set; }

        public int Phone { get; set; }

        public int Mobile { get; set; }

        [StringLength(128)]
        [DisplayFormat(NullDisplayText="No email")]
        public string Email { get; set; }

        [Display(Name="Contact Method")]
        public ContactMethod? ContactMethod { get; set; }

        [Required]
        [Display(Name="Primary Contact")]
        public bool PrimaryContact { get; set; }

        // Navigation properties.
        public virtual int SnnCaseId { get; set; }  // Points back to Snn Case the contact relates to, Foreign Key.
        public virtual ContactMethod ContMethod { get; set; }
    }
}