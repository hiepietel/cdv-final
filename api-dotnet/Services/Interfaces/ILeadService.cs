public interface ILeadService{
    Task<Lead> GetLead(int leadId);
    Task<List<Lead>> GetLeads();
    Task<Lead> CreateLead(Lead lead);
    Task<string> UpdateLead(int leadId, Lead lead);
    Task<string> DeleteLead(int leadId);
}