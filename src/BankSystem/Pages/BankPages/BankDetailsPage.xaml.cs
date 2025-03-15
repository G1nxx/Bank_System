using Application.Interfaces;
using Application.Interfaces.Handlers;
using AutoMapper;
using Domain.Entities;

namespace BankSystem.Pages.BankPages;

public partial class BankDetailsPage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    private Bank _bank;

    public BankDetailsPage(Bank bank, IUnitOfWork unitOfWork)
	{
        _unitOfWork = unitOfWork;
		InitializeComponent();
        BindingContext = _bank = bank;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        BindingContext = null;
        base.OnNavigatedTo(args);

        _bank = await _unitOfWork.GetBankHandler()
            .GetBankByIdAsync(_bank.Id, CancellationToken.None);
        BindingContext = _bank;
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RedactInfoBankPage(_bank , _unitOfWork));
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        await _unitOfWork.GetBankHandler()
            .DeleteBank(_bank, CancellationToken.None);
        await DisplayAlert("Удаление", "Удаление информации", "OK");
        await Navigation.PopAsync();
    }
}