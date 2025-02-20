using DemoDis.Services.Firebase;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace DemoDis;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Register FirebaseCrashlyticsService
        builder.Services.AddSingleton<IFirebaseCrashlyticsService, FirebaseCrashlyticsService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterFirebase(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                Firebase.Core.App.Configure();
                Firebase.Crashlytics.Crashlytics.SharedInstance.Init();
                Firebase.Crashlytics.Crashlytics.SharedInstance.SetCrashlyticsCollectionEnabled(true);
                Firebase.Crashlytics.Crashlytics.SharedInstance.SendUnsentReports();
                return false;
            }));
#else
            events.AddAndroid(android => android.OnCreate((activity, bundle) => {
                Firebase.FirebaseApp.InitializeApp(activity);
            }));
#endif
        });

        return builder;
    }
}
