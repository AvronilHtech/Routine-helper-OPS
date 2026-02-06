using Plugin.LocalNotification;
using RoutineHelper.Models;

namespace RoutineHelper.Services;

public class RoutineReminderService : IRoutineReminderService
{
    public Task ScheduleDailyReminderAsync(RoutineItem routine)
    {
        var nextReminder = GetNextReminderTime(routine.Time);

        var request = new NotificationRequest
        {
            NotificationId = Math.Abs(routine.Id.GetHashCode()),
            Title = $"Upcoming routine: {routine.Title}",
            Description = $"Starts at {routine.Time:HH:mm}. Get ready!",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = nextReminder,
                RepeatType = NotificationRepeat.Daily
            }
        };

        return LocalNotificationCenter.Current.Show(request);
    }

    private static DateTime GetNextReminderTime(TimeOnly routineTime)
    {
        var today = DateTime.Now.Date;
        var routineDateTime = today.Add(routineTime.ToTimeSpan());
        var reminderDateTime = routineDateTime.AddMinutes(-10);

        if (reminderDateTime <= DateTime.Now)
        {
            reminderDateTime = reminderDateTime.AddDays(1);
        }

        return reminderDateTime;
    }
}
