using System.ComponentModel.DataAnnotations;

namespace PatientNet.Models.ViewModels
{
	public class PatientViewModel
	{
		[Required]
		[Display(Name="Name")]
		public string Name { get; set;}

		[Required]
		[Display(Name = "Age")]
		public int Age { get; set; }

		[Required]
		[Display(Name = "Birthdate")]
		public string Birthdate { get; set; }

		[Required]
		[Display(Name = "Sex")]
		public string Sex { get; set; }

		[Required]
		[Display(Name = "Allergies")]
		public string Allergies { get; set; }

		[Required]
		[Display(Name = "Observations")]
		public string Observations { get; set; }

	}
}
