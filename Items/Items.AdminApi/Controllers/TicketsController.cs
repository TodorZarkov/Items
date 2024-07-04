namespace Items.AdminApi.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.Ticket;
	using static Items.Common.RoleConstants;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Items.AdminApi.Infrastructure.Extensions;
	using System.Net.Mime;
	using System.Net.Http.Headers;

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : Controller
	{
		private readonly ITicketService ticketService;

		public TicketsController(ITicketService ticketService)
		{
			this.ticketService = ticketService;
		}


		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All([FromQuery] TicketQueryModel? queryModel)
		{
			//todo: validate query model
			AllTicketInfoServiceModel tickets = await ticketService.GetAllAsync(queryModel);

			return Ok(tickets);
		}

		[AllowAnonymous]
		[HttpGet("{ticketId}")]
		public async Task<IActionResult> Details([FromRoute] Guid ticketId)
		{
			//todo: validate id if needed
			TicketDetailsServiceModel ticket = await ticketService.GetAsync(ticketId);

			MultipartFormDataContent content = new MultipartFormDataContent();

			ByteArrayContent snapshotContent = new ByteArrayContent(ticket.Snapshot);
			snapshotContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Image.Jpeg);

			content.Add(snapshotContent);

			JsonContent ticketContent = JsonContent.Create(ticket);

			content.Add(ticketContent);

			return Ok(content);
		}


		[HttpPost]
		public async Task<IActionResult> Add([FromForm] TicketFormServiceModel ticketFormModel)
		{
			//todo: async check the model
			Guid? userId = User.GetId();
			Guid ticketId = await ticketService.AddAsync((Guid)userId!, ticketFormModel);

			return Ok(new { id = ticketId });
		}

		[Authorize(Roles = $"{Admin}, {SuperAdmin}")]
		[HttpPut("{ticketId}")]
		public async Task<IActionResult> Edit([FromRoute] Guid ticketId, [FromBody] TicketEditServiceModel ticketEditModel)
		{
			//todo: static and async validation
			Guid? userId = User.GetId();
			await ticketService.EditAsync((Guid)userId!, ticketId, ticketEditModel);
			return Ok(new { id = ticketId });
		}
	}
}
