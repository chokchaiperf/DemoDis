using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Firebase;
using Firebase.Crashlytics;

namespace DemoDis;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        FirebaseApp.InitializeApp(this);
        FirebaseCrashlytics.Instance.SetCrashlyticsCollectionEnabled(true);
        FirebaseCrashlytics.Instance.Log("Crashlytics Debugging Enabled");
        Log.Debug("Crashlytics", "Crashlytics Debugging Enabled");
    }
}
