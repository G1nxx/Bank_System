using BankSystem.Pages;

namespace BankSystem
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EditBanksPage), typeof(EditBanksPage));
        }
    }
}
