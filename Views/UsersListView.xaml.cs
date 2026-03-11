using InClassWork.ViewModels;

namespace InClassWork.Views;

public partial class UsersListView : ContentPage
{
	public UsersListView()
	{
		InitializeComponent();
		BindingContext = new ViewModels.UsersListViewModel();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		//((ViewModels.UsersListViewModel)BindingContext).GetUsersCommand.Execute(null);

		(BindingContext as UsersListViewModel)!.OnAppearing();
	}
}