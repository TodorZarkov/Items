namespace Items.AdminApi.Controllers
{
    using static Common.RoleConstants;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Items.Services.Data.Interfaces;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : Controller
    {
        private readonly IUnitService unitService;

        public UnitsController(IUnitService unitService)
        {
            this.unitService = unitService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var units = await unitService.AllAsync();

            return Ok(units);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            bool exist = await unitService.IsValidIdAsync(id);
            if (!exist)
            {
                ModelState.AddModelError(nameof(id), "Invalid unit id.");
                return BadRequest(ModelState);
            }
            var unit = await unitService.GetByIdAsync(id);

            return Ok(unit);
        }
    }
}
