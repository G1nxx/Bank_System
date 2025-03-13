using BankSystem.Pages;
using Application.Interfaces;
using Infrastructure.Presistence.Context;
using Infrastructure.Presistence.UnitOfWork;

namespace BankSystem;

public partial class MainPage : ContentPage
{
    IUnitOfWork _unitOfWork;
    public MainPage(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        Task.Run(UpdatePicker).Wait();
    }

    private async Task UpdatePicker()
    {
        try
        {
            var banks = await _unitOfWork.GetAllBanksAsync();
            bankPicker.Items.Clear();
            foreach (var bank in banks)
            {
                bankPicker.Items.Add(bank.LegalName);
            }
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Ошибка загрузки банков: {ex.Message}";
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (bankPicker.SelectedIndex == -1)
        {
            statusLabel.Text = "Пожалуйста, выберите банк для регистрации.";
            return;
        }

        string selectedBank = bankPicker.SelectedItem.ToString();
        statusLabel.Text = ""; // очищаем статус

        // Здесь может быть переход на страницу регистрации, передаём выбранный банк
        await Navigation.PushAsync(new RegistrationPage(selectedBank));
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (bankPicker.SelectedIndex == -1)
        {
            statusLabel.Text = "Пожалуйста, выберите банк для входа.";
            return;
        }

        string selectedBank = bankPicker.SelectedItem.ToString();
        statusLabel.Text = "";

        // Здесь переход на страницу входа
        //await Navigation.PushAsync(new LoginPage(selectedBank));
    }
}
