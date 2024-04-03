namespace Haiku.Mobile.Inventaire.View;

[QueryProperty(nameof(QrCodeString), "qrCodeString")]
public partial class PopupPage : ContentPage
{
    readonly ArticlesService ArticlesService;
    public string QrCodeString { get; set; }

    public PopupPage(ArticlesService articlesService)
    {
        this.ArticlesService = articlesService;
        InitializeComponent();
    }

    private async void OnloginClicked(object sender, EventArgs e)
    {
        //Authenticate user using api and go to the articles pages
        
        var auth = await ArticlesService.Login(QrCodeString, password.Text);
        if (auth)
        {
            await DisplayAlert("Success", "You have been authenticated successfully.", "OK");
            await Shell.Current.GoToAsync("//ArticlesPage");
        }
        else
        {
            await DisplayAlert("Failed", "Wrong Password, please try again.", "OK");
            await Shell.Current.GoToAsync("//ArticlesPage");
        }

    }
    private async void OnImageButtonClicked(object sender, EventArgs e)
    {
        //go back to the scanner page
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
