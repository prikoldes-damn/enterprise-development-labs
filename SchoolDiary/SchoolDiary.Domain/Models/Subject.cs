namespace SchoolDiary.Domain.Model;

/// <summary>
/// Класс, представляющий предмет.
/// </summary>
public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public List<Grade> Grades { get; set; } = new();
}