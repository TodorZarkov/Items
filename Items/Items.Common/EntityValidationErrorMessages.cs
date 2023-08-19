namespace Items.Common
{
	public static class EntityValidationErrorMessages
	{
		public static class Unit
		{
			public const string InvalidUnitId = "Invalid Measurement Unit Id. Try between {0} and {1} inclusive!";
		}

		public static class Item
		{
			public const string StartSellCannotBeInThePast = "Start Sell Cannot Be In The Past.";
			public const string StartSellAfterEndSell = "Start Sell Cannot Be After End Sell.";

			public const string CannotBeDeliveredBeforeSent = "Cannot Be Delivered Before Sent.";
		}

		public static class Contract
		{
			public const string CannotBeDeliveredBeforeSent = "Cannot Be Delivered Before Sent.";
		}
	}
}
