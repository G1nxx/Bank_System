using Application.Interfaces;
using AutoMapper;
using BankSystem.Pages.BankPages;
using BankSystem.Pages.ListsPages;
using Domain.Entities;
using Infrastructure.Models;

namespace BankSystem.Pages.AdminPages;

public partial class AdminProfilePage : ContentPage
{
    private IUnitOfWork _unitOfWork;

    public AdminProfilePage(User admin, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();

        adminInfoLabel.Text = $"Логин: {admin.Login}\n" +
                             $"Имя: {admin.Name}\n" +
                             $"Роль: {admin.Role}\n" +
                             $"Email: {admin.Email}";
    }
    private async void OnRedactBanksClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditBanksPage(_unitOfWork));
    }


    private async void OnUsersClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UsersListPage(_unitOfWork));
    }

    private async void OnTransactionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TransactionsListPage(_unitOfWork));
    }
    private async void OnRequestsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountRequestsListPage(_unitOfWork));
    }

    private async void OnTransfersClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new TransfersListPage(_unitOfWork));
    }

    private async void OnAccountsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountsListPage(_unitOfWork));
    }
}