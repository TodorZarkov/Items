namespace Items.Common
{
	public static class TicketConstants
	{
		public static class Statuses
		{
			public const string OPEN = "Open";
			public const string ASSIGN = "Assign";
			public const string CLOSE = "Close";
			public const string DELETE = "Delete";
		}

		public static class Types
		{
			public const string BUG = "Bug";
			public const string NEW_CATEGORY = "NewCategory";
			public const string NEW_CURRENCY = "NewCurrency";
		}

		public static class Query
		{
			public const int HitsPerPage = 20;
			public const int CurrentPage = 1;
		}
	}
}
