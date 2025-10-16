using FavCars.Models;
using FavCarsAppShell.Data;
using System;
using Microsoft.Maui.Controls;
using FavCars.Data;
using System.IO;

namespace FavCars.Views
{
    [QueryProperty(nameof(CarId), "carId")]
    public partial class CarDetailsPage : ContentPage
    {
        private readonly CarDatabase _database;
        private Car _car;

        public int CarId { get; set; }

        public CarDetailsPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "cars.db3"
            );
            _database = new CarDatabase(dbPath);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            _car = await _database.GetCarAsync(CarId);

            if (_car != null)
            {
                CarNameLabel.Text = _car.Name;
                CarYearLabel.Text = _car.Year.ToString();
                CarEngineLabel.Text = _car.Engine;
                CarColorLabel.Text = _car.Color;
                CarFuelTypeLabel.Text = _car.FuelType;
            }
        }
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

