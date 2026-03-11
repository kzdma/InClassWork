using InClassWork.Models;
using InClassWork.Views;

namespace InClassWork
{
    public partial class App : Application
    {
        public AppUser? CurrentUser { get; set; }

		public App()
        {
            InitializeComponent();


        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
			NavigationPage navigationPage = new NavigationPage(new SignInWorkout());
			//NavigationPage navigationPage = new NavigationPage(new UsersListView());
			return new Window(navigationPage);


			// Start with the SignIn page as the root of the Window
			//var window = new Window(new UsersListView());
			//return window;
		}
	}
}