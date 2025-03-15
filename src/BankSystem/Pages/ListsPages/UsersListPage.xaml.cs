using Application.Interfaces;

namespace BankSystem.Pages.ListsPages;

public partial class UsersListPage : ContentPage
{
	private IUnitOfWork _unitOfWork;

    public UsersListPage(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
		InitializeComponent();
		Task.Run(async () =>
		{
			var users = (await _unitOfWork.GetUserHandler().GetUsersAsync(CancellationToken.None)).ToList();
			usersCollectionView.ItemsSource = users;
			usersCollectionView.VerticalScrollBarVisibility = ScrollBarVisibility.Always;
		});
    }
}