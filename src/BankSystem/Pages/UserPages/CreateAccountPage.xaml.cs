using Domain.Dtos;
using Infrastructure.Persistence.Handlers;
using Application.Interfaces;
using Application.Interfaces.Handlers;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System.Threading;

namespace BankSystem.Pages.UserPages;

public partial class CreateAccountPage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    private User _user;
    private List<Bank> bankList = new();

    public CreateAccountPage(User user, IUnitOfWork unitOfWork)
	{
        _unitOfWork = unitOfWork;
        _user = user;

        InitializeComponent();
        currencyPicker.ItemsSource = Enum.GetNames(typeof(CurrencyType));
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await UpdatePicker();
    }

    private async Task UpdatePicker()
    {
        try
        {
            bankList = (await _unitOfWork.GetBankHandler()
               .GetBanksInfoAsync(CancellationToken.None)).ToList();
            bankPicker.Items.Clear();
            foreach (var bank in bankList) {
                bankPicker.Items.Add(bank.LegalName);
            }
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Ошибка загрузки банков: {ex.Message}";
        }
    }

    private void OnCreateAccountClicked(object sender, EventArgs e)
    {
        string accountName = accountNameEntry.Text?.Trim()!;
        string currency = currencyPicker.SelectedItem?.ToString()!;
        string bankName = bankPicker.SelectedItem?.ToString()!;

        if (string.IsNullOrEmpty(accountName) ||
            string.IsNullOrEmpty(currency) ||
            string.IsNullOrEmpty(bankName))
        {
            statusLabel.Text = "Пожалуйста, заполните все поля.";
            return;
        }

        _unitOfWork.GetRCBAHandler().CreateRCBAAsync(
            new RCBA(accountName,
            (CurrencyType)Enum.Parse(typeof(CurrencyType), currency),
            _user.Id,
            bankList.Where(bank => bank.LegalName.Equals(bankName)).FirstOrDefault()!.Id),
            CancellationToken.None);

        DisplayAlert("Account", "Запрос на создание счета успешно отправлен", "Ок");
        Navigation.PopAsync();
    }
}