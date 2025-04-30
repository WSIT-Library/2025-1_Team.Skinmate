using CommunityToolkit.Maui.Views;

namespace MauiApp1.Views.Content;

public partial class WebMapPopup : Popup
{
    public WebMapPopup()
    {
        InitializeComponent();
        
        //MapWebView.Source = "http://10.101.123.25:8080/web/main.html";
        LoadLocationInit();
    
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
    private async void LoadLocationInit()
    {
            
        var location = await Geolocation.Default.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
        double lat = location?.Latitude ?? 37.5665;
        double lon = location?.Longitude ?? 126.9780;
        Console.WriteLine($"��ǥ ���: lat = {lat}, lon = {lon}");
        // ���� �Ķ���Ϳ� ��ǥ ���̱�
        MapWebView.Source = $"http://10.101.123.25:8080/web/main.html?lat={lat}&lon={lon}";
    }
}