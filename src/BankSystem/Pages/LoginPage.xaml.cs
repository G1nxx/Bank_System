using System.Text.RegularExpressions;
using Application.Interfaces.Handlers;
using AutoMapper;
using Microsoft.Maui.Controls;

namespace BankSystem.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(string selectedBank)
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text?.Trim();
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

            if (AuthenticateUser(username, password))
            {
                statusLabel.TextColor = Colors.Green;
                statusLabel.Text = "Успешный вход!";
                // Переход на другую страницу (например, главную)
                // await Navigation.PushAsync(new MainPage());
            }
            else
            {
                ShowError("Неверный логин или пароль.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Заглушка для проверки логина и пароля
            // В реальном приложении здесь будет запрос к базе данных или API
            return username == "testuser" && password == "Password123";
        }

        private void ShowError(string message)
        {
            statusLabel.TextColor = Colors.Red;
            statusLabel.Text = message;
        }
    }
}