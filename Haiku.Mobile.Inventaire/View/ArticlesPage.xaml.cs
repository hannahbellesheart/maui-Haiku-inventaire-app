namespace Haiku.Mobile.Inventaire.View;

public partial class ArticlesPage : ContentPage
{
    public ArticlesPage(ArticlesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void Add_Article_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//BarcodeScanPage");
    }
}