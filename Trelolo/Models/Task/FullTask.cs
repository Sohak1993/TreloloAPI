namespace Trelolo.Models.Task
{
    public class FullTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdList { get; set; }
    }
}
