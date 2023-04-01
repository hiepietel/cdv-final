using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Controllers;

[ApiController]
//[Route("[controller]")]
public class LeadController : ControllerBase
{
    private readonly ILeadService _leadService;
    public LeadController(ILeadService leadService)
    {
        _leadService = leadService;
    }

    [HttpPost]
    [Route("/api/leads")]
    public async Task<IActionResult> CreateLead([FromBody] Lead lead)
    {
        await _leadService.CreateLead(lead);
        return Ok();
    }

    [HttpGet]
    [Route("api/leads")]
    public async Task<IActionResult> GetLeads()
    {
        var response = await _leadService.GetLeads();
        return Ok(response);
    }

    [HttpGet]
    [Route("api/leads/{leadId}")]
    public async Task<IActionResult> GetLead([FromQuery] int leadId)
    {
        return Ok(await _leadService.GetLead(leadId));
    }

    [HttpPut]
    [Route("api/leads/{leadId}")]
    public async Task<IActionResult> UpdateLead([FromQuery] int leadId, [FromBody] Lead lead)
    {
        await _leadService.UpdateLead(leadId, lead);
        return Ok(new
        {
            message = "Successfully Updated"
        });
    }

    [HttpDelete]
    [Route("api/leads/{leadId}")]
    public async Task<IActionResult> DeleteLead([FromQuery] int leadId)
    {
        await _leadService.DeleteLead(leadId);
        return Ok(new
        {
            message = "Successfully Deleted"
        });
    }
}