using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadController : ControllerBase
{
    [HttpPost]
    [Route("/api/leads")]
    public async Task<IActionResult> CreateLead(){
        
        return Ok();
    }

    [HttpGet]
    [Route("api/leads")]
    public async Task<IActionResult> GetLeads(){
        return Ok();
    }

    [HttpGet]
    [Route("api/leads/{leadId}")]
    public async Task<IActionResult> GetLead([FromQuery] int leadId){
        return Ok();
    }

    [HttpPut]
    [Route("api/leads/{leadId}")]
    public async Task<IActionResult> UpdateLead([FromQuery] int leadId){
        return Ok();
    }

    [HttpDelete]
    [Route("api/leads/{leadId}")]
    public async Task<IActionResult> DeleteLead([FromQuery] int leadId){
        return Ok();
    }
}