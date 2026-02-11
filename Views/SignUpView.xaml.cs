namespace InClassWork.Views;

public partial class SignUpView : ContentPage
{
	public SignUpView()
	{
		InitializeComponent();
		BindingContext = new ViewModels.SignUpViewModel();
	}
}