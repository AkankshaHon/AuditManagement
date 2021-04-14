using AuditChecklistModule.Model;
using AuditChecklistModule.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditChecklistController : ControllerBase
    {
        private readonly IChecklistProvider checklistProviderobj;

        public AuditChecklistController(IChecklistProvider _checklistProviderobj)
        {
            checklistProviderobj = _checklistProviderobj;
        }

        [HttpGet]
        public IActionResult AuditCheckListQuestions([FromBody] string auditType)
        {
            if (string.IsNullOrEmpty(auditType))
                return BadRequest("No Input");
            if ((auditType != "Internal") && (auditType != "SOX"))
                return Ok("Wrong Input");

            try
            {
                List<Questions> list = checklistProviderobj.QuestionsProvider(auditType);
                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
