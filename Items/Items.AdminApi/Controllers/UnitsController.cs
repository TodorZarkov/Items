namespace Items.AdminApi.Controllers
{
    using static Common.RoleConstants;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Items.Services.Data.Interfaces;
    using Items.Services.Data.Models.Unit;

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
            
            try
            {
                var units = await unitService.AllAsync();

                return Ok(units);
            }
            catch (Exception)
            {
                //todo: Logging e
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
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


            try
            {
                var unit = await unitService.GetByIdAsync(id);

                return Ok(unit);
            }
            catch (Exception)
            {
                //todo: Logging e
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            
        }

        [HttpPost]
        [Authorize(Roles = $"{Admin}, {SuperAdmin}")]
        public async Task<IActionResult> Create([FromBody] UnitServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool existName = await unitService.ExistByNameAsync(model.Name);
            if (existName)
            {
                ModelState.AddModelError(nameof(model.Name), "Unit with specified name already exist.");
                return BadRequest(ModelState);
            }

            try
            {
                int id = await unitService.CreateAsync(model);
                return Ok(new {id});

            }
            catch (Exception e)
            {
                //todo: Logging e
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Admin}, {SuperAdmin}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool validId = await unitService.IsValidIdAsync(id);
            if (!validId)
            {
                ModelState.AddModelError(nameof(id), "Invalid unit id.");
                return BadRequest(ModelState);
            }
            long relations = await unitService.CountRelationsAsync(id);
            if (relations != 0)
            {
                ModelState.AddModelError(nameof(relations), $"The unit with id {id} is used by {relations} items or contracts. Cannot delete.");
                return BadRequest(ModelState);
            }

            try
            {
                await unitService.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                //todo: Logging e
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }
    }
}
