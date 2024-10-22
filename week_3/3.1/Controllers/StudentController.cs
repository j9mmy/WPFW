using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using deez.Data;
using deez.Models;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly DatabaseContext _context;

    public StudentController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet("MoreThanOneGrade")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsWithMoreThanOneGrade()
    {
        return await _context.Students
            .Include(column => column.Grades)
            .Where(student => student.Grades.Count() > 1)
            .ToListAsync();
    }

    [HttpGet("AmountOfTeachers")]
    public async Task<ActionResult<int>> GetAmountOfTeachers()
    {
        return await _context.Teachers.CountAsync();
    }

    [HttpGet("NoTeachers")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsWithNoTeachers()
    {
        return await _context.Students
            .Include(column => column.Teachers)
            .Where(student => student.Teachers.Any() == false)
            .ToListAsync();
    }

    [HttpGet("SortedByName")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsSortedByName()
    {
        return await _context.Students
            .OrderBy(student => student.Name)
            .ToListAsync();
    }

    [HttpGet("HasChemistryTeacher")] // Logisch gezien moet dit werken, maar door de meer-op-meer relatie zit het vast in een oneindige lus :(
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsThatHaveChemistryTeachers()
    {
        return await _context.Students
            .Include(column => column.Teachers)
            .Where(student => student.Teachers.Any(teacher => teacher.TeachingCourse == "Chemistry"))
            .ToListAsync();
    }
}