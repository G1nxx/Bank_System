using Application.Interfaces.Handlers;
using Domain.Entities;

namespace BankSystem.Pages;

public partial class BankDetailsPage : ContentPage
{
    public BankDetailsPage(Bank bank)
	{
		InitializeComponent();
        BindingContext = bank;
    }
}