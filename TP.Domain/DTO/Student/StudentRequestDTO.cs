namespace TP.Domain.DTO.Student
{
    public class StudentRequestDTO
    {
        public StudentRequestDTO()
        {
            LastUpdateDate = DateTime.Now;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime LastUpdateDate { get; private set; }
    }
}
