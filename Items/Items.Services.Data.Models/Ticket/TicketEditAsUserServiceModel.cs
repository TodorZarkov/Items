namespace Items.Services.Data.Models.Ticket
{
    using static Items.Common.EntityValidationConstants.Ticket;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class TicketEditAsUserServiceModel
    {
        public int TypeId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(TitleMax, MinimumLength = TitleMin)]
        public string Title { get; set; } = null!;

        [StringLength(DescriptionMax, MinimumLength = DescriptionMin)]
        public string? Description { get; set; }

        public IFormFile? SnapShot { get; set; }
    }
}
