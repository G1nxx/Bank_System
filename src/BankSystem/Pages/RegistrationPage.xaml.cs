using System.Text.RegularExpressions;
using Application.Dtos;
using Application.Interfaces.Handlers;
using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Models;
using Microsoft.Maui.Controls;

namespace BankSystem.Pages
{
    public partial class RegistrationPage : ContentPage
    {
        private IUserHandler _userHandler;
        public RegistrationPage(string selectedBank, IUserHandler userHandler)
        {
            _userHandler = userHandler;
            InitializeComponent();
            bankName.Text = $"Регистрация в банке: {selectedBank}";
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

            // Проверка на пустые обязательные поля
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                ShowError("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            // Валидация логина
            var usernameRegex = new Regex(@"^[a-zA-Z0-9]{4,20}$");
            if (!usernameRegex.IsMatch(login))
            {
                ShowError("Логин должен содержать только латинские буквы и цифры (4–20 символов).");
                return;
            }

            // Валидация email
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(email))
            {
                ShowError("Неверный формат email.");
                return;
            }

            // Валидация пароля
            var passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            if (!passwordRegex.IsMatch(password))
            {
                ShowError("Пароль должен быть не менее 8 символов и содержать хотя бы одну букву и одну цифру.");
                return;
            }

            // Проверка совпадения паролей
            if (password != confirmPassword)
            {
                ShowError("Пароли не совпадают.");
                return;
            }

            // Хэширование пароля
            var passwordHash = PasswordHasher.HashPassword(password);

            // Создание объекта пользователя
            var user = new User(0,
                login,
                name,
                "User",
                dateOfBirth,
                email,
                passportSeries,
                phoneNumber,
                passwordHash
            );

            // Сохранение пользователя в базу данных (заглушка)
            _userHandler.CreateUserAsync(user, CancellationToken.None);

            // Уведомление об успешной регистрации
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