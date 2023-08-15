namespace Items.Services.Common
{
	using Items.Services.Common.Interfaces;
	using System;

	public class DateTimeUtcProvider : IDateTimeProvider
	{
		public DateTime GetCurrentDate()
		{
			return DateTime.UtcNow.Date;
		}

		public DateTime GetCurrentDateTime()
		{
			return DateTime.UtcNow;
		}
	}
}
