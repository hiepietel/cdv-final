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
        lead.DateCreated = DateTime.Now;
        await _appContext.Leads.AddAsync(lead);
        await _appContext.SaveChangesAsync();
        return lead;
    }

    public async Task<string> DeleteLead(int leadId)
    {
        var lead = await _appContext.Leads.FirstOrDefaultAsync(x => x.Id == leadId);
        _appContext.Leads.Remove(lead);
        return "";
    }

    public async Task<Lead> GetLead(int leadId)
    {
        var response = await _appContext.Leads.FirstOrDefaultAsync(x => x.Id == leadId);
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
        leadToUpdate.DateLastUpdated = DateTime.Now;
        leadToUpdate.FirstName = lead.FirstName;
        leadToUpdate.LastName = lead.FirstName;
        leadToUpdate.Email = lead.Email;
        leadToUpdate.Company = lead.Company;
        leadToUpdate.Note = lead.Note;
        await _appContext.SaveChangesAsync();
        return "";
    }
}