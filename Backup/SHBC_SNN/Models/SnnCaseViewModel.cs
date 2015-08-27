using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBC_SNN.Models
{
    public class SnnCaseViewModel
    {
        public int Id { get; set; }
        public string CaseNo { get; set; }
        public string Address { get; set; }
        public int Uprn { get; set; }
        public int CountOfContacts { get; set; }
    }
}