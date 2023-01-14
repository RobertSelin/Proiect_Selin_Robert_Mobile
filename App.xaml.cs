using Proiect_Selin_Robert_Mobile.Data;

namespace Proiect_Selin_Robert_Mobile;

public partial class App : Application
{
	static BookingListDatabase database;

	public static BookingListDatabase Database
	{
		get
		{
			if (database == null)
			{
				database = new BookingListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BookingList.db3"));
			}

			return database;
		}
	}

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
