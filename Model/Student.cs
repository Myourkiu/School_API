namespace School_API.Model
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
