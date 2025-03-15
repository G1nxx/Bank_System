using Application.Interfaces;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Entities.Transactions;
using Domain.Enums;
using Domain.Primitives;

namespace BankSystem.Pages.ListsPages;

public partial class AccountRequestDetailsPage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    private RCBA _request;
    private User _user;
    private Bank _bank;

    public AccountRequestDetailsPage(RCBA request, IUnitOfWork unitOfWork)
    {
        _request = request;
        _unitOfWork = unitOfWork;
        InitializeComponent();
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        Task.Run(async () =>
        {
            _user = await _unitOfWork.GetUserHandler()
                .GetUserByIdAsync(_request.UserId, CancellationToken.None);
            _bank = await _unitOfWork.GetBankHandler()
                .GetBankByIdAsync(_request.BankId, CancellationToken.None);
        }).Wait();

        requestAccountNameLabel.Text = $"Название счета: {_request.AccountName}";
        requestCurrencyLabel.Text = $"Валюта: {_request.Currency}";
        requestStatusLabel.Text = $"Статус: {_request.IsApproved}";
        requestCreatedAtLabel.Text = $"Дата создания: {_request.CreatedAt}";

        bankTypeLabel.Text = $"Тип банка: {_bank.Type}";
        bankLegalNameLabel.Text = $"Юридическое название: {_bank.LegalName}";
        bankLegalAddressLabel.Text = $"Юридический адрес: {_bank.LegalAddress}";
        bankTRNLabel.Text = $"TRN: {_bank.TRN}";
        bankBIKLabel.Text = $"BIK: {_bank.BIK}";

        userLoginLabel.Text = $"Логин: {_user.Login}";
        userNameLabel.Text = $"Имя: {_user.Name}";
        userRoleLabel.Text = $"Роль: {_user.Role}";
        userDateOfBirthLabel.Text = $"Дата рождения: {_user.DateOfBirth:dd/MM/yyyy}";
        userEmailLabel.Text = $"Email: {_user.Email}";
        userPassportSeriesLabel.Text = $"Серия паспорта: {_user.PassportSeries}";
        userPhoneNumberLabel.Text = $"Номер телефона: {_user.PhoneNumber}";
        if(_request.IsApproved != RStatusType.InProcess)
        {
            approveButton.IsVisible = false;
            rejectButton.IsVisible  = false;
        }
    }
    private async void OnRejectClicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Отклонить запрос", "Вы уверены, что хотите отклонить запрос?", "Да", "Нет");
        if (result)
        {
            _request.IsApproved = RStatusType.Denied;
            Task.Run(async () => await _unitOfWork.GetRCBAHandler().UpdateRCBA(_request, CancellationToken.None)).Wait();
            await _unitOfWork.GetTransactionHandler()
                .CreateTransactionAsync(new Transaction(TransactionType.BACreation, _request), CancellationToken.None);
            await DisplayAlert("Успех", "Запрос отклонен.", "OK"); 
            await Navigation.PopAsync();
        }
    }

    private async void OnApproveClicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Одобрить запрос", "Вы уверены, что хотите одобрить запрос?", "Да", "Нет");
        if (result)
        {
            _request.IsApproved = RStatusType.Approved;
            Task.Run(async () => await _unitOfWork.GetRCBAHandler().UpdateRCBA(_request, CancellationToken.None)).Wait();
            uint id = await _unitOfWork.GetBAHandler().CreateBAAsync(new BankAccount(_request), CancellationToken.None);
            Entity entity = await _unitOfWork.GetBAHandler().GetBAByIdAsync(id, CancellationToken.None);
            await _unitOfWork.GetTransactionHandler()
                .CreateTransactionAsync(new Transaction(TransactionType.BACreation, entity), CancellationToken.None);
            await DisplayAlert("Успех", "Запрос одобрен.", "OK");
            await Navigation.PopAsync();
        }
    }
}