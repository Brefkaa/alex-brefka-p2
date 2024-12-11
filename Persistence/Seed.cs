using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.ToDoList.Any())
            {
                var ToDoList = new List<Todo>
                {
                    new Todo {
                        Task = "Do the dishes",
                        Date = DateTime.Now
                    },
                    new Todo {
                        Task = "Do the laundry",
                        Date = DateTime.Now
                    },
                    new Todo {
                        Task = "Clean the living room",
                        Date = DateTime.Now
                    },
                };

                context.ToDoList.AddRange(ToDoList);
                context.SaveChanges();
            }
        }
    }
}