using Maintenance_Helpdesk.DbContexts;
using Maintenance_Helpdesk.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance_Helpdesk.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class Maintenance_HelpdeskController : Controller
    {
        private Maintenance_HelpdeskDbContext context;
        public record UndoParameters(string name);

        public Maintenance_HelpdeskController(Maintenance_HelpdeskDbContext context)
        {
            this.context = context;
        }

        [EnableCors("AllowAll")]
        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            return Ok("Get Works");
        }

        [EnableCors("AllowAll")]
        [HttpPost]
        [Route("submit")]
        public async Task<IActionResult> Submit([FromBody] Maintenance_HelpdeskModel request)
        {
            context.Maintenance_Helpdesk.Add(request);
            var savedToDb = await context.SaveChangesAsync();

            if (savedToDb == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [EnableCors("AllowAll")]
        [HttpDelete]
        [Route("undo")]
        public async Task<IActionResult> UndoFrontendTests([FromBody] UndoParameters parameters)
        {
            var recordsToRemove = context.Maintenance_Helpdesk
                .Where(r => r.Name == parameters.name)
                .ToArray();

            if (recordsToRemove.Length == 0)
                return NoContent();

            context.Maintenance_Helpdesk.RemoveRange(recordsToRemove);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}