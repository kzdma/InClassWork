using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWork.Helper;
using InClassWork.Models;
using InClassWork.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InClassWork.ViewModels
{
    public partial class UsersListViewModel : ObservableObject
    {
		private List<AppUser> _allUsers; //List of users to be displayed
		public ObservableCollection<AppUser> AllUsers { get; set; }


		private ICommand GetUsers2Command;

        public Command GetUsersCommand
		{
			get
			{
				return new Command(() =>
				{
					// This command can be used to fetch all users from the database
					// For example, it could be bound to a button to refresh the user list
					_allUsers = new DBMokup().GetUsers();
					AllUsers.Clear(); // Clear the existing collection
					foreach (var user in _allUsers)
					{
						AllUsers.Add(user); // Add each user to the ObservableCollection
					}
				});
			}
		}

		[RelayCommand]
		private void NavigateToAccountPage()
		{		
			Shell.Current.GoToAsync("AccountPageView");
		}

		[ObservableProperty]
        private string _usersFilterButtonText;

        [ObservableProperty]
        private bool _isBusy;

        public UsersListViewModel()
        {
            UsersFilterButtonText = FontHelper.USERS_FILTER_ON;
			AllUsers = new(); // Initialize the ObservableCollection
			GetUsers2Command = new Command(GetUsersFromDB);
		}

		private void GetUsersFromDB()
		{
			_allUsers = new DBMokup().GetUsers();
		}

		internal void OnAppearing()
		{
			GetUsersCommand.Execute(null);
		}
	}
}
