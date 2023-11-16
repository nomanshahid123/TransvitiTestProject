using TransvitiTestProject.Models;

namespace TransvitiTestProject.IServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
    }
}
