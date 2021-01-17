using IT_Helpdesk.DbContexts;
using IT_Helpdesk.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Helpdesk.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class IT_HelpdeskController : Controller
    {
        private IT_HelpdeskDbContext context;
        public record UndoParameters(string name);

        public IT_HelpdeskController(IT_HelpdeskDbContext context)
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
        public async Task<IActionResult> Submit([FromBody] IT_HelpdeskModel request)
        {
            context.IT_Helpdesk.Add(request);
            var savedToDb = await context.SaveChangesAsync();

            if (savedToDb == 0)
                return BadRequest();

            return Ok();
        }

        [EnableCors("AllowAll")]
        [HttpDelete]
        [Route("undo")]
        public async Task<IActionResult> UndoFrontendTests([FromBody] UndoParameters parameters)
        {
            var recordsToRemove = context.IT_Helpdesk
                .Where(r => r.Name == parameters.name)
                .ToArray();

            if (recordsToRemove.Length == 0)
                return NoContent();

            context.IT_Helpdesk.RemoveRange(recordsToRemove);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}