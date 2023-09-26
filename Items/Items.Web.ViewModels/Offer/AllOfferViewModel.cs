namespace Items.Web.ViewModels.Offer
{
	public class AllOfferViewModel
	{
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Guid Id { get; set; }

		public string Expires { get; set; } = null!;

		public string? Message { get; set; }


		public decimal Quantity { get; set; }
		public decimal Value { get; set; }


		public string? BarterQuantity { get; set; }
		public string? BarterUnit { get; set; }
		public Guid? BarterItemId { get; set; }
		public string? BarterPictureUri { get; set; }
		public string? BarterName { get; set; }
        public string? BarterDescription { get; set; }
    }
}
