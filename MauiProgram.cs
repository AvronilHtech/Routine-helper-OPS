using Microsoft.Extensions.Logging;
using RoutineHelper.Services;
using RoutineHelper.ViewModels;
using RoutineHelper.Views;

namespace RoutineHelper;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseLocalNotification()
;

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IRoutineReminderService, RoutineReminderService>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
