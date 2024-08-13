namespace Items.Services.Data.Models.Ticket
{
	using static Items.Common.EntityValidationConstants.Ticket;

	using System.ComponentModel.DataAnnotations;
	using Microsoft.AspNetCore.Http;

	public class TicketFormServiceModel
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
