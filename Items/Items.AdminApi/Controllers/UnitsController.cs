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
    }
}
