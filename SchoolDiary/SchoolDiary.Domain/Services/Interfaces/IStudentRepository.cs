using SchoolDiary.Domain.Model;

namespace SchoolDiary.Domain.Services;

/// <summary>
/// Интерфейс репозитория для работы с учениками.
/// </summary>
public interface IStudentRepository
{
    IEnumerable<Student> GetAllStudentsInClass(int classId);
    IEnumerable<Student> GetStudentsWithGradesOnDate(DateTime date);
    IEnumerable<Student> GetTopFiveStudents();
    IEnumerable<Student> GetStudentsWithMaxAverageGrade(DateTime startDate, DateTime endDate);
    IEnumerable<SubjectStatistics> GetSubjectStatistics();
}

/// <summary>
/// Статистика по предметам.
/// </summary>
public class SubjectStatistics
{
    public string SubjectName { get; set; }
    public int MinGrade { get; set; }
    public double AvgGrade { get; set; }
    public int MaxGrade { get; set; }