using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TP.Domain.Domain;
using TP.Domain.DTO.Student;
using TP.Domain.Interfaces.Data;
using TP.Domain.Interfaces.Services;

namespace TP.Service.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly ILogger<StudentServices> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;
        private readonly ICacheControlService _cacheControlService;

        public StudentServices(ILogger<StudentServices> logger,
                               IStudentRepository studentRepository,
                               IMemoryCache memoryCache,
                               IMapper mapper,
                               ICacheControlService cacheControlService)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _memoryCache = memoryCache;
            _mapper = mapper;
            _cacheControlService = cacheControlService;
        }

        public async Task Add(StudentRequestDTO studentRequestDTO)
        {
            _logger.LogInformation("Service: adicionando student");

            try
            {
                var student = _mapper.Map<Student>(studentRequestDTO);
                await _studentRepository.Add(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Service: erro ao adicionar student. {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<StudentResponseDTO>> GetAll()
        {
            _logger.LogInformation("Service: buscando todos os student");

            try
            {
                IEnumerable<StudentResponseDTO> responseDTO = (IEnumerable<StudentResponseDTO>)_memoryCache.Get("StudentResponseDTO");

                if (responseDTO == null)
                {
                    var students = await _studentRepository.GetAll();
                    responseDTO = _mapper.Map<IEnumerable<StudentResponseDTO>>(students);
                    _cacheControlService.SettingTimeAndCache(responseDTO, "StudentResponseDTO");
                }

                return responseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Service: erro ao buscar todos os student. {ex.Message}");
                throw;
            }
        }

        public async Task<StudentResponseDTO> GetById(int studentId)
        {
            _logger.LogInformation("Service: buscando student");

            try
            {
                var student = await _studentRepository.GetById(studentId);
                var result = _mapper.Map<StudentResponseDTO>(student);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Service: erro ao buscar student. {ex.Message}");
                throw;
            }
        }

        public async Task Remove(int studentId)
        {
            _logger.LogInformation("Service: removendo student");

            try
            {
                await _studentRepository.RemoveById(studentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Service: erro ao remover student. {ex.Message}");
                throw;
            }
        }

        public async Task Update(int studentId, StudentRequestDTO newStudent)
        {
            _logger.LogInformation("Service: atualizando student");

            try
            {
                if (await GetById(studentId) != null)
                {
                    var student = _mapper.Map<Student>(newStudent);
                    await _studentRepository.Add(student);
                    await _studentRepository.Update(studentId, student);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Service: erro ao atualizar student. {ex.Message}");
                throw;
            }
        }
    }
}
