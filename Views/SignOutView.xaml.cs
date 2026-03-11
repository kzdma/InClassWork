namespace InClassWork.Views;

public partial class SignOutView : ContentPage
{
	public SignOutView()
	{
		InitializeComponent();
			
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();

		//Navigate to the sign-in page after signing out
		//Sign out the user by clearing the current user and navigating to the sign-in page
		(App.Current as App)!.CurrentUser = null;

		//Application.Current.Windows[0].Page = new SignInWorkout();
		//Application.Current?.ActivateWindow(new Window(new SignInWorkout()));

		// 2. Safely swap the Window Root
		// We use FirstOrDefault() to avoid "Index out of range" if the list is empty
		//var window = Application.Current?.Windows.FirstOrDefault();

		//if (this.Window != null)
		//{
		//	this.Window.Page = new SignInWorkout();
		//}

		// 2. Schedule the swap to happen AFTER the current UI cycle finishes
		Dispatcher.Dispatch(() =>
		{
			var window = Application.Current?.Windows.FirstOrDefault();
			if (window != null)
			{
				// This replaces the Shell with the SignIn page
				window.Page = new SignInWorkout();
			}
		});
	}
}