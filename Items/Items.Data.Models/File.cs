namespace Items.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class File
	{
        //public File()
        //{
        //    Id = Guid.NewGuid();
        //}

        [Key]
        public Guid Id { get; set; }

        [Required]
        public byte[] Bytes { get; set; } = null!;

        [Required]
        public string MimeType { get; set; } = null!;

        public string? Name { get; set; }
    }
}
