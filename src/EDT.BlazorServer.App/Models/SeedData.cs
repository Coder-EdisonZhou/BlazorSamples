namespace EDT.BlazorServer.App.Models
{
    public static class SeedData
    {
        public static void Initialize(TodoContext db)
        {
            var todos = new TodoItem[]
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Name = "Study Computer Network", IsComplete=false, Remark = "Take a Test" },
                new TodoItem { Id = Guid.NewGuid().ToString(), Name = "Study Operation System", IsComplete=false, Remark = "Take a Test" },
                new TodoItem { Id = Guid.NewGuid().ToString(), Name = "Study Data Structure", IsComplete=false, Remark = "Take a Test" },
                new TodoItem { Id = Guid.NewGuid().ToString(), Name = "Walk the dog", IsComplete=true, Remark = string.Empty },
                new TodoItem { Id = Guid.NewGuid().ToString(), Name = "Run 5km in 40mins", IsComplete=true, Remark = string.Empty },
            };

            db.TodoItems.AddRange(todos);
            db.SaveChanges();
        }
    }
}
