using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoutineHelper.Models;
using RoutineHelper.Services;

namespace RoutineHelper.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IRoutineReminderService _reminderService;

    public ObservableCollection<RoutineItem> Routines { get; } = new();

    [ObservableProperty]
    private string routineTitle = string.Empty;

    [ObservableProperty]
    private TimeSpan selectedTime = new(8, 0, 0);

    [ObservableProperty]
    private string statusMessage = "Create a routine and we'll remind you 10 minutes early.";

    public MainViewModel(IRoutineReminderService reminderService)
    {
        _reminderService = reminderService;
    }

    [RelayCommand]
    private async Task AddRoutineAsync()
    {
        if (string.IsNullOrWhiteSpace(RoutineTitle))
        {
            StatusMessage = "Routine title is required.";
            return;
        }

        var routine = new RoutineItem
        {
            Title = RoutineTitle.Trim(),
            Time = TimeOnly.FromTimeSpan(SelectedTime)
        };

        Routines.Add(routine);
        await _reminderService.ScheduleDailyReminderAsync(routine);

        StatusMessage = $"Saved '{routine.Title}'. Reminder set for {routine.Time.AddMinutes(-10):HH:mm} daily.";
        RoutineTitle = string.Empty;
    }
}
