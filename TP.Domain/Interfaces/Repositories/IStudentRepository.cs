using TP.Domain.Domain;

namespace TP.Domain.Interfaces.Data
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(string studentId);
        Task Add(Student student);
        Task RemoveById(string studentId);
        Task Update(string studentId, Student newStudent);
    }
}
