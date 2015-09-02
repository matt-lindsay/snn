using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

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
                return CreateFullAddress();
            }
        }

        //public virtual List<Case> Case { get; set; }
        public virtual ICollection<Case> Cases { get; set; }

        private string CreateFullAddress()
        {
            StringBuilder baseString = new StringBuilder();
            string comma = ",";

            baseString.Append(SaonNum).Append(comma).Append(SaonTxt).Append(comma)
                .Append(PaonNum).Append(comma).Append(PaonTxt).Append(comma)
                .Append(StreetName).Append(comma).Append(Locality).Append(comma)
                .Append(PostTown).Append(comma).Append(County).Append(comma)
                .Append(PostCode);

            string fullAddress = "";

            fullAddress = baseString.ToString();

            fullAddress = Regex.Replace(fullAddress, ",,", ",");

            return fullAddress;
        }
    }
}