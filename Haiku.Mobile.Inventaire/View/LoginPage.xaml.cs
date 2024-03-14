using BarcodeScanner.Mobile;

namespace Haiku.Mobile.Inventaire.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.All);
        InitializeComponent();
        Methods.AskForRequiredPermission();
    }

    public string qrCodeString;
    private void Camera_OnDetected(object sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
    {
        qrCodeString = e.BarcodeResults[0].DisplayValue;

        Dispatcher.Dispatch(async () =>
        {
            await DisplayAlert("Success", "TSI Login code scanned successfully.", "OK");
            // If you want to start scanning again
            //Camera.IsScanning = true;
            await Shell.Current.GoToAsync($"//PasswordPage?qrCodeString={qrCodeString}", true);
        });
    }
}