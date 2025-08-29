namespace FavCars
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.CarDetailsPage), typeof(Views.CarDetailsPage));
            Routing.RegisterRoute(nameof(Views.AddCarPage), typeof(Views.AddCarPage));
        }
    }
}
