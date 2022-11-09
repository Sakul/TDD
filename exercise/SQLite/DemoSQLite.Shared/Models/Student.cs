namespace DemoSQLite.Shared.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
