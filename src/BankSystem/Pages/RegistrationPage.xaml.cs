using System.Text.RegularExpressions;

namespace BankSystem.Pages;
public partial class RegistrationPage : ContentPage // Fluent Validator - Посмотреть
{
    public RegistrationPage(string selectedBank)
    {
        InitializeComponent();
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text?.Trim();
        string email = emailEntry.Text?.Trim();
        string password = passwordEntry.Text;
        string confirmPassword = confirmPasswordEntry.Text;

        if (string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword))
        {
            ShowError("Пожалуйста, заполните все поля.");
            return;
        }

        var usernameRegex = new Regex(@"^[a-zA-Z0-9]{4,20}$");
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        var passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

        if (!usernameRegex.IsMatch(username))
        {
            ShowError("Логин должен содержать только латинские буквы и цифры (4–20 символов).");
            return;
        }

        if (!emailRegex.IsMatch(email))
        {
            ShowError("Неверный формат email.");
            return;
        }

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

        statusLabel.TextColor = Colors.Green;
        statusLabel.Text = "Успешная регистрация!";
    }

    private void ShowError(string message)
    {
        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = message;
    }
}