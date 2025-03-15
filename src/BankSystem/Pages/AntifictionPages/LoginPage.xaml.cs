using System.Text.RegularExpressions;
using Application.Interfaces;
using Application.Interfaces.Handlers;
using AutoMapper;
using BankSystem.Pages.AdminPages;
using BankSystem.Pages.ManagerPages;
using BankSystem.Pages.UserPages;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Models;
using Microsoft.Maui.Controls;

namespace BankSystem.Pages.AntifictionPages;

public partial class LoginPage : ContentPage
{
    private IUnitOfWork _unitOfWork;
    public LoginPage(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        EnterencyLabel.Text = "Вход в Систему";
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowError("Пожалуйста, заполните все поля.");
            return;
        }

        var usernameRegex = new Regex(@"^[a-zA-Z0-9]{4,20}$");
        if (!usernameRegex.IsMatch(username))
        {
            ShowError("Логин должен содержать только латинские буквы и цифры (4–20 символов).");
            return;
        }

        var passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
        if (!passwordRegex.IsMatch(password))
        {
            ShowError("Пароль должен быть не менее 8 символов и содержать хотя бы одну букву и одну цифру.");
            return;
        }
        if (await _unitOfWork.GetUserHandler().GetUserByLoginAsync(username, CancellationToken.None) == null)
        {
            ShowError("Пользователь с таким именем не зарегистрирован.");
            return;
        }
        if (await AuthenticateUser(username, password))
        {
            var user = await _unitOfWork.GetUserHandler().GetUserByLoginAsync(username, CancellationToken.None);
            switch (user.Role)
            {
                case RoleType.USER:
                    await DisplayAlert("USER", "Вы вошли в систему как пользователь.", "OK");
                    await Navigation.PushAsync(new UserProfilePage(user, _unitOfWork));
                    break;
                case RoleType.MANAGER:
                    await DisplayAlert("MANAGER", "Вы вошли в систему как менеджер.", "OK");
                    await Navigation.PushAsync(new ManagerProfilePage(user, _unitOfWork));
                    break;
                case RoleType.ADMIN:
                    await DisplayAlert("ADMIN", "Вы вошли в систему как администратор.", "OK");
                    await Navigation.PushAsync(new AdminProfilePage(user, _unitOfWork));
                    break;
            }
            statusLabel.Text = "";
        }
        else
        {
            ShowError("Неверный логин или пароль.");
        }

        usernameEntry.Text = "";
        passwordEntry.Text = "";
    }

    private async Task<bool> AuthenticateUser(string username, string password)
    {
        var user = await _unitOfWork.GetUserHandler().GetUserByLoginAsync(username, CancellationToken.None);
        if (PasswordHasher.HashPassword(password) == user.PasswordHash)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ShowError(string message)
    {
        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = message;
    }
}