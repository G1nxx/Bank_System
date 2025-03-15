using BankSystem.Pages.AntifictionPages;
using BankSystem.Pages.BankPages;
using Application.Interfaces;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.UnitOfWork;
using Domain.Entities;
using AutoMapper;
using Infrastructure.Models;

namespace BankSystem;

public partial class MainPage : ContentPage
{
    IUnitOfWork _unitOfWork;
    public MainPage(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrationPage(_unitOfWork.GetUserHandler())) ;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        statusLabel.Text = "";

        await Navigation.PushAsync(new LoginPage(_unitOfWork));
    }
}