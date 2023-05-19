
namespace Domain.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
    }
}
