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
    using Microsoft.Extensions.Configuration.UserSecrets;

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

        [AllowAnonymous]
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

        //make overloads with  different models
        [HttpPut("{ticketId}")]
        public async Task<IActionResult> Edit([FromRoute] Guid ticketId, [FromForm] TicketEditAsUserServiceModel model)
        {
            //TODO: VALIDATE PARAMETERS!!!

            Guid userId = (Guid)User.GetId()!;
            TicketUserState state = await ticketService.GetStateAsync(ticketId, userId);

            if (state.isUser
                && state.isCreator
                && !state.isTicketAssigned
                && !state.anyWithSameProblem)
            {
                try
                {
                    //TODO: VALIDATE PARTICULARY THE  MODEL!!!
                    await ticketService.EditAsUserAsync(ticketId, model);
                    return NoContent();
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }

            return BadRequest();
            //there's six types of users regarding the Ticket:


            //creator - can modify certain fields before ticket assignment. The
            //	fields are the same as on create.

            //admin-before-assignment - is like user-not-author plus can assign to self and change severity but only if assigning is happened. cannot assign to super admins.

            //admin-assigner - is like user-not-author after assigning

            //admin-assignee - cannot change the user data. Can change: severity, reject assignment, ticket status, ticket type

            //super-admin - like admin but can assign to anyone.

            //isCreator, isUser, isAdmin, isSuperAdmin, isAssigner, isAssignee, isTicketAssigned


        }


        [HttpPatch("{ticketId}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid ticketId,
            [FromBody] TicketUpdateServiceModel model)
        {


            Guid? userId = User.GetId();
            Guid id = await ticketService.UpdateAsync(model, ticketId, (Guid)userId!);

            return Ok(new { updatedTicket = id });
        }

        [HttpDelete("{ticketId}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid ticketId)
        {
            //to delete:
            //must be owner,
            //ticket mustn't be assigned(assignee must be null)
            Guid? userId = User.GetId();
            bool canDelete = await ticketService.CanDeleteAsync(userId!, ticketId);
            if (!canDelete)
            {
                ModelState.AddModelError("", "Cannot delete. Either not allowed, the ticket is assigned or there's already another user with the same problem.");
                return BadRequest(ModelState);
            }

            try
            {
                await ticketService.DeleteAsync(ticketId);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
