namespace Items.Data.Models
{
    using static Common.EntityValidationConstants.Document;

    using System.ComponentModel.DataAnnotations;

    public class Document
    {
        public Document()
        {
            Id = Guid.NewGuid();
            Items = new HashSet<Item>();
        }

        [Key]
        public Guid Id { get; set; }


        [Required]
        public ICollection<FileIdentifier> DocumentFiles { get; set; } = null!;


        public ICollection<Item> Items { get; set; } = null!;
    }
}
