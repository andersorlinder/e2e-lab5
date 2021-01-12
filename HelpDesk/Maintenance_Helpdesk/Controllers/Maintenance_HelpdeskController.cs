using Maintenance_Helpdesk.DbContexts;
using Maintenance_Helpdesk.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Maintenance_Helpdesk.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class Maintenance_HelpdeskController : Controller
    {
        private Maintenance_HelpdeskDbContext context;

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
    }
}