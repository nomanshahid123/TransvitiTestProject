using TransvitiTestProject.IServices;
using TransvitiTestProject.Models;

namespace TransvitiTestProject.Services
{
    public class StudentService: IStudentService
    {
        private static List<Student> _students = new List<Student>
    {
        new Student { Id = 1, Name = "Ali", Age = 20 },
        new Student { Id = 2, Name = "Ahmad", Age = 22 },
        new Student { Id = 3, Name = "Azhar", Age = 21 }
    };
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await Task.Run(() => _students);
        }
    }
}
