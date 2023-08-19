namespace Items.Web.ViewModels.Deal
{
	public class ContractViewModel
	{
		public bool? IsSeller { get; set; }
		public string? SellerName { get; set; } 
		public string? SellerEmail { get; set; }
		public string? SellerPhone { get; set; }

		public string? BuyerName { get; set; }
		public string? BuyerEmail { get; set; }
		public string? BuyerPhone { get; set; }

		public string TotalPrice { get; set; } = null!;

        public decimal Price { get; set; }

		public string CurrencySymbol { get; set; } = null!;

		public string UnitSymbol { get; set; } = null!;

		public string ItemName { get; set; } = null!;

		public string ItemPictureUri { get; set; } = null!;

		public string? ItemDescription { get; set; }


		public decimal Quantity { get; set; }

		public DateTime SendDue { get; set; } //modifiable

		public DateTime DeliverDue { get; set; }//modifiable

		public string? SellerComment { get; set; } //modifiable

		public string? BuyerComment { get; set; } //modifiable

		public string DeliveryAddress { get; set; } = null!; //modifiable
	}
}
