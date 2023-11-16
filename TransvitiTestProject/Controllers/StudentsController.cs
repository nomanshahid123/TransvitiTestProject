using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransvitiTestProject.DbContextHandler;
using TransvitiTestProject.IServices;
using TransvitiTestProject.Models;

namespace TransvitiTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentsService;
        private IAuthenticate _authenticateService;
        private readonly StudentDbContext _dbContext;
        public StudentsController(IStudentService studentsService, IAuthenticate authenticateService, StudentDbContext dbContext)
        {
            _studentsService = studentsService;
            _authenticateService = authenticateService;
            _dbContext = dbContext;
        }



        [AllowAnonymous]
        [HttpPost("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateModel model)
        {
            var user = await _authenticateService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [HttpGet("GetAllStudents")]
        [Authorize]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var student = await _studentsService.GetAll();
                if (student == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No Record Found!");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetAllStudentsFromDB")]
        [Authorize]
        public async Task<IActionResult> GetAllStudentsFromDB()
        {
            try
            {
                var student = await _dbContext.Students.ToListAsync();
                if (student == null || student.Count == 0)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No Record Found!");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
        [Authorize]
        [HttpPost("SaveStudentToDB")]
        public async Task<IActionResult> SaveStudentToDB([FromBody] Student student)
        {
            try
            {
                _dbContext.Students.Add(student);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, $"Record Saved!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
