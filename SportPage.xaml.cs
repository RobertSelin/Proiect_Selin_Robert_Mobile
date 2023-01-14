using Proiect_Selin_Robert_Mobile.Models;

namespace Proiect_Selin_Robert_Mobile;

public partial class SportPage : ContentPage
{
	BookingList bl;
	public SportPage(BookingList blist)
	{
		InitializeComponent();
		bl = blist;
	}

	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var sport = (Sport)BindingContext;
		await App.Database.SaveSportAsync(sport);
		listView.ItemsSource = await App.Database.GetSportsAsync();
	}

	async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		var sport = (Sport)BindingContext;
		await App.Database.DeleteSportAsync(sport);
		listView.ItemsSource = await App.Database.GetSportsAsync();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource = await App.Database.GetSportsAsync();
	}

	async void OnAddButtonClicked(object sender, EventArgs e)
	{
		Sport s;
		if (listView.SelectedItem != null)
		{
			s = listView.SelectedItem as Sport;
			var ls = new ListSport()
			{
				BookingListID = bl.ID,
				SportID = s.ID
			};

		await App.Database.SaveListSportAsync(ls);
		s.ListSports = new List<ListSport> { ls };
		await Navigation.PopAsync();
		}
	}
}