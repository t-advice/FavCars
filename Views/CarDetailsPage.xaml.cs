using FavCars.Models;

namespace FavCars.Views;

public partial class CarDetailsPage : ContentPage
{
	public string CarId { get; set; }
    public object Name { get; private set; }

    public CarDetailsPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (int.TryParse(CarId, out int id))
        {
            var car = (await App.Database.GetCarsAsync()).FirstOrDefault(c => c.id == id);
            if (car != null)
            {
                CarImage.Source = car.ImagePath;
                CarName.Text = car.Name;
                CarYear.Text = $"Year: {car.Year}";
                CarEngine.Text = car.Engine;
                CarColor.Text = car.Color;
                CarFuel.Text = car.FuelType;
                
            }
        }
    }
}