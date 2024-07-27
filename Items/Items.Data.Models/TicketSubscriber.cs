namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TicketSubscriber
    {
        [Required]
        [ForeignKey(nameof(Ticket))]
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Subscriber))]
        public Guid SubscriberId { get; set; }
        public ApplicationUser Subscriber { get; set; } = null!;
    }
}
