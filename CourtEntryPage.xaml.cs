using Proiect_Selin_Robert_Mobile.Models;

namespace Proiect_Selin_Robert_Mobile;

public partial class CourtEntryPage : ContentPage
{
	public CourtEntryPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource = await App.Database.GetCourtsAsync();
	}

	async void OnCourtAddedClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CourtPage
		{
			BindingContext = new Court()
		});
	}

	async void OnListViewSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem != null)
		{
			await Navigation.PushAsync(new CourtPage
			{
				BindingContext = e.SelectedItem as Court
			});
		}
	}
}