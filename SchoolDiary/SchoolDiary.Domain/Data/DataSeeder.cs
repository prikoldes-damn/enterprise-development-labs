using System;
using System.Collections.Generic;
using System.Linq;
using SchoolDiary.Domain.Model;

namespace SchoolDiary.Domain.Data;

/// <summary>
/// Класс для заполнения коллекций данными.
/// </summary>
public static class DataSeeder
{
    public static readonly List<Class> Classes = new()
    {
        new Class { Id = 1, Number = 9, Letter = 'A' },
        new Class { Id = 2, Number = 10, Letter = 'B' },
        new Class { Id = 3, Number = 11, Letter = 'C' }
    };

    public static readonly List<Subject> Subjects = new()
    {
        new Subject { Id = 1, Name = "Математика", Year = 9 },
        new Subject { Id = 2, Name = "Физика", Year = 10 },
        new Subject { Id = 3, Name = "Химия", Year = 11 }
    };

    public static readonly List<Student> Students = new()
    {
        new Student
        {
            Id = 1,
            Passport = "1234567890",
            FullName = "Иванов Иван Иванович",
            BirthDate = new DateTime(2007, 5, 10),
            ClassId = 1
        },
        new Student
        {
            Id = 2,
            Passport = "0987654321",
            FullName = "Петров Петр Петрович",
            BirthDate = new DateTime(2006, 8, 15),
            ClassId = 2
        },
        new Student
        {
            Id = 3,
            Passport = "1122334455",
            FullName = "Сидорова Анна Сергеевна",
            BirthDate = new DateTime(2005, 3, 20),
            ClassId = 3
        }
    };

    public static readonly List<Grade> Grades = new()
    {
        new Grade
        {
            Id = 1,
            StudentId = 1,
            SubjectId = 1,
            Score = 5,
            Date = new DateTime(2023, 10, 15)
        },
        new Grade
        {
            Id = 2,
            StudentId = 2,
            SubjectId = 2,
            Score = 4,
            Date = new DateTime(2023, 10, 16)
        },
        new Grade
        {
            Id = 3,
            StudentId = 3,
            SubjectId = 3,
            Score = 3,
            Date = new DateTime(2023, 10, 17)
        }
    };

    static DataSeeder()
    {
        // Связываем учеников с их классами
        foreach (var student in Students)
        {
            student.Class = Classes.FirstOrDefault(c => c.Id == student.ClassId);
            student.Class?.Students.Add(student);
        }

        // Связываем оценки с учениками и предметами
        foreach (var grade in Grades)
        {
            grade.Student = Students.FirstOrDefault(s => s.Id == grade.StudentId);
            grade.Subject = Subjects.FirstOrDefault(s => s.Id == grade.SubjectId);

            if (grade.Student != null)
            {
                grade.Student.Grades.Add(grade);
            }

            if (grade.Subject != null)
            {
                grade.Subject.Grades.Add(grade);
            }
        }
    }
}
