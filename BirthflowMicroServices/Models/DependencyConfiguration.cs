namespace BirthflowMicroServices.Models
{
	public class DependencyConfiguration
	{
		public required string From { get; set; }
		public required string To { get; set; }
		public required string DependencyType { get; set; }
	}

}
