namespace Haiku.Mobile.Inventaire.View;

[QueryProperty(nameof(barcodeString), "barcodeString")]
public partial class AddArticlePage : ContentPage
{
    ArticlesViewModel vm;
    public AddArticlePage(ArticlesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        vm = viewModel;
    }
    public string barcodeString { get; set; }

    string articleData;
    private void btn_AddArticle_Clicked(object sender, EventArgs e)
    {
        articleData = articleName.Text + "_" + barcodeString;
        vm.AddArticleCommand.Execute(articleData);
        Application.Current!.MainPage = new AppShell();
    }
}