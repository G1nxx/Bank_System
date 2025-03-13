using System.Text.RegularExpressions;

namespace BankSystem.Pages;
public partial class RegistrationPage : ContentPage // Fluent Validator - ����������
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
            ShowError("����������, ��������� ��� ����.");
            return;
        }

        var usernameRegex = new Regex(@"^[a-zA-Z0-9]{4,20}$");
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        var passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

        if (!usernameRegex.IsMatch(username))
        {
            ShowError("����� ������ ��������� ������ ��������� ����� � ����� (4�20 ��������).");
            return;
        }

        if (!emailRegex.IsMatch(email))
        {
            ShowError("�������� ������ email.");
            return;
        }

        if (!passwordRegex.IsMatch(password))
        {
            ShowError("������ ������ ���� �� ����� 8 �������� � ��������� ���� �� ���� ����� � ���� �����.");
            return;
        }

        if (password != confirmPassword)
        {
            ShowError("������ �� ���������.");
            return;
        }

        statusLabel.TextColor = Colors.Green;
        statusLabel.Text = "�������� �����������!";
    }

    private void ShowError(string message)
    {
        statusLabel.TextColor = Colors.Red;
        statusLabel.Text = message;
    }
}