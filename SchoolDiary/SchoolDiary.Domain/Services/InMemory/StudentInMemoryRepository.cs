using System;
using System.Collections.Generic;
using System.Linq;
using SchoolDiary.Domain.Model;
using SchoolDiary.Domain.Data;

namespace SchoolDiary.Domain.Services.InMemory;

/// <summary>
/// Репозиторий для работы с учениками в памяти.
/// </summary>
public class StudentInMemoryRepository : IStudentRepository
{
    public IEnumerable<Student> GetAllStudentsInClass(int classId)
    {
        return DataSeeder.Students
            .Where(s => s.ClassId == classId)
            .OrderBy(s => s.FullName)
            .ToList();
    }

    public IEnumerable<Student> GetStudentsWithGradesOnDate(DateTime date)
    {
        return DataSeeder.Grades
            .Where(g => g.Date == date)
            .Select(g => g.Student)
            .Distinct()
            .ToList();
    }

    public IEnumerable<Student> GetTopFiveStudents()
    {
        return DataSeeder.Grades
            .GroupBy(g => g.StudentId)
            .Select(g => new
            {
                StudentId = g.Key,
                AverageGrade = g.Average(gr => gr.Score)
            })
            .OrderByDescending(g => g.AverageGrade)
            .Take(5)
            .Join(DataSeeder.Students,
                g => g.StudentId,
                s => s.Id,
                (g, s) => s)
            .ToList();
    }

    public IEnumerable<Student> GetStudentsWithMaxAverageGrade(DateTime startDate, DateTime endDate)
    {
        return DataSeeder.Grades
            .Where(g => g.Date >= startDate && g.Date <= endDate)
            .GroupBy(g => g.StudentId)
            .Select(g => new
            {
                StudentId = g.Key,
                AverageGrade = g.Average(gr => gr.Score)
            })
            .OrderByDescending(g => g.AverageGrade)
            .Join(DataSeeder.Students,
                g => g.StudentId,
                s => s.Id,
                (g, s) => s)
            .ToList();
    }

    public IEnumerable<SubjectStatistics> GetSubjectStatistics()
    {
        return DataSeeder.Grades
            .GroupBy(g => g.SubjectId)
            .Select(g => new SubjectStatistics
            {
                SubjectName = g.First().Subject.Name,
                MinGrade = g.Min(gr => gr.Score),
                AvgGrade = g.Average(gr => gr.Score),
                MaxGrade = g.Max(gr => gr.Score)
            })
            .ToList();
    }
}