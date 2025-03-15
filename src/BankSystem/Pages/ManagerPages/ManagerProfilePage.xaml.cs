using Application.Interfaces;
using BankSystem.Pages.ListsPages;
using Domain.Entities;

namespace BankSystem.Pages.ManagerPages;

public partial class ManagerProfilePage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    private User _user;
    public ManagerProfilePage(User user, IUnitOfWork unitOfWork)
	{
        _user = user;
        _unitOfWork = unitOfWork;
		InitializeComponent();
	}
    private async void OnAccountRequestsClicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new AccountRequestsListPage(_unitOfWork));
    }

    private async void OnTransactionsClicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new TransactionsListPage(_unitOfWork));
    }

    private async void OnAccountsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountsListPage(_unitOfWork));
    }

    private async void OnUsersClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UsersListPage(_unitOfWork));
    }
}