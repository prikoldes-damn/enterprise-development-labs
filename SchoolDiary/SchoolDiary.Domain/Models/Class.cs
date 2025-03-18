namespace SchoolDiary.Domain.Model;

/// <summary>
/// Класс, представляющий класс (группу учеников).
/// </summary>
public class Class
{
    public int Id { get; set; }
    public int Number { get; set; }
    public char Letter { get; set; }
    public List<Student> Students { get; set; } = new();
}