using Proiect_Selin_Robert_Mobile.Models;

namespace Proiect_Selin_Robert_Mobile;

public partial class ListEntryPage : ContentPage
{
	public ListEntryPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource = await App.Database.GetBookingListsAsync();
	}

	async void OnBookingListAddedClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ListPage
		{
			BindingContext = new BookingList()
		});
	}

	async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem != null)
		{
			await Navigation.PushAsync(new ListPage
			{
				BindingContext = e.SelectedItem as BookingList
			});
		}
	}
}