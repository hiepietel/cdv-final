using Microsoft.EntityFrameworkCore;

public class LeadService : ILeadService
{
    private readonly AppContext _appContext;
    public LeadService(AppContext appContext)
    {
        _appContext = appContext;
    }

    public async Task<Lead> CreateLead(Lead lead)
    {
        lead.DateCreated = DateTime.UtcNow;
        await _appContext.Leads.AddAsync(lead);
        await _appContext.SaveChangesAsync();
        return lead;
    }

    public async Task<string> DeleteLead(int leadId)
    {
        var lead = await _appContext.Leads.FirstOrDefaultAsync(x => x.Id == leadId);
        if(lead == null){
            return "";
        }
        _appContext.Leads.Remove(lead);
        return "";
    }

    public async Task<Lead> GetLead(int leadId)
    {
        var response = await _appContext.Leads.FirstOrDefaultAsync(x => x.Id == leadId);
        if(response == null){
            return new Lead();
        }
        return response;
    }

    public async Task<List<Lead>> GetLeads()
    {
        return await _appContext.Leads.ToListAsync();
    }

    public async Task<string> UpdateLead(int leadId, Lead lead)
    {
        var leadToUpdate = await _appContext.Leads.FirstOrDefaultAsync(x => x.Id == leadId);
        if(leadToUpdate == null){
            return "";
        }
        leadToUpdate.DateLastUpdated = DateTime.UtcNow;
        leadToUpdate.first_name = lead.first_name;
        leadToUpdate.last_name = lead.first_name;
        leadToUpdate.email = lead.email;
        leadToUpdate.company = lead.company;
        leadToUpdate.note = lead.note;
        await _appContext.SaveChangesAsync();
        return "";
    }
}