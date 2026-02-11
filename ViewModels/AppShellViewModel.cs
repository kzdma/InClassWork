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
            (App.Current as App)!.CurrentUser = null;
			Application.Current.Windows[0].Page = new SignInWorkout();
		}
	}
}
