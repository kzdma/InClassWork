using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWork.Helper;
using InClassWork.Models;
using InClassWork.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InClassWork.ViewModels
{
	public partial class SignUpViewModel: ObservableObject
	{
		AppUser _newUser;
		DBMokup _dbMokup;
		
		private string? _firstName;
		private string? _lastName;
		private string? _userEmail;
		private string? _userPassword;
		private string? _userMobile;
		[ObservableProperty] private string _passwordButtonText;
		[ObservableProperty] private bool _isPasswordNotVisible;
		

		public string? FirstName
		{
			get => _firstName;
			set
			{
				if (_firstName != value)
				{
					_firstName = value;
					OnPropertyChanged();
					(SignUpCommand as Command).ChangeCanExecute();

				}
			}
		}
		public string? LastName
		{
			get => _lastName;
			set
			{
				if (_lastName != value)
				{
					_lastName = value;
					OnPropertyChanged();
					(SignUpCommand as Command).ChangeCanExecute();

				}
			}
		}
		public string? UserEmail
		{
			get => _userEmail;
			set
			{
				if (value != _userEmail)
				{
					_userEmail = value;
					OnPropertyChanged();
					(SignUpCommand as Command).ChangeCanExecute();

				}
			}
		}
		public string? UserPassword
		{
			get => _userPassword;
			set
			{
				if (_userPassword != value)
				{
					_userPassword = value;
					OnPropertyChanged();
					(SignUpCommand as Command).ChangeCanExecute();

				}
			}
		}
		public string? UserMobile
		{
			get => _userMobile;
			set
			{
				if (_userMobile != value)
				{
					_userMobile = value;
					OnPropertyChanged();
					(SignUpCommand as Command).ChangeCanExecute();

				}
			}
		}


		public ICommand SignUpCommand { get; }


		public SignUpViewModel()
		{
			_dbMokup = new DBMokup();
			PasswordButtonText = FontHelper.OPEN_EYE_ICON;
			IsPasswordNotVisible = true;

			SignUpCommand = new Command(SignUp, ValidateData);
		}

		private bool ValidateData()
		{
			var fnameOK = !string.IsNullOrEmpty(_firstName);
			var lnameOK = !string.IsNullOrEmpty(_lastName);
			var emailOK = !string.IsNullOrEmpty(_userEmail);
			var passOK = string.IsNullOrEmpty(_userPassword) ? false : _userPassword.Length > 5;
			var mobileOK = string.IsNullOrEmpty(_userMobile) ? false : _userMobile.Length == 10;

			return fnameOK && lnameOK && emailOK && passOK && mobileOK;

		}

		[RelayCommand]
		private void TogglePassword()
		{
			IsPasswordNotVisible = !IsPasswordNotVisible;

			if (IsPasswordNotVisible)
				PasswordButtonText = FontHelper.OPEN_EYE_ICON;
			else
				PasswordButtonText = FontHelper.CLOSED_EYE_ICON;
		}	
		private async void SignUp()
		{
			AppUser newuser = new AppUser()
			{
				FirstName = _firstName,
				LastName = _lastName,
				UserEmail = _userEmail,
				UserMobile = _userMobile,
				RegDate = DateTime.Now.ToShortDateString()
			};

			//Check if user email not exist
			if(_dbMokup.GetUserByEmail(newuser.UserEmail!)!= null) 
			{
				//User email exist - show error message
				//using CommunityToolkit.Maui.Alerts
				await Toast.Make($"Email already exists!", ToastDuration.Short, 14).Show();
				return;
			}

			//Add user to database
			_dbMokup.Insert(newuser);

			//Sign In the user		 
			//Set CurrentUser in App			
			(App.Current as App)!.CurrentUser = newuser;

			//Navigate to MainPage
			Application.Current!.Windows[0].Page = new AppShell();
		}
	}
}
	