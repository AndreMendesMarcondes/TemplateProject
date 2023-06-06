using TP.Domain.Domain;

namespace TP.Domain.Interfaces.Data
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int studentId);
        Task Add(Student student);
        Task RemoveById(int studentId);
        Task Update(int studentId, Student newStudent);
    }
}
