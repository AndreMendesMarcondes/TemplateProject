using TP.Domain.DTO.Student;

namespace TP.Domain.Interfaces.Services
{
    public interface IStudentServices
    {
        Task<IEnumerable<StudentResponseDTO>> GetAll();
        Task<StudentResponseDTO> GetById(int studentId);
        Task Add(StudentRequestDTO studentRequestDTO);
        Task Remove(int studentId);
        Task Update(int studentId);
    }
}
