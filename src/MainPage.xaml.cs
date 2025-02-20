using System.IO;
using DemoDis.Services.Firebase;

namespace DemoDis;

public partial class MainPage : ContentPage
{
	int count = 0;

	private	readonly IFirebaseCrashlyticsService _crashlyticsService;

	public MainPage(IFirebaseCrashlyticsService crashlyticsService)
	{
		InitializeComponent();
		_crashlyticsService = crashlyticsService;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
		_crashlyticsService.Log(new Exception("This is a test exception"));
	}
}
