namespace Items.Common
{
	public static class EntityValidationErrorMessages
	{
		public static class Unit
		{
			public const string InvalidUnitId = "Invalid Measurement Unit Id (Unit Id).";
		}

		public static class Item
		{
			public const string StartSellCannotBeInThePast = "Start Sell Cannot Be In The Past.";
			public const string StartSellMustBeToday = "Start Sell Must Be Today.";
			public const string StartSellAfterEndSell = "Start Sell Cannot Be After End Sell or be End Sell.";
			public const string StartSellPriceCurrencyRequired = "Start Sell, Price, Currency and Is Auction are all Required to Put on Market!";
			public const string PriceCurrencyRequired = "If Price is Present, Currency is Required!";

			public const string CannotBeDeliveredBeforeSent = "Cannot Be Delivered Before Sent.";

			public const string InsufficientQuantity = "Insufficient Item Quantity! Try reduce order Quantity.";


		}

		public static class Contract
		{
			public const string CannotBeDeliveredBeforeSent = "Cannot Be Delivered Before Sent.";
		}

		public static class General
		{
			public const string GeneralFormError = "Some of the Input Data is Invalid!";
		}
	}
}
