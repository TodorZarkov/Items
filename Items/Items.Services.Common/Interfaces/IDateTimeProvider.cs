namespace Items.Services.Common.Interfaces
{
	public interface IDateTimeProvider
	{
		DateTime GetCurrentDate();

		DateTime GetCurrentDateTime();
	}
}
