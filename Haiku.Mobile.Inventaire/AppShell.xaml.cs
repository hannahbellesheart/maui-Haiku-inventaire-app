namespace Haiku.Mobile.Inventaire
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(PopupPage), typeof(PopupPage));

            Routing.RegisterRoute(nameof(ArticlesPage), typeof(ArticlesPage));
            Routing.RegisterRoute(nameof(BarcodeScanPage), typeof(BarcodeScanPage));
            Routing.RegisterRoute(nameof(AddArticlePage), typeof(AddArticlePage));

        }
    }
}