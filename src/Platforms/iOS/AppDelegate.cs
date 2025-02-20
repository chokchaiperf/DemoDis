using Foundation;
using UIKit;

namespace DemoDis;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        Firebase.Core.App.Configure();

        // Enable Firebase debug logging
        NSUserDefaults.StandardUserDefaults.SetBool(true, "FIRDebugEnabled");
        
        return base.FinishedLaunching(app, options);
    }
}
