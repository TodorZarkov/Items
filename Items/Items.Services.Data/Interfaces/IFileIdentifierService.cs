namespace Items.Services.Data.Interfaces
{
	public interface IFileIdentifierService
	{
		Task<bool> CanAccessAsync(Guid userId, Guid fileId);

		Task<IEnumerable<Guid>> PublicFilesByItemIdAsync(Guid itemId);
	}
}
