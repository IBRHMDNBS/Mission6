using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Entity;
using StudentAPI.DTOs;
using StudentAPI.Models;

namespace StudentAPI.Controllers;
[ApiController]
[Route("api/[controller]")]

public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;
    public StudentsController(AppDbContext context)
    {
        _context = context;
    }
    //
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var students = await _context.Students
    .Select(s => new GetStudentDto
    {
        Id = s.Id,
        FirstName = s.FirstName,
        LastName = s.LastName,
        StudentNumber = s.StudentNumber,
        Class = s.Class
    }).ToListAsync();

        return Ok(students);
    }
    //
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound(new ErrorModel(404, "Bu id'ye sahip bir öğrenci bulunamadı"));

        return Ok(student);
    }
    //
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var AddStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentNumber == dto.StudentNumber);
        if (AddStudent != null)
            return BadRequest(new ErrorModel(400, "Bu öğrenci numarası zaten mevcut!"));

        var student = new StudentEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            StudentNumber = dto.StudentNumber,
            Class = dto.Class
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }
    //
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentDto dto)
    {
       if (!ModelState.IsValid)return BadRequest(ModelState);

       if (id != dto.Id)return BadRequest(new ErrorModel(400, "URL'deki ID ile body'deki ID uyuşmuyor."));

        var student = await _context.Students.FindAsync(id);
        if (student == null)return NotFound(new ErrorModel(404, "Öğrenci bulunamadı!"));

       var StudentNumber = await _context.Students.FirstOrDefaultAsync(s => s.StudentNumber == dto.StudentNumber && s.Id != dto.Id);
       if (StudentNumber != null)return BadRequest(new ErrorModel(400, "Bu öğrenci numarası zaten başka bir öğrenciye ait!"));

        student.FirstName = dto.FirstName;
        student.LastName = dto.LastName;
        student.StudentNumber = dto.StudentNumber;
        student.Class = dto.Class;

        _context.Students.Update(student);
        await _context.SaveChangesAsync();

        return Ok(student);
    }
    //
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest(new ErrorModel(400, "Geçerli bir öğrenci ID giriniz."));

        var student = await _context.Students.FindAsync(id);
        if (student == null)
            return NotFound(new ErrorModel(404, "Öğrenci bulunamadı!"));

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return Ok(student);
    }
}




