public class Lead{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string first_name { get; set; } = string.Empty;
    public string last_name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string company { get; set; } = string.Empty;
    public string note { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public DateTime? DateLastUpdated { get; set; }
}