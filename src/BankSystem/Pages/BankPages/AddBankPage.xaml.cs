using Application.Interfaces.Handlers;
using Domain.Dtos.BankDtos;
using Domain.Entities;
using AutoMapper;
using System.Text.RegularExpressions;
using Domain.Enums;
using Application.Interfaces;

namespace BankSystem.Pages.BankPages;

public partial class AddBankPage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    public AddBankPage(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        typePicker.ItemsSource = Enum.GetNames(typeof(CompanyType));
    }

    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        string legalName = legalNameEntry.Text?.Trim();
        string legalAddress = legalAddressEntry.Text?.Trim();
        string trn = trnEntry.Text?.Trim();
        string bik = bikEntry.Text?.Trim();

        if (string.IsNullOrEmpty(legalName) ||
            string.IsNullOrEmpty(legalAddress) ||
            string.IsNullOrEmpty(trn) ||
            string.IsNullOrEmpty(bik))
        {
            ShowError("����������, ��������� ��� ����.");
            return;
        }


        if (typePicker.SelectedItem == null)
        {
            ShowError("�������� ���");
            return;
        }
        CompanyType type = (CompanyType)Enum.Parse(typeof(CompanyType), typePicker.SelectedItem.ToString());

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

        var newBank = _unitOfWork.GetMapper().Map<Bank>(new BankDto
        {
            Id = 0,
            Type = Enum.GetName(typeof(CompanyType), type),
            LegalName = legalName,
            LegalAddress = legalAddress,
            TRN = int.Parse(trn),
            BIK = int.Parse(bik)
        });

        await _unitOfWork.GetBankHandler()
            .CreateBankAsync(newBank, CancellationToken.None);

        await DisplayAlert("�����", $"���� '{legalNameEntry.Text}' ������!", "OK");
        await Navigation.PopAsync();
    }

    private void ShowError(string message)
    {
        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = message;
    }
}