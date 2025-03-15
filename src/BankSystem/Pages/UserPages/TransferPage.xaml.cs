using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Entities.Transactions;

namespace BankSystem.Pages.UserPages;

public partial class TransferPage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    private User _user;
    public TransferPage(User user, IUnitOfWork unitOfWork)
    {
        _user = user;
        _unitOfWork = unitOfWork;
        InitializeComponent();
    }
    private void OnTransferClicked(object sender, EventArgs e)
    {
        string fromAccount = fromAccountEntry.Text?.Trim();
        string toAccount = toAccountEntry.Text?.Trim();
        string amount = amountEntry.Text?.Trim();

        if (string.IsNullOrEmpty(fromAccount) || string.IsNullOrEmpty(toAccount) || string.IsNullOrEmpty(amount))
        {
            statusLabel.Text = "Пожалуйста, заполните все поля.";
            return;
        }

        if (!decimal.TryParse(amount, out decimal amountValue))
        {
            statusLabel.Text = "Некорректная сумма.";
            return;
        }
        var BAHandler = _unitOfWork.GetBAHandler();
        BankAccount? fromAcc = null, 
                     toAcc = null;
        Task.Run(async () =>
        {
            fromAcc = await BAHandler.GetBAByAccountNumberAsync(fromAccount, CancellationToken.None);
            toAcc = await  BAHandler.GetBAByAccountNumberAsync(toAccount, CancellationToken.None);
        }).Wait();
        if (fromAcc == null || toAcc == null)
        {
            statusLabel.Text = "Неверные номера договоров.";
            return;
        }
        List<BankAccount> userAccs = new();
        Task.Run(async () => userAccs = (await BAHandler.GetBAsByUserIdAsync(_user.Id, CancellationToken.None)).ToList()).Wait();
        foreach (var user in userAccs) 
        {
            if (user.AccountNumber == fromAccount)
            {
                MakeTransfer(fromAcc, toAcc, amountValue);

                DisplayAlert("Успех", "Перевод выполнен успешно!", "Ок");
                return;
            }
        }
        statusLabel.Text = "Договор не принадлежит пользователю";

        
    }
    private void MakeTransfer(BankAccount from, BankAccount to, decimal amount)
    {
        from.Balance -= amount;
        switch (from.Currency)
        {
            case CurrencyType.USD:
                amount *= (decimal)3.22;
                break;
            case CurrencyType.EUR:
                amount *= (decimal)3.41;
                break;
        }
        var am = amount;
        switch (to.Currency)
        {
            case CurrencyType.USD:
                amount /= (decimal)3.22;
                break;
            case CurrencyType.EUR:
                amount /= (decimal)3.41;
                break;
        }
        to.Balance += amount;

        Task.Run(async () => {
            await _unitOfWork.GetBAHandler().UpdateBA(from, CancellationToken.None);
            await _unitOfWork.GetBAHandler().UpdateBA(to, CancellationToken.None);

            var transId = await _unitOfWork.GetTransferHandler()
                .CreateTransferAsync(
                    new Transfer(from.Id, to.Id, am), CancellationToken.None);
            var trans = await _unitOfWork.GetTransferHandler().GetTransferByIdAsync(transId, CancellationToken.None);
            await _unitOfWork.GetTransactionHandler()
                .CreateTransactionAsync(
                    new Transaction(TransactionType.Transfer, trans, from, to),
                    CancellationToken.None);
        });
    }
}