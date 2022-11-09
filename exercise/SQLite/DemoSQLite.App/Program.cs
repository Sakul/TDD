using DemoSQLite.Shared.Models;
using DemoSQLite.Shared.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

const string TitleName = "SQLite (DEMO)";
Console.WriteLine(TitleName);
Console.WriteLine(new string('─', TitleName.Length));

// Create UniversityDbContext with SQLite
var connBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
var connection = new SqliteConnection(connBuilder.ConnectionString);
var options = new DbContextOptionsBuilder<UniversityDbContext>()
    .UseSqlite(connection)
    .Options;
var universityCtx = new UniversityDbContext(options);
universityCtx.Database.OpenConnection();
universityCtx.Database.EnsureCreated();


// Add new teacher
var teacher = new Teacher
{
    Id = "T01",
    Name = "Alice",
};
universityCtx.Teachers.Add(teacher);

// Add new student
var student = new Student
{
    Id = "S01",
    Name = "Saladpuk",
    TeacherId = teacher.Id,
    Teacher = teacher,
};
universityCtx.Students.Add(student);
await universityCtx.SaveChangesAsync();

// Show all teachers
Console.WriteLine("Teachers");
foreach (var item in universityCtx.Teachers)
{
    Console.WriteLine(convertToString(item));
}

Console.WriteLine();

// Show all students
Console.WriteLine("Students");
foreach (var item in universityCtx.Students)
{
    Console.WriteLine(convertToString(item));
}

//// Add new student that conflict with UNIQUE constraint
//var otherStudent = new Student
//{
//    Id = "S01",
//    Name = "Au",
//    TeacherId = teacher.Id,
//    Teacher = teacher,
//};
//universityCtx.Students.Add(otherStudent);
//await universityCtx.SaveChangesAsync();

string convertToString(object target)
    => JsonSerializer.Serialize(target, new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    });