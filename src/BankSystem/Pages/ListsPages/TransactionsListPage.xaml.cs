using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Transactions;

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
}
