namespace RoutineHelper.Models;

public class RoutineItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public TimeOnly Time { get; set; }

    public string DisplayTime => Time.ToString("hh\\:mm");
}
