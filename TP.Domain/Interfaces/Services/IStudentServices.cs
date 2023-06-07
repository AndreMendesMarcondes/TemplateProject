using TP.Domain.DTO.Student;

namespace TP.Domain.Interfaces.Services
{
    public interface IStudentServices
    {
        Task<IEnumerable<StudentResponseDTO>> GetAll();
        Task<StudentResponseDTO> GetById(string studentId);
        Task Add(StudentRequestDTO studentRequestDTO);
        Task Remove(string studentId);
        Task Update(string studentId, StudentRequestDTO newStudent);
    }
}
