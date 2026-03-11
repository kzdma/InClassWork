using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWork.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWork.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isAdminVisible;

        public AppShellViewModel()
        {
            if((App.Current as App)!.CurrentUser!.IsAdmin)
                IsAdminVisible = true; // Set to true for testing purposes
		}

        [RelayCommand]
        private void SignOut()
        {
			//         (App.Current as App)!.CurrentUser = null;
			//Application.Current.Windows[0].Page = 
			//             new NavigationPage(new SignInWorkout());

			(App.Current as App)!.CurrentUser = null;

			// Use the Dispatcher on the current window to handle the swap
			var window = Application.Current.Windows.FirstOrDefault();
			if (window != null)
			{
				window.Dispatcher.Dispatch(() =>
				{
					// This replaces the Shell with a fresh NavigationPage or the SignIn page directly
					window.Page = new SignInWorkout();
				});
			}
		}
        [RelayCommand]
        private void NavigateToAdminPage()
        {
            Shell.Current.GoToAsync(nameof(AdminPageView));
		}
	}
}
