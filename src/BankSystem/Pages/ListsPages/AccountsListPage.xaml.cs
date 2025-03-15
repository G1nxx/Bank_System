using Application.Interfaces;
using Domain.Entities;

namespace BankSystem.Pages.ListsPages;

public partial class AccountsListPage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    private List<BankAccount> _accounts = new();

    public AccountsListPage(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        Task.Run(async () =>
        {
            _accounts = (await _unitOfWork.GetBAHandler()
                    .GetBAsAsync(CancellationToken.None)).ToList();
        });

        accountsCollectionView.ItemsSource = _accounts;
        accountsCollectionView.VerticalScrollBarVisibility = ScrollBarVisibility.Always;

    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        accountsCollectionView.ItemsSource = null;
        base.OnNavigatedTo(args);
        Task.Run(async () =>
        {
            _accounts = (await _unitOfWork.GetBAHandler()
                    .GetBAsAsync(CancellationToken.None)).ToList();
        }).Wait();
        accountsCollectionView.ItemsSource = _accounts;
    }
}

