using BarcodeScanner.Mobile;

namespace Haiku.Mobile.Inventaire.View;

public partial class BarcodeScanPage : ContentPage
{
    public BarcodeScanPage()
    {
        Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.All);
        Methods.AskForRequiredPermission();
        InitializeComponent();

    }

    public string barcodeString;
    private void Camera_OnDetected(object sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
    {
        barcodeString = e.BarcodeResults[0].DisplayValue;

        Dispatcher.Dispatch(async () =>
        {
            await DisplayAlert("Success", "Barcode scanned successfully.", "OK");
            // disabling camera
            Camera.IsScanning = false;


            await Shell.Current.GoToAsync($"//AddArticlePage?barcodeString={barcodeString}", true);

        });
    }
}