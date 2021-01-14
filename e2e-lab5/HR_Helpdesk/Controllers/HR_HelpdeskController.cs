using HR_Helpdesk.DBContexts;
using HR_Helpdesk.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Helpdesk.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class HR_HelpdeskController : Controller
    {
        private readonly HR_HelpdeskDbContext context;
        public record UndoParameters(string Name);

        public HR_HelpdeskController(HR_HelpdeskDbContext context)
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
        public async Task<IActionResult> Submit([FromBody] HR_HelpdeskModel request)
        {
            context.HR_Helpdesk.Add(request);
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
            var recordsToRemove = context.HR_Helpdesk
                .Where(r => r.Name == parameters.Name)
                .ToArray();
            var noRecordsWereFound = recordsToRemove.Length == 0;

            if (noRecordsWereFound)
                return NoContent();

            context.HR_Helpdesk.RemoveRange(recordsToRemove);
            await context.SaveChangesAsync();
            return NotFound();
        }
    }
}