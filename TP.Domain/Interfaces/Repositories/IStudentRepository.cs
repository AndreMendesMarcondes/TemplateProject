using TP.Domain.Domain;

namespace TP.Domain.Interfaces.Data
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int studentId);
        Task Add(Student student);
        Task Remove(int studentId);
        Task Update(int studentId);
    }
}
