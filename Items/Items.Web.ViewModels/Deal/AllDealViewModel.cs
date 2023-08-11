namespace Items.Web.ViewModels.Deal
{
	public class AllDealViewModel
	{
		
		public Guid Id { get; set; }


		
		public Guid BuyerId { get; set; }


		
		public Guid SellerId { get; set; }



		//public ApplicationUser Buyer { get; set; } = null!;


		//public ApplicationUser Seller { get; set; } = null!;




		public string Price { get; set; } = null!;


		public string Currency { get; set; } = null!;


		public string Quantity { get; set; } = null!;


		public string SendDue { get; set; } = null!;

		public DateTime DeliverDue { get; set; }

		public string ContractDate { get; set; } = null!;

		public bool SellerOk { get; set; }

		public bool BuyerOk { get; set; }

		public bool Fulfilled { get; set; }

		public string? SellerComment { get; set; }

		public string? BuyerComment { get; set; }

		public string DeliveryAddress { get; set; } = null!;

		public bool BuyerConfirm { get; set; }
	}
}
