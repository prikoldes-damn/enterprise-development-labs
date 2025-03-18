namespace SchoolDiary.Domain.Model;

/// <summary>
/// Класс, представляющий ученика.
/// </summary>
public class Student
{
    public int Id { get; set; }
    public string Passport { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public List<Grade> Grades { get; set; } = new();
}