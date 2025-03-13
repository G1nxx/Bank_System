using Application.Dtos;
using Application.Interfaces.Handlers;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System.Formats.Tar;
using System.Text.RegularExpressions;

namespace BankSystem.Pages.BankPages;

public partial class RedactInfoBankPage : ContentPage
{
    private Bank _bank;
    private IMapper _mapper;
    private IBankHandler _bankHandler;
    public RedactInfoBankPage(Bank bank, IBankHandler bankHandler, IMapper mapper)
    {
        _bank = bank;
        _mapper = mapper;
        _bankHandler = bankHandler;

        InitializeComponent();

        typeEntry.Placeholder += _bank.Type;
        legalNameEntry.Placeholder += _bank.LegalName;
        legalAddressEntry.Placeholder += _bank.LegalAddress;
        trnEntry.Placeholder += _bank.TRN;
        bikEntry.Placeholder += _bank.BIK;
        creditIdsEntry.Placeholder += _bank.CreditIds;
        clientIdsEntry.Placeholder += _bank.ClientIds;
    }

    private async void OnUpdateButtonClicked(object sender, EventArgs e)
    {

        string type = typeEntry.Text?.Trim();
        string legalName = legalNameEntry.Text?.Trim();
        string legalAddress = legalAddressEntry.Text?.Trim();
        string trn = trnEntry.Text?.Trim();
        string bik = bikEntry.Text?.Trim();
        string creditIds = creditIdsEntry.Text?.Trim();
        string clientIds = clientIdsEntry.Text?.Trim();


        if (type != "NONE" &&
            type != "IP" &&
            type != "OOO" &&
            type != "OAO" &&
            type != "DAO" &&
            type != "ZAO")
        {
            ShowError("Неверный тип");
            typeEntry.Text = "NONE";
            return;
        }

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

        if (!string.IsNullOrEmpty(creditIds) && !uint.TryParse(creditIds, out _))
        {
            ShowError("ID кредитов должно быть положительным числом.");
            return;
        }

        if (!string.IsNullOrEmpty(clientIds) && !uint.TryParse(clientIds, out _))
        {
            ShowError("ID клиентов должно быть положительным числом.");
            return;
        }


        if (!string.IsNullOrEmpty(type))
        {
            _bank.Type = type == "ZAO" ? CompanyType.ZAO :
                         type == "IP" ? CompanyType.IP :
                         type == "OOO" ? CompanyType.OOO :
                         type == "OAO" ? CompanyType.OAO :
                         type == "ODO" ? CompanyType.ODO : CompanyType.None;
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
        if (!string.IsNullOrEmpty(creditIds))
        {
            _bank.CreditIds = uint.Parse(creditIds);
        }
        if (!string.IsNullOrEmpty(clientIds))
        {
            _bank.ClientIds = uint.Parse(clientIds);
        }


        await _bankHandler.UpdateBank(_bank, CancellationToken.None);

        await DisplayAlert("Успех", $"Банк '{legalNameEntry.Text}' обновлен!", "OK");
        await Navigation.PopAsync();
    }

    private void ShowError(string message)
    {
        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = message;
    }
}