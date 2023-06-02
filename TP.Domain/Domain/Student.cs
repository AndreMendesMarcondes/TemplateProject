namespace TP.Domain.Domain
{
    public class Student
    {
        public int IdStudent { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
