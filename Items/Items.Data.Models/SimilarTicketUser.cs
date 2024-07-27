namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class SimilarTicketUser
    {
        [ForeignKey(nameof(Ticket))]
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
