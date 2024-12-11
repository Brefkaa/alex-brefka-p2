namespace Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string? Task { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time => Date.Subtract(new DateTime());
    }
}

