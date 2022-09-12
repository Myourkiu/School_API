using Microsoft.EntityFrameworkCore;
using School_API.Data;
using School_API.Model;

namespace School_API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDb;
        public StudentRepository(AppDbContext appDb)
        {
            _appDb = appDb;
        }


        public async Task<Student> CreateStudent(Student student)
        {
            _appDb.Students.Add(student); //adiciona o student ao db
            await _appDb.SaveChangesAsync(); //salva no db

            return student; //retorna um student após o salvamento
        }

        public async Task DeleteStudent(Guid Id)
        {
            var studentToDelete = _appDb.Students.FindAsync(Id); //cria uma variável e procura pelo Id do student
            _appDb.Students.Remove(await studentToDelete); //remove o student do db

            await _appDb.SaveChangesAsync(); //salva as alterações
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _appDb.Students.ToListAsync(); //retorna uma lista dos alunos do db
        }

        public async Task<Student> GetStudentsById(Guid Id)
        {
            return await _appDb.Students.FindAsync(Id); //retorna um aluno especificado pelo Id
        }

        public async Task UpdateStudent(Student student)
        {
            _appDb.Entry(student).State = EntityState.Modified; //da uma entrada para modificar o entitystate do student
            await _appDb.SaveChangesAsync(); //salva as alterações
        }
    }
}
