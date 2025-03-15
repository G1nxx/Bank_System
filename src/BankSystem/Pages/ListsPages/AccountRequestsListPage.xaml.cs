using Application.Interfaces;
using Domain.Entities;

namespace BankSystem.Pages.ListsPages;

public partial class AccountRequestsListPage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    private List<RCBA> _rcbas;

    public AccountRequestsListPage(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        Task.Run(async () =>
        {
            _rcbas = (await _unitOfWork.GetRCBAHandler().GetRCBAsAsync(CancellationToken.None)).ToList();
        });
        requestsCollectionView.ItemsSource = _rcbas;
        requestsCollectionView.VerticalScrollBarVisibility = ScrollBarVisibility.Always;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        requestsCollectionView.ItemsSource = null;
        base.OnNavigatedTo(args);
        Task.Run(async () =>
        {
            _rcbas = (await _unitOfWork.GetRCBAHandler().GetRCBAsAsync(CancellationToken.None)).ToList();
        }).Wait();
        requestsCollectionView.ItemsSource = _rcbas;
    }
    private async void OnDetailsClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var request = button?.BindingContext as RCBA;

        if (request != null)
        {
            await Navigation.PushAsync(new AccountRequestDetailsPage(request, _unitOfWork));
        }
    }
}