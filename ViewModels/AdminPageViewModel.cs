using CommunityToolkit.Mvvm.Input;
using InClassWork.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWork.ViewModels
{
    public partial class AdminPageViewModel
    {
        [RelayCommand]
        private async Task NavigateToUsersList()
        {
            await Shell.Current.GoToAsync(nameof(UsersListView));
		}
	}
}
