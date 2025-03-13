using Application.Interfaces.Handlers;
using AutoMapper;
using Domain.Entities;

namespace BankSystem.Pages.BankPages;

public partial class BankDetailsPage : ContentPage
{
    private IMapper _mapper;
    private IBankHandler _bankHandler;
    private Bank _bank;

    public BankDetailsPage(Bank bank, IBankHandler bankHandler, IMapper mapper)
	{
        _mapper = mapper;
        _bankHandler = bankHandler;
		InitializeComponent();
        BindingContext = _bank = bank;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        BindingContext = null;
        base.OnNavigatedTo(args);

        _bank = await _bankHandler.GetBankByIdAsync(_bank.Id, CancellationToken.None);
        BindingContext = _bank;
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RedactInfoBankPage(_bank , _bankHandler, _mapper));
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        await _bankHandler.DeleteBank(_bank, CancellationToken.None);
        await DisplayAlert("Удаление", "Удаление информации", "OK");
        await Navigation.PopAsync();
    }
}