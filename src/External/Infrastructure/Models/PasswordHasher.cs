using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Models;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        // Создаем объект SHA-256
        using (SHA256 sha256 = SHA256.Create())
        {
            // Преобразуем пароль в массив байтов
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Вычисляем хэш
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // Преобразуем хэш в строку HEX
            StringBuilder hashString = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hashString.Append(b.ToString("x2")); // "x2" означает шестнадцатеричный формат с двумя символами
            }

            return hashString.ToString();
        }
    }
}