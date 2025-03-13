using BankSystem.Pages;
using BankSystem.Pages.BankPages;
using Application.Interfaces;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.UnitOfWork;
using Domain.Entities;
using AutoMapper;

namespace BankSystem;

public partial class MainPage : ContentPage
{
    private IMapper _mapper;
    IUnitOfWork _unitOfWork;
    private List<string> bankList = new();
    public MainPage(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        InitializeComponent();
        
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        bankPicker.ItemsSource = null;

        base.OnNavigatedTo(args);

        await Task.Run(() => UpdatePicker(CancellationToken.None));
        bankPicker.ItemsSource = bankList;
    }

    private async Task UpdatePicker(CancellationToken cancellationToken)
    {
        try
        {
            var banks = _unitOfWork.GetBankHandler(cancellationToken).GetBanksInfoAsync(cancellationToken).Result.ToList();
            bankList.Clear();
            for (int i = 0; i < banks.Count(); ++i)
            {
                bankList.Add(banks[i].LegalName);
            }
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Ошибка загрузки банков: {ex.Message}";
        }
    }
    private async void OnRedactBanksClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditBanksPage(_unitOfWork.GetBankHandler(), _mapper));
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (bankPicker.SelectedIndex == -1)
        {
            statusLabel.Text = "Пожалуйста, выберите банк для регистрации.";
            return;
        }

        string selectedBank = bankPicker.SelectedItem.ToString();
        statusLabel.Text = "";

        await Navigation.PushAsync(new RegistrationPage(selectedBank, _unitOfWork.GetUserHandler()));
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

        await Navigation.PushAsync(new LoginPage(selectedBank));
    }
}
