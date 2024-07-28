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
    using Items.Services.Data.Models.TicketType;

    [Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : Controller
	{
		private readonly ITicketService ticketService;
		private readonly ITicketTypeService ticketTypeService;

        public TicketsController(ITicketService ticketService, ITicketTypeService ticketTypeService)
        {
            this.ticketService = ticketService;
            this.ticketTypeService = ticketTypeService;
        }


        [AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All([FromQuery] TicketQueryModel? queryModel)
		{
			//todo: validate query model
			AllTicketInfoServiceModel tickets = await ticketService.GetAllAsync(queryModel);

			return Ok(tickets);
		}

		[HttpGet("Types")]
		public async Task<IActionResult> AllTypes()
		{
			AllTicketTypesServiceModel[] types = (await ticketTypeService.AllAsync())
				.ToArray();

			return Ok(types);
		}

		[AllowAnonymous]
		[HttpGet("{ticketId}")]
		public async Task<IActionResult> Details([FromRoute] Guid ticketId)
		{
			Guid? userId = User.GetId();
			TicketDetailsServiceModel ticket = await ticketService.GetAsync(ticketId, userId);

			return Ok(ticket);
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

		
		[HttpPatch("{ticketId}")]
		public async Task<IActionResult> Edit(
			[FromRoute] Guid ticketId, 
			[FromBody] TicketUpdateServiceModel model)
        {
            //there's five types of users related to Ticket:
            //creator - can modify certain fields before ticket assignment
            //user - not admin and not creator - only can toggle subscribe and same problem
            //admin-assigner - 
            //admin-assignee - 
            //super-admin - 

            Guid? userId = User.GetId();
			Guid id = await ticketService.UpdateAsync(model, ticketId, (Guid)userId!);

            return Ok(new {updatedTicket = id});
        }
    }
}
