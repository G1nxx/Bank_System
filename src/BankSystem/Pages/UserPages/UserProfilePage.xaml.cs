using Application.Interfaces;
using Domain.Abstractions;
using Domain.Entities;

namespace BankSystem.Pages.UserPages;

public partial class UserProfilePage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    private User _user;

    public UserProfilePage(User user, IUnitOfWork unitOfWork)
	{
        _unitOfWork = unitOfWork;
        _user = user;
		InitializeComponent();
        BindingContext = _user;
    }

    private async void OnActionsClicked(object sender, EventArgs e)
    {
        // Создание выпадающего меню
        string action = await DisplayActionSheet("Выберите действие", "Отмена", null, "Создать счет", "Перевести средства");

        if (action == "Создать счет")
        {
            await Navigation.PushAsync(new CreateAccountPage(_user, _unitOfWork));
        }
        else if (action == "Перевести средства")
        {
            await Navigation.PushAsync(new TransferPage(_user, _unitOfWork));
        }
    }
}