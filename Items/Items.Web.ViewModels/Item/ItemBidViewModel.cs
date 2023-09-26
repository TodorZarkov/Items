﻿namespace Items.Web.ViewModels.Item
{
	public class ItemBidViewModel
	{

		public string Name { get; set; } = null!;

		public string MainPictureUri { get; set; } = null!;


		public string? HighestBid { get; set; } //
		public int? BarterOffers { get; set; } //


        public string? Country { get; set; }//

		public string? Town { get; set; }//

		public string StartPrice { get; set; } = null!;//

		public string? CurrencySymbol { get; set; }//


		public decimal? QuantityLeft { get; set; }//

		public string Unit { get; set; } = null!;//

		public string EndSell { get; set; } = null!;//
    }
}
