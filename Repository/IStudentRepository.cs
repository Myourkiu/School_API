using School_API.Model;

namespace School_API.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentsById(Guid Id);
        Task<Student> CreateStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Guid Id);
    }
}
