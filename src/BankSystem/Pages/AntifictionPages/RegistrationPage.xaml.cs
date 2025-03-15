using System.Text.RegularExpressions;
using Domain.Dtos;
using Application.Interfaces.Handlers;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Models;
using Microsoft.Maui.Controls;

namespace BankSystem.Pages.AntifictionPages;

public partial class RegistrationPage : ContentPage
{
    private IUserHandler _userHandler;
    public RegistrationPage(IUserHandler userHandler)
    {
        _userHandler = userHandler;
        InitializeComponent();
        bankName.Text = $"Регистрация в систему";
        rolePicker.ItemsSource = Enum.GetNames(typeof(RoleType)).ToList();
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        string login = loginEntry.Text?.Trim();
        string name = nameEntry.Text?.Trim();
        string email = emailEntry.Text?.Trim();
        DateTime dateOfBirth = dateOfBirthPicker.Date;
        string passportSeries = passportSeriesEntry.Text?.Trim();
        string phoneNumber = phoneNumberEntry.Text?.Trim();
        string password = passwordEntry.Text;
        string confirmPassword = confirmPasswordEntry.Text;

        if (string.IsNullOrEmpty(login) ||
            string.IsNullOrEmpty(name) ||
            string.IsNullOrEmpty(passportSeries) ||
            string.IsNullOrEmpty(phoneNumber) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword))
        {
            ShowError("Пожалуйста, заполните все поля.");
            return;
        }

        var usernameRegex = new Regex(@"^[a-zA-Z0-9]{4,20}$");
        if (!usernameRegex.IsMatch(login))
        {
            ShowError("Логин должен содержать только латинские буквы и цифры (4–20 символов).");
            return;
        }

        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        if (!emailRegex.IsMatch(email))
        {
            ShowError("Неверный формат email.");
            return;
        }

        if (rolePicker.SelectedItem == null)
        {
            ShowError("Пожалуйста, выберете роль.");
        }
        RoleType roleType = (RoleType)Enum.Parse(typeof(RoleType), rolePicker.SelectedItem.ToString());

        var passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
        if (!passwordRegex.IsMatch(password))
        {
            ShowError("Пароль должен быть не менее 8 символов и содержать хотя бы одну букву и одну цифру.");
            return;
        }

        if (password != confirmPassword)
        {
            ShowError("Пароли не совпадают.");
            return;
        }

        var passwordHash = PasswordHasher.HashPassword(password);

        var user = new User(0,
            login,
            name,
            roleType,
            dateOfBirth,
            email,
            passportSeries,
            phoneNumber,
            passwordHash
        );

        _userHandler.CreateUserAsync(user, CancellationToken.None);

        statusLabel.TextColor = Colors.Green;
        statusLabel.Text = "Успешная регистрация!";
        Navigation.PopAsync();
    }

    private void ShowError(string message)
    {
        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = message;
    }
}

/*
    [PrimaryKey, AutoIncrement, Indexed, NotNull]
    public uint Id { get; set; }

    [NotNull]
    public string Login { get; set; }

    public string Name { get; set; }

    [NotNull]
    public string Role { get; set; }

    public DateTime DateOfBirth { get; set; }

    [NotNull]
    public string Email { get; set; }

    public string PassportSeries { get; set; }

    public string PhoneNumber { get; set; }

    [NotNull]
    public string PasswordHash { get; set; }
*/