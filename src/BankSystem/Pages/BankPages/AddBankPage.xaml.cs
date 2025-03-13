using Application.Interfaces.Handlers;
using Application.Dtos;
using Domain.Entities;
using AutoMapper;
using System.Text.RegularExpressions;

namespace BankSystem.Pages.BankPages;

public partial class AddBankPage : ContentPage
{
    private IMapper _mapper;
    private IBankHandler _bankHandler;
    public AddBankPage(IBankHandler bankHandler, IMapper mapper)
    {
        _mapper = mapper;
        _bankHandler = bankHandler;
        InitializeComponent();
    }

    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        string type = typeEntry.Text?.Trim();
        string legalName = legalNameEntry.Text?.Trim();
        string legalAddress = legalAddressEntry.Text?.Trim();
        string trn = trnEntry.Text?.Trim();
        string bik = bikEntry.Text?.Trim();
        string creditIds = creditIdsEntry.Text?.Trim();
        string clientIds = clientIdsEntry.Text?.Trim();

        if (string.IsNullOrEmpty(type) ||
            string.IsNullOrEmpty(legalName) ||
            string.IsNullOrEmpty(legalAddress) ||
            string.IsNullOrEmpty(trn) ||
            string.IsNullOrEmpty(bik) ||
            string.IsNullOrEmpty(creditIds) ||
            string.IsNullOrEmpty(clientIds))
        {
            ShowError("����������, ��������� ��� ����.");
            return;
        }

        if (type != "NONE" &&
            type != "IP"   &&
            type != "OOO"  &&
            type != "OAO"  &&
            type != "DAO"  &&
            type != "ZAO")
        {
            ShowError("�������� ���");
            typeEntry.Text = "NONE";
            return;
        }

        var trnRegex = new Regex(@"^\d{9}$");
        if (!trnRegex.IsMatch(trn))
        {
            ShowError("TRN ������ �������� �� 9 ����.");
            trnEntry.Text = string.Empty;
            return;
        }

        var bikRegex = new Regex(@"^\d{9}$");
        if (!bikRegex.IsMatch(bik))
        {
            ShowError("BIK ������ �������� �� 9 ����.");
            bikEntry.Text = string.Empty;
            return;
        }

        if (!uint.TryParse(creditIds, out _))
        {
            ShowError("ID �������� ������ ���� ������������� ������.");
            creditIds = string.Empty;
            return;
        }

        if (!uint.TryParse(clientIds, out _))
        {
            ShowError("ID �������� ������ ���� ������������� ������.");
            clientIds = string.Empty;
            return;
        }

        var newBank = _mapper.Map<Bank>(new BankDto
        {
            Id = 0,
            Type = type,
            LegalName = legalName,
            LegalAddress = legalAddress,
            TRN = int.Parse(trn),
            BIK = int.Parse(bik),
            CreditIds = uint.Parse(creditIds),
            ClientIds = uint.Parse(clientIds)
        });

        await _bankHandler.CreateBankAsync(newBank, CancellationToken.None);

        await DisplayAlert("�����", $"���� '{legalNameEntry.Text}' ������!", "OK");
        await Navigation.PopAsync();
    }

    private void ShowError(string message)
    {
        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = message;
    }
}