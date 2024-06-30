using System.ComponentModel.DataAnnotations;

namespace PatientNet.Models.ViewModels
{
	public class SearchViewModel
	{
		[Required]	
		[Display]
		public string Search { get; set; }

	}
}
