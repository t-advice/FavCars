using FavCars.Models;
using FavCarsAppShell.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace FavCars;

public partial class App : Application
{
    static CarDatabase _database;
    public App()
    {
        InitializeComponent();


        MainPage = new AppShell();
    }

    public static CarDatabase Database
    {
        get
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cars.db3");
                _database = new CarDatabase(dbPath);
            }
            return _database;



        }

    }
}