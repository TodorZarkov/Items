namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserContract
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; } = null!;



        [ForeignKey(nameof(Contract))]
        public Guid ContractId { get; set; }

        [Required]
        public Contract Contract { get; set; } = null!;
    }
}
