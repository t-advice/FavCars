using FavCars.Models;
using FavCarsAppShell.Data;

namespace FavCars.Views
{
    [QueryProperty(nameof(CarId), "carId")]
    public partial class CarDetailsPage : ContentPage
    {
        private Car _car;
        public int CarId { get; set; }

        public CarDetailsPage()
        {
            InitializeComponent();
            _database = new CarDatabase();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            _car = await App.Database.GetCarAsync(CarId);
            if (_car != null)
            {
                CarNameLabel.Text = _car.Name;
                CarYearLabel.Text = $"Year: {_car.Year}";
                CarEngineLabel.Text = $"Engine: {_car.Engine}";
                CarColorLabel.Text = $"Color: {_car.Color}";
                CarFuelTypeLabel.Text = $"Fuel: {_car.FuelType}";

                CarImage.Source = string.IsNullOrEmpty(_car.ImagePath)
                    ? "defaultcar.png" // default image
                    : _car.ImagePath;
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
