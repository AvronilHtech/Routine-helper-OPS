using RoutineHelper.Models;

namespace RoutineHelper.Services;

public interface IRoutineReminderService
{
    Task ScheduleDailyReminderAsync(RoutineItem routine);
}
