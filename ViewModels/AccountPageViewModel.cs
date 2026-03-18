using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWork.Helper;
using InClassWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWork.ViewModels
{
	public partial class AccountPageViewModel: ObservableObject
	{
		#region Properties
		[ObservableProperty]
		private string _firstName;

		[ObservableProperty]
		private string _lastName;

		[ObservableProperty]
		private string _userEmail;

		[ObservableProperty]
		private string _userMobile;

		[ObservableProperty]
		private AppUser _recievedUser; // Used to receive user details from the UsersListPage

		[ObservableProperty]
		private bool _isDeleteButtonVisible;

		[ObservableProperty]
		private string _deleteIcon;

		[ObservableProperty]
		private ImageSource _userImageSource;

		[ObservableProperty]
		private bool _errorMessageIsVisible;

		[ObservableProperty]
		private string _errorMessage;

		[ObservableProperty]
		private bool _isBusy;
		#endregion


		public AccountPageViewModel()
		{
			DeleteIcon = FontHelper.DELETE_USER_ICON;
		}

		[RelayCommand]
		private void Delete()
		{
			// This command can be used to delete the user's account
		}

		[RelayCommand]
		private void GetUserImage()
		{
			// This command can be used to fetch the user's profile image from the database
		}
	}
}
