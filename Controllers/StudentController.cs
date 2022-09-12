using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_API.Data;
using School_API.Model;
using School_API.Repository;
using School_API.ViewModel;

namespace School_API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("student")]

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetAllStudents();
        }

        [HttpGet]
        [Route("student/{Id}")]

        public async Task<ActionResult<Student>> GetStudentByIdAsync([FromRoute] Guid Id)
        {
            return await _studentRepository.GetStudentsById(Id);
        }

        [HttpPost]
        [Route("student")]

        public async Task<ActionResult<Student>> PostStudentAsync([FromServices]AppDbContext context,
            [FromBody]CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = new Student
            {
                Date = DateTime.Now,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age
            };

            try
            {
                await context.AddAsync(student);
                await context.SaveChangesAsync();
                return Created($"v1/student/{student.Id}", student);
            }
            catch (Exception e)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("student/{Id}")]

        public async Task<ActionResult> PutStudentAsync([FromServices] AppDbContext context,
            [FromBody] CreateViewModel model, [FromRoute] Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = await context.Students.FirstOrDefaultAsync(x => x.Id == Id);

            if (student == null)
                return NotFound();

            try
            {
                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.Age = model.Age;

                context.Update(student);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("student/{Id}")]

        public async Task<ActionResult> DeleteStudentAsync([FromServices] AppDbContext context,
            [FromRoute] Guid Id)
        {
            var student = await context.Students.FirstOrDefaultAsync(x => x.Id == Id);

            try
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest();
            }
        }
    }
}
