namespace Items.Common
{
	public static class EntityValidationErrorMessages
	{
		public static class Unit
		{
			public const string InvalidUnitId = "Invalid Measurement Unit Id (Unit Id).";
		}
		
		public static class Currency
		{
			public const string InvalidCurrencyId = "Invalid Currency Id.";
		}

		public static class Item
		{
			public const string StartSellCannotBeInThePast = "Start Sell Cannot Be In The Past.";
			public const string StartSellMustBeToday = "Start Sell Must Be Today.";
			public const string StartSellAfterEndSell = "Start Sell Cannot Be After End Sell or be End Sell.";
			public const string StartSellPriceCurrencyRequired = "Start Sell, Price, Currency and Is Auction are all Required to Put on Market!";
			public const string PriceCurrencyRequired = "If Price is Present, Date and Currency are Required!";

			public const string CannotBeDeliveredBeforeSent = "Cannot Be Delivered Before Sent.";

			public const string InsufficientQuantity = "Insufficient Item Quantity! The Quantity must be less or equal than {0}.";


		}

		public static class Contract
		{
			public const string CannotBeDeliveredBeforeSent = "Cannot Be Delivered Before Sent.";
			public const string BarterItemRequiredIfPresentAnyBarterProperty = "All Fields of Barter Item becomes required if at least one field of barter fields is present!";
		}
		
		public static class Location
		{
			public const string InvalidLocationId = "Invalid Location Id!";
		}

		public static class Offer
		{
			public const string BarterQuantityRequired = "Barter Quantity is required if barter Item is present!";
			public const string BarterItemRequired = "Barter Item is required if barter Quantity is present!";

			public const string InvalidExpirationDate = "Invalid Expiration date. Date must not be before {0}!";

			public const string InvalidBidValue = "The Bid Value must be greater than {0}, with step {1}!";

			public const string InvalidBarterItemId = "Invalid Barter Item id!/Invalid Barter Quantity!";

			public const string BidValueRequired = "The Bid per unit value is required if barter item is not present!";
		}

		public static class Auction
		{
			public const string InvalidEndAuctionDate = "Invalid End Auction Date. Must be after or on {0}!";
		}

		public static class Category
		{
			public const string ExistingCategory = "The specified Category already exists.";
		}

		public static class General
		{
			public const string GeneralFormError = "Some of the Input Data is Invalid!";
		}
	}
}
