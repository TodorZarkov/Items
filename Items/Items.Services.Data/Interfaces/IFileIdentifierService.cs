namespace Items.Services.Data.Interfaces
{
	public interface IFileIdentifierService
	{
		Task<bool> CanAccess(Guid userId, Guid fileId);
	}
}
