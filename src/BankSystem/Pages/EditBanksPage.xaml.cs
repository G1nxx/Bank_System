using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Handlers;
using Domain.Entities;
using Domain.Enums;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BankSystem.Pages;

public partial class EditBanksPage : ContentPage
{
    public ObservableCollection<Bank> Banks { get; set; } = new ObservableCollection<Bank>();
    private IBankHandler _bankHandler { get; }

    public EditBanksPage(IBankHandler bankHandler)
    {
        _bankHandler = bankHandler;

        InitializeComponent();
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await Task.Run(() => UpdateBanks());

        banksCollectionView.ItemsSource = null;
        banksCollectionView.ItemsSource = Banks;
        
    }

    public async Task UpdateBanks()
    {
        Banks.Clear();
        var banks = _bankHandler.GetBanksInfoAsync(CancellationToken.None).Result.ToList();
        for (int i = 0; i < banks.Count(); i++)
        {

            Banks.Add(banks[i]);
        }
    }

    private async void OnBankSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Bank selectedBank)
        {
            await Navigation.PushAsync(new BankDetailsPage(selectedBank));
        }

        banksCollectionView.SelectedItem = null;
    }

    private async void OnAddBankClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddBankPage(_bankHandler));
    }
}