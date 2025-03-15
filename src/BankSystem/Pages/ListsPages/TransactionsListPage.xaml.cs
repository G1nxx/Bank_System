using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Transactions;
using Domain.Enums;
using System.Text.RegularExpressions;

namespace BankSystem.Pages.ListsPages;

public partial class TransactionsListPage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    private List<Transaction> _transactions = new();
	public TransactionsListPage(IUnitOfWork unitOfWork)
	{
        _unitOfWork = unitOfWork;
		InitializeComponent();
        Task.Run(async () =>
        {
            _transactions = (await _unitOfWork.GetTransactionHandler()
                    .GetTransactionsAsync(CancellationToken.None)).ToList();
        });
        transactionsCollectionView.ItemsSource = _transactions;
        transactionsCollectionView.VerticalScrollBarVisibility = ScrollBarVisibility.Always;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        transactionsCollectionView.ItemsSource = null;
        base.OnNavigatedTo(args);
        Task.Run(async () =>
            {
                _transactions = (await _unitOfWork.GetTransactionHandler()
                    .GetTransactionsAsync(CancellationToken.None)).ToList();
            }).Wait();
        transactionsCollectionView.ItemsSource = _transactions;

    }
    private void OnCancelClicked(object sender, System.EventArgs e)
    {
        var button = sender as Button;
        var transaction = button.BindingContext as Transaction;
        if (transaction.Type == TransactionType.Transfer)
        {
            var trans = ParseTransfer(transaction.Information);

            if (trans.IsCancelled == false)
            {
                Task.Run(async () =>
                {
                    MakeTransfer(await _unitOfWork.GetBAHandler()
                                    .GetBAByIdAsync(trans.ReceiverBankAccountId, CancellationToken.None),
                                 await _unitOfWork.GetBAHandler()
                                    .GetBAByIdAsync(trans.RecipientBankAccountId, CancellationToken.None),
                                 trans.Amount);
                });
                trans.IsCancelled = true;
                _unitOfWork.GetTransferHandler().UpdateTransfer(trans, CancellationToken.None);
            }
        }
    }

    public Transfer ParseTransfer(string input)
    {
        var recipientRegex = new Regex(@"Счет отправителя: (([0-9]){8}-([0-9]){4})");
        var receiverRegex = new Regex(@"Счет получателя: (([0-9]){8}-([0-9]){4})");
        var amountRegex = new Regex(@"Сумма в рублях: ((-?)([0-9]+)\,([0-9]*))");

        string recipientId = recipientRegex.Match(input).Groups[1].Value;
        string receiverId = receiverRegex.Match(input).Groups[1].Value;
        decimal amount = decimal.Parse(amountRegex.Match(input).Groups[1].Value);

        return Task.Run(async () =>
        {
            return new Transfer((await _unitOfWork.GetBAHandler().GetBAByAccountNumberAsync(receiverId, CancellationToken.None)).Id,
                        (await _unitOfWork.GetBAHandler().GetBAByAccountNumberAsync(recipientId, CancellationToken.None)).Id,
                        amount);
        }).Result;
        
    }

    private void MakeTransfer(BankAccount from, BankAccount to, decimal amount)
    {
        switch (from.Currency)
        {
            case CurrencyType.USD:
                amount /= (decimal)3.22;
                break;
            case CurrencyType.EUR:
                amount /= (decimal)3.41;
                break;
        }
        to.Balance -= amount;
        var am = amount;
        switch (from.Currency)
        {
            case CurrencyType.USD:
                amount *= (decimal)3.22;
                break;
            case CurrencyType.EUR:
                amount *= (decimal)3.41;
                break;
        }
        switch (to.Currency)
        {
            case CurrencyType.USD:
                amount /= (decimal)3.22;
                break;
            case CurrencyType.EUR:
                amount /= (decimal)3.41;
                break;
        }
        from.Balance += amount;

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
