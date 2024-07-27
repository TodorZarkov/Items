namespace Items.Services.Data.Models.Ticket
{
    using static Items.Common.EntityValidationConstants.Ticket;

    using Microsoft.AspNetCore.Http;

    using System.ComponentModel.DataAnnotations;

    public class TicketUpdateServiceModel
    {
        //user before assignment
        public int? TypeId { get; set; }

        [StringLength(TitleMax, MinimumLength = TitleMin)]
        public string? Title { get; set; }

        [StringLength(DescriptionMax, MinimumLength = DescriptionMin)]
        public string? Description { get; set; }

        public IFormFile? SnapShot { get; set; }
        //--------------------------------------------------

        //any user apart from author, admins
        public bool? ToggleSubscribe { get; set; }

        public bool? ToggleSameProblem { get; set; }
        //--------------------------------------------------


       
        public int? StatusId { get; set; }

        public Guid? AssigneeId { get; set; }

        public int? Severity { get; set; }
    }
}
