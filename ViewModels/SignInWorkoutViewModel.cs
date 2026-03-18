using InClassWork.Helper;
using InClassWork.Models;
using InClassWork.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InClassWork.ViewModels
{
	public class SignInWorkoutViewModel:ViewModelBase
	{
		#region Data Members
		private string? _userName;
		private string? _password;
		private string? _errorMessage;
		private bool _errorMessageVisible;
		private bool _ispasswordNotVisible;
		private Color? _errorMessageColor;
		private string _passwordButtonText;

		private readonly INavigation? _navigationPage;
		private DBMokup? _db;
		#endregion

		#region Properties
		public string UserName
		{
			get => _userName!;
			set
			{
				if (_userName != value)
				{
					_userName = value;
					OnPropertyChanged();
					(SignInCommand as Command).ChangeCanExecute();
				}
			}
		}
		public string UserPassword
		{
			get => _password!;
			set
			{
				if (_password != value)
				{
					_password = value;
					OnPropertyChanged();
					(SignInCommand as Command).ChangeCanExecute();
				}
			}
		}
		public string ErrorMessage
		{
			get => _errorMessage!;
			set
			{
				if (_errorMessage != value)
				{
					_errorMessage = value;
					OnPropertyChanged();
				}
			}
		}
		public bool ErrorMessageVisible
		{
			get => _errorMessageVisible;
			set
			{
				if (_errorMessageVisible != value)
				{
					_errorMessageVisible = value;
					OnPropertyChanged();
				}
			}
		}
		public Color ErrorMessageColor
		{
			get => _errorMessageColor!;
			set
			{
				if (_errorMessageColor != value)
				{
					_errorMessageColor = value;
					OnPropertyChanged();
				}
			}
		}
		public bool IsPasswordNotVisible
		{
			get => _ispasswordNotVisible;
			set
			{
				if (_ispasswordNotVisible != value)
				{
					_ispasswordNotVisible = value;
					OnPropertyChanged();
				}
			}
		}
		public string PasswordButtonText
		{
			get => _passwordButtonText;
			set
			{
				if (_passwordButtonText != value)
				{
					_passwordButtonText = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand ShowPasswordCommand { get; }
		public ICommand SignInCommand { get; }

		public ICommand NavigateToSignUpCommand { get; }
		#endregion

		public SignInWorkoutViewModel(INavigation? navigationPage)
		{
			_ispasswordNotVisible = true;
			_passwordButtonText = FontHelper.CLOSED_EYE_ICON;
			_errorMessageVisible = false;
			_errorMessage = String.Empty;
			_db = new DBMokup();

			ShowPasswordCommand = new Command(TogglePassordButtonClick);
			SignInCommand = new Command(SignInButtonClick, CanSignIn);
			NavigateToSignUpCommand = new Command(async () =>
			{
				if (navigationPage != null)
				{
					await navigationPage.PushAsync(new Views.SignUpView());
				}
			});
			_navigationPage = navigationPage;

			//Debug Mode
			UserName = "admin@mail.com";
			UserPassword = "123456";
		}

		private void TogglePassordButtonClick()
		{
			IsPasswordNotVisible = !IsPasswordNotVisible;

			if (IsPasswordNotVisible)
				PasswordButtonText = FontHelper.OPEN_EYE_ICON;
			else
				PasswordButtonText = FontHelper.CLOSED_EYE_ICON;
		}

		private void SignInButtonClick()
		{
			ErrorMessageVisible = true;


			if (_db!.isExist(UserName, UserPassword))
			{
				//Get User from DB
				AppUser user = _db.GetUserByEmail(UserName)!;

				//Set CurrentUser in App			
				(App.Current as App)!.CurrentUser = user;

				//Navigate to MainPage
				// SWAP the page on the existing window
				if (Application.Current?.Windows.Count > 0)
				{
					Application.Current.Windows[0].Page = new AppShell();
				}
			}
			else
			{
				ErrorMessage = AppMessages.SignInErrorMessage;
				ErrorMessageColor = Colors.Red;
			}


			// Use the Dispatcher to prevent the white/blank screen
			//MainThread.BeginInvokeOnMainThread(() =>
			//{
			//	var window = Application.Current?.Windows.FirstOrDefault();
			//	if (window != null)
			//	{
			//		// Resetting the Page here via Dispatcher ensures the UI thread is ready
			//		window.Page = new AppShell();
			//	}
			//});
		}
		
		private bool CanSignIn()
		{
			return !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));
		}
	}
}
