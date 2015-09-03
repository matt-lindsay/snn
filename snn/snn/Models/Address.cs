using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace snn.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [Display(Name = "SAON #")]
        public string SaonNum { get; set; }

        [Display(Name = "Saon Text")]
        public string SaonTxt { get; set; }

        [Display(Name = "Paon #")]
        public string PaonNum { get; set; }

        [Display(Name = "Paon Text")]
        public string PaonTxt { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name = "Locality")]
        public string Locality { get; set; }

        [Display(Name = "Post Town")]
        public string PostTown { get; set; }

        [Display(Name = "County")]
        public string County { get; set; }

        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Display(Name = "UPRN")]
        public string Uprn { get; set; }

        [Display(Name = "Full Address")]
        public string FullAddress
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                string comma = ", ";
                if (!string.IsNullOrEmpty(SaonNum)) sb.Append(SaonNum).Append(comma);
                if (!string.IsNullOrEmpty(SaonTxt)) sb.Append(SaonTxt).Append(comma);
                if (!string.IsNullOrEmpty(PaonNum)) sb.Append(PaonNum).Append(comma);
                if (!string.IsNullOrEmpty(PaonTxt)) sb.Append(PaonTxt).Append(comma);
                if (!string.IsNullOrEmpty(StreetName)) sb.Append(StreetName).Append(comma);
                if (!string.IsNullOrEmpty(Locality)) sb.Append(Locality).Append(comma);
                if (!string.IsNullOrEmpty(PostTown)) sb.Append(PostTown).Append(comma);
                if (!string.IsNullOrEmpty(County)) sb.Append(County).Append(" ");
                if (!string.IsNullOrEmpty(PostCode)) sb.Append(PostCode);
                return sb.ToString();
            }
        }

        public virtual ICollection<Case> Cases { get; set; }
    }
}