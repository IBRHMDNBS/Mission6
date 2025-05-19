using StudentAPI.Data;
using StudentAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bogus;



namespace StudentAPI.Data.Seeder;

public class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Students.Any())
            return;

        var userFaker = new Faker<StudentEntity>()
           .RuleFor(s => s.FirstName, f => f.Name.FirstName())
           .RuleFor(s => s.LastName, f => f.Name.LastName())
           .RuleFor(s => s.StudentNumber, f => f.Random.Int(100, 999).ToString())
           .RuleFor(s => s.Class, f => f.PickRandom(new[] { "A", "B", "C", "D" }));

        //20 tane sahte öğrenci oluştur
        var students = userFaker.Generate(20);
        context.Students.AddRange(students);
        context.SaveChanges();
    }

    
    



}
