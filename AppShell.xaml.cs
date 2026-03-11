using InClassWork.Views;

namespace InClassWork
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AppShellViewModel();

			Routing.RegisterRoute(nameof(MainPageView), typeof(MainPageView));
			Routing.RegisterRoute(nameof(AccountPageView), typeof(AccountPageView));
			Routing.RegisterRoute(nameof(AdminPageView), typeof(AdminPageView));
			Routing.RegisterRoute(nameof(UsersListView), typeof(UsersListView));
			Routing.RegisterRoute(nameof(SignOutView), typeof(SignOutView));
		}

		protected override void OnNavigating(ShellNavigatingEventArgs args)
		{
			base.OnNavigating(args);

			//if (args.Target.Location.OriginalString.Contains("SignOutView"))
			//{
			//	args.Cancel(); // Stop the navigation to the white page

			//	// Run your logout logic here
			//	(App.Current as App)!.CurrentUser = null;
			//	Application.Current.Windows[0].Page = new SignInWorkout();
			//}
		}
	}
}
