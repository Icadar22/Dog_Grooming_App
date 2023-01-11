using System;
using Dog_Grooming_App.Data;
using System.IO;


namespace Dog_Grooming_App;

public partial class App : Application
{
    static AppointmentListDatabase database;
    public static AppointmentListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               AppointmentListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "AppointmentList.db3"));
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
