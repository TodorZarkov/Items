namespace Items.Common
{
	public static class TicketConstants
	{
		public static class Statuses
		{
			public const string OPEN = "Open";//This corresponds to Rised/Reported
			public const string ASSIGN = "Assign";//This corr. to opened/assigned
			public const string CLOSE = "Close";//--> solved
			public const string DELETE = "Delete";//not have relation with fe.
		}

		public static class Types
		{
			public const string BUG = "Bug";
			public const string NEW_CATEGORY = "NewCategory";
			public const string NEW_CURRENCY = "NewCurrency";
            public const string NEW_UNIT = "NewUnit";
        }

        public static class Query
		{
			public const int HitsPerPage = 20;
			public const int CurrentPage = 1;
		}
	}
}
