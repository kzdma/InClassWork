using InClassWork.Helper;
using InClassWork.Models;
using InClassWork.ViewModels;

namespace InClassWork.Views;

public partial class SignInWorkout : ContentPage
{
	public SignInWorkout()
	{
		InitializeComponent();
		BindingContext = new SignInWorkoutViewModel(this.Navigation);				
	}
}