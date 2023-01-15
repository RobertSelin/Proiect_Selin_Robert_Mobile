using Proiect_Selin_Robert_Mobile.Models;

namespace Proiect_Selin_Robert_Mobile;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

	async void OnSaveButtonClicked (object sender, EventArgs e)
	{
		var blist = (BookingList)BindingContext;
		blist.Date = DateTime.UtcNow;
		Court selectedCourt = (CourtPicker.SelectedItem as Court);
		blist.CourtID = selectedCourt.ID;
		await App.Database.SaveBookingListAsync(blist);
		await Navigation.PopAsync();
	}

    async void OnDeleteButtonClicked (object sender, EventArgs e)
	{
		var blist = (BookingList)BindingContext;
		await App.Database.DeleteShopListBookingListAsync(blist);
		await Navigation.PopAsync();
	}

	async void OnChooseButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SportPage((BookingList)this.BindingContext)
		{
			BindingContext = new Sport()
		});
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		var items = await App.Database.GetCourtsAsync();
		CourtPicker.ItemsSource = (System.Collections.IList)items;
		CourtPicker.ItemDisplayBinding = new Binding("CourtDetails");

		var sportl = (BookingList)BindingContext;
		listView.ItemsSource = await App.Database.GetListSportsAsync(sportl.ID);
	}

}