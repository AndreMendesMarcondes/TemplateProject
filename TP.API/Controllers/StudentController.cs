using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TP.Domain.DTO.Student;
using TP.Domain.Interfaces.Services;

namespace TP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentServices _studentServices;

        public StudentController(ILogger<StudentController> logger,
                                 IStudentServices studentServices)
        {
            _logger = logger;
            _studentServices = studentServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Controller: Buscando todos os students");

            try
            {
                var students = await _studentServices.GetAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: Erro ao buscar todos os students. {ex.Message}");
                return StatusCode(500, "Erro ao buscar todos os students");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"Controller: Buscando student por id {id}");

            try
            {
                var student = await _studentServices.GetById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: Erro ao buscar student por id. {ex.Message}");
                return StatusCode(500, "Erro ao buscar student por id");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(StudentRequestDTO studentRequest)
        {
            _logger.LogInformation($"Controller: Inserindo student {JsonConvert.SerializeObject(studentRequest)}");

            try
            {
                await _studentServices.Add(studentRequest);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: Erro ao inserir student. {ex.Message}");
                return StatusCode(500, "Erro ao inserir student");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int studentId, StudentRequestDTO studentRequest)
        {
            _logger.LogInformation($"Controller: Atualizando student {JsonConvert.SerializeObject(studentRequest)}");

            try
            {
                await _studentServices.Update(studentId,studentRequest);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: Erro ao atualizar student. {ex.Message}");
                return StatusCode(500, "Erro ao atualizar student");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int studentId)
        {
            _logger.LogInformation($"Controller: Removendo student {studentId}");

            try
            {
                await _studentServices.Remove(studentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: Erro ao remover student {studentId}. {ex.Message}");
                return StatusCode(500, "Erro ao remover student");
            }
        }
    }
}
