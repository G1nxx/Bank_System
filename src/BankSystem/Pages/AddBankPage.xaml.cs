using Application.Interfaces.Handlers;
using Domain.Entities;
using Domain.Enums;

namespace BankSystem.Pages;

public partial class AddBankPage : ContentPage
{
    private IBankHandler _bankHandler;
    public AddBankPage(IBankHandler bankHandler)
    {
        _bankHandler = bankHandler;
        InitializeComponent();
    }

    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        var newBank = new Bank(0, 
            CompanyType.None, 
            legalNameEntry.Text, 
            legalAddressEntry.Text, 
            int.Parse(trnEntry.Text),
            int.Parse(bikEntry.Text),
            uint.Parse(creditIdsEntry.Text),
            uint.Parse(clientIdsEntry.Text)
        );

        await _bankHandler.CreateBankAsync(newBank, CancellationToken.None);

        await DisplayAlert("Успех", $"Банк '{legalNameEntry.Text}' создан!", "OK");
        //await Shell.Current.GoToAsync("..");
        await Navigation.PopAsync();
        //if (Navigation.NavigationStack.FirstOrDefault() is EditBanksPage editBanksPage)
        //{
        //    await editBanksPage.UpdateBanks();
        //}
    }
}