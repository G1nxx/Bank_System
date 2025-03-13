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
                ShowError("����������, ��������� ��� ����.");
                return;
            }

            var usernameRegex = new Regex(@"^[a-zA-Z0-9]{4,20}$");
            if (!usernameRegex.IsMatch(username))
            {
                ShowError("����� ������ ��������� ������ ��������� ����� � ����� (4�20 ��������).");
                return;
            }

            var passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            if (!passwordRegex.IsMatch(password))
            {
                ShowError("������ ������ ���� �� ����� 8 �������� � ��������� ���� �� ���� ����� � ���� �����.");
                return;
            }

            if (AuthenticateUser(username, password))
            {
                statusLabel.TextColor = Colors.Green;
                statusLabel.Text = "�������� ����!";
                // ������� �� ������ �������� (��������, �������)
                // await Navigation.PushAsync(new MainPage());
            }
            else
            {
                ShowError("�������� ����� ��� ������.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // �������� ��� �������� ������ � ������
            // � �������� ���������� ����� ����� ������ � ���� ������ ��� API
            return username == "testuser" && password == "Password123";
        }

        private void ShowError(string message)
        {
            statusLabel.TextColor = Colors.Red;
            statusLabel.Text = message;
        }
    }
}