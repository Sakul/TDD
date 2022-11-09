namespace DemoSQLite.Shared.Models
{
    public class Teacher
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}
