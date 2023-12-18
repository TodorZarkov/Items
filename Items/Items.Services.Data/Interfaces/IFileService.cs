namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.File;

	public interface IFileService
	{
		Task<Guid> SaveAsync(FileServiceModel fileModel);

		Task ModifyAsync(Guid fileId, FileServiceModel fileModel);

		Task<FileServiceModel> GetAsync(Guid fileId);

		Task<IEnumerable<FileServiceModel>> GetAsync(IEnumerable<Guid> fileIds);

		Task DeleteAsync(Guid fileId);

	}
}
