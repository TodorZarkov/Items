namespace Items.Services.Data.Models.File
{
	using System.ComponentModel.DataAnnotations;

	public class FileServiceModel
	{
		[Required]
		public byte[] Bytes { get; set; } = null!;

		[Required]
		public string MimeType { get; set; } = null!;

		public string? Name { get; set; }
	}
}
