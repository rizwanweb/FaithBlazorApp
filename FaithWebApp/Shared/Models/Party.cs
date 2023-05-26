namespace FaithWebApp.Shared.Models
{
	public class Party
	{
		public int Id { get; set; }

		public string ClientName { get; set; } = string.Empty;
		public string? ContactPerson { get; set; }
		public string? Phone { get; set; }
		public string? Mobile { get; set; }
		public string? Email { get; set; }
		public string? Ntn { get; set; }
		public string? Gst { get; set; }
		public string? Address { get; set; }
		public City? City { get; set; }
		public int CityID { get; set; }
		public string? ClientType { get; set; }
		public string? Fax { get; set; }
		public string? StandAddress { get; set; }
		public string? Cnic { get; set; }
		public string? Designation { get; set; }
		public string? AuthorizedPerson { get; set; }
	}
}
