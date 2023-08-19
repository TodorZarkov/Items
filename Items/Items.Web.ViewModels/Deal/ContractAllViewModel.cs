namespace Items.Web.ViewModels.Deal
{
	using  Items.Common.Enums;
	public class ContractAllViewModel
	{
		
		public Guid Id { get; set; }



        //public ApplicationUser Buyer { get; set; } = null!;


        //public ApplicationUser Seller { get; set; } = null!;
        public bool IsSeller { get; set; }
		public string RowStatusColor { get; set; } = null!;

		public Guid? ItemId { get; set; }
		public string ItemName { get; set; } = null!;
		public string ItemPicture { get; set; } = null!;

        public string Price { get; set; } = null!;


		public string Currency { get; set; } = null!;


		public string Quantity { get; set; } = null!;

		public string Unit { get; set; } = null!;

        public string SendDue { get; set; } = null!;

		public DateTime DeliverDue { get; set; }

		public string ContractDate { get; set; } = null!;


		public bool SellerOk { get; set; }
		public bool BuyerOk { get; set; }
		public bool BuyerReceived { get; set; }
		public bool SellerReceived { get; set; }
		public DealStatus DealStatus { get; set; }


        public string? SellerComment { get; set; }

		public string? BuyerComment { get; set; }

		public string DeliveryAddress { get; set; } = null!;

	}
}
