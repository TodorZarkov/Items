namespace Items.Common.Enums
{
	using System.ComponentModel.DataAnnotations;

	public enum Criteria
	{
		Auctions = 1,

		[Display(Name = "On Sale")]
		OnSale = 2,


		Mine = 3,

		[Display(Name = "Not Mine")]
		NotMine = 4,
		Sold = 5,
		Bought = 6,
		Barters = 7,
		Bids = 8,
	}
}
