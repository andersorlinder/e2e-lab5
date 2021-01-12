using HR_Helpdesk.DBContexts;
using HR_Helpdesk.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Helpdesk.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class HR_HelpdeskController : Controller
    {
        private readonly HR_HelpdeskDbContext context;

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
    }
}