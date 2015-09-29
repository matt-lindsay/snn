using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace snn.Models
{
	public class AddressChangeIntelligence
	{
		[Key]
		public int AddressChangeIntelligenceID { get; set; }
		
		[Display(Name = "Address Change Intelligence")]
		public string AddressChangeIntelligenceDescription { get; set; }
		
		public virtual List<Case> Case { get; set; }
	}	
}