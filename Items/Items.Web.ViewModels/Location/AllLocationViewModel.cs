namespace Items.Web.ViewModels.Location
{
	public class AllLocationViewModel
	{
		public Guid Id { get; set; }


		public string? Name { get; set; }


		public string? Description { get; set; }


		public string? GeoLocation { get; set; }


		public string? Border { get; set; }


		public string? Country { get; set; } = null!;


		public string? Town { get; set; }


		public string? Address { get; set; } = null!;


		public int Places { get; set; }


		public int Items { get; set; }

		public LocationVisibilityViewModel Visibility { get; set; } = null!;
    }
}
