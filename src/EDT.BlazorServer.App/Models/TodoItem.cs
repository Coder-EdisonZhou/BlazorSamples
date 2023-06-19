namespace EDT.BlazorServer.App.Models
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Remark { get; set; }
    }
}
