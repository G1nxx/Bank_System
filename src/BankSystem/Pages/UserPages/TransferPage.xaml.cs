namespace BankSystem.Pages.UserPages;

public partial class TransferPage : ContentPage
{
	public TransferPage()
	{
		InitializeComponent();
	}
    private void OnTransferClicked(object sender, EventArgs e)
    {
        string fromAccount = fromAccountEntry.Text?.Trim();
        string toAccount = toAccountEntry.Text?.Trim();
        string amount = amountEntry.Text?.Trim();

        if (string.IsNullOrEmpty(fromAccount) || string.IsNullOrEmpty(toAccount) || string.IsNullOrEmpty(amount))
        {
            statusLabel.Text = "����������, ��������� ��� ����.";
            return;
        }

        if (!decimal.TryParse(amount, out decimal amountValue))
        {
            statusLabel.Text = "������������ �����.";
            return;
        }

        // ������ �������� ������� (��������)
        statusLabel.TextColor = Colors.Green;
        statusLabel.Text = "������� �������� �������!";
    }
}