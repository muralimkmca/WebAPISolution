using EntityframeworkCore6.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityframeworkCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly StudentDbContext studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        [HttpGet]
        [ActionName("GetStudents")]
        public async Task<IActionResult> GetStudentList()
        {
            var students = await studentDbContext.Students.ToListAsync();
            return Ok(students);
        }

        [HttpPost]  
        public async Task<IActionResult> InsertStudent([FromBody]Students student)
        {
            await studentDbContext.Students.AddAsync(student);
            await studentDbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{StudentId:int}")]
        
        public async Task<IActionResult> DeleteStudent(int StudentId)
        {
            var removestudent = await studentDbContext.Students.FirstOrDefaultAsync(x => x.StudentId == StudentId);
            if(removestudent != null)
            {
                studentDbContext.Remove(removestudent);
                await studentDbContext.SaveChangesAsync();
                return Ok(removestudent);
            }
            return NotFound("Student Not Found");
        }
    }
}
