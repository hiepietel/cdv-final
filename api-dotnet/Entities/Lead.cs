public class Lead{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string company { get; set; }
    public string note { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateLastUpdated { get; set; }
}