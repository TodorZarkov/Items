namespace Items.Common.Enums
{
	using System.ComponentModel.DataAnnotations;

	public enum Sorting
	{
		//item
		Name = 1,

		[Display(Name = "Price (Desc.)")]
		PriceDec = 2 ,

		[Display(Name = "Price (Asc.)")]
		PriceAsc = 3 ,


		Latest = 4 ,

		//location, place
		Country = 5,
		Town = 6,

		//bid
		[Display(Name = "End Date")]
		EndDate = 7,

		//sell
		[Display(Name = "Start Date")]
		StartDate = 8,
		Type = 9,

		Status = 10,

		[Display(Name = "Send Date")]
		SendDate = 11,

		[Display(Name = "Delivery Date")]
		DeliveryDate = 12
	}
}
