using Domain.Dtos;
using Application.Interfaces.Handlers;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System.Formats.Tar;
using System.Text.RegularExpressions;
using Application.Interfaces;

namespace BankSystem.Pages.BankPages;

public partial class RedactInfoBankPage : ContentPage
{
    private Bank _bank;
    private IUnitOfWork _unitOfWork;
    public RedactInfoBankPage(Bank bank, IUnitOfWork unitOfWork)
    {
        _bank = bank;
        _unitOfWork = unitOfWork;

        InitializeComponent();
        typePicker.ItemsSource = Enum.GetNames(typeof(CompanyType));

        typePicker.SelectedItem = Enum.GetName(typeof(CompanyType), _bank.Type);
        legalNameEntry.Placeholder += _bank.LegalName;
        legalAddressEntry.Placeholder += _bank.LegalAddress;
        trnEntry.Placeholder += _bank.TRN;
        bikEntry.Placeholder += _bank.BIK;
    }

    private async void OnUpdateButtonClicked(object sender, EventArgs e)
    {

        string legalName = legalNameEntry.Text?.Trim();
        string legalAddress = legalAddressEntry.Text?.Trim();
        string trn = trnEntry.Text?.Trim();
        string bik = bikEntry.Text?.Trim();


        if (typePicker.SelectedItem == null)
        {
            ShowError("Выберете тип");
            return;
        }
        CompanyType type = (CompanyType)Enum.Parse(typeof(CompanyType), typePicker.SelectedItem.ToString());

        var trnRegex = new Regex(@"^\d{9}$");
        if (!string.IsNullOrEmpty(trn) && !trnRegex.IsMatch(trn))
        {
            ShowError("TRN должен состоять из 9 цифр.");
            return;
        }

        var bikRegex = new Regex(@"^\d{9}$");
        if (!string.IsNullOrEmpty(bik) && !bikRegex.IsMatch(bik))
        {
            ShowError("BIK должен состоять из 9 цифр.");
            return;
        }
        if (!string.IsNullOrEmpty(legalName))
        {
            _bank.LegalName = legalName;
        }
        if (!string.IsNullOrEmpty(legalAddress))
        {
            _bank.LegalAddress = legalAddress;
        }
        if (!string.IsNullOrEmpty(trn))
        {
            _bank.TRN = int.Parse(trn);
        }
        if (!string.IsNullOrEmpty(bik))
        {
            _bank.BIK = int.Parse(bik);
        }
        _bank.Type = type;

        await _unitOfWork.GetBankHandler()
            .UpdateBank(_bank, CancellationToken.None);

        await DisplayAlert("Успех", $"Банк '{legalNameEntry.Text}' обновлен!", "OK");
        await Navigation.PopAsync();
    }

    private void ShowError(string message)
    {
        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = message;
    }
}