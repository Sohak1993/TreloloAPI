namespace Trelolo.Models.List
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int IdProject { get; set; }
    }
}
