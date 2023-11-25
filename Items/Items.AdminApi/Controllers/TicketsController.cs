namespace Items.AdminApi.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.Ticket;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;


	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : ControllerBase
	{
		private readonly ITicketService ticketService;

		public TicketsController(ITicketService ticketService)
		{
			this.ticketService = ticketService;
		}


		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All(TicketQueryModel? queryModel)
		{
			//todo: validate query model
			AllTicketInfoServiceModel tickets = await ticketService.GetAllAsync(queryModel);

			return Ok(tickets);
		}
    }
}
