using Proiect_Selin_Robert_Mobile.Models;

namespace Proiect_Selin_Robert_Mobile;

public partial class CourtPage : ContentPage
{
    public CourtPage()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var court = (Court)BindingContext;
        await App.Database.SaveCourtAsync(court);
        await Navigation.PopAsync();
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var court = (Court)BindingContext;
        var address = court.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Baza preferata"
        };
        var location = locations?.FirstOrDefault();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }
}