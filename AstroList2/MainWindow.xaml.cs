using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AstroList2.Data;
using AstroList2.Models;

namespace AstroList2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Planet> _planets;

        public MainWindow()
        {
            InitializeComponent();

            _planets = PlanetData.GetPlanetsInRandomOrder();
            DisplayPlanets();
        }

        public void DisplayImage(string fileName, long distance)
        {
            planetButton.Visibility = Visibility.Visible;
            planetImage.Source = new BitmapImage(new Uri($"Images/{fileName}", UriKind.Relative));
            planetImage.Stretch = Stretch.Uniform;
        }

        public void DisplayPlanets()
        {
            planetsListBox.Items.Clear();
            foreach (Planet planet in _planets)
            {
                planetsListBox.Items.Add(planet);
            }
        }

        private void OnPlanetSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Planet selectedPlanet = (Planet)planetsListBox.SelectedItem;
            if (selectedPlanet == null)
            {
                return;
            }

            nameTextBox.Text = selectedPlanet.Name;

            string size = selectedPlanet.Size;
            switch (size)
            {
                case "Small":
                    smalRadioButton.IsChecked = true;
                    break;

                case "Medium":
                    mediumRadioButton.IsChecked = true;
                    break;

                case "Large":
                    largeRadioButton.IsChecked = true;
                    break;
            }

            temperatureTextBox.Text = selectedPlanet.TemperatureInCelcius.ToString();

            ringsCheckBox.IsChecked = selectedPlanet.HasRings == true;
            atmosphereCheckBox.IsChecked = selectedPlanet.HasAtmosphere == true;
            moonsCheckBox.IsChecked = selectedPlanet.HasMoons == true;

            //if (selectedPlanet.NumberOfMoons > 0)
            //{
            //    moonsCheckBox.IsChecked = true;
            //}




            DisplayImage(selectedPlanet.ImageName, selectedPlanet.DistanceFromSunInKm);
        }

        private void OnMoveUpButtonClicked(object sender, RoutedEventArgs e)

        //lijst van planeten heeft zelfde volgorde als de listbox 

        //geselecteerde planeet even aan de kant zetten (zie pokemon-oef) daarna de planeet erboven één index naar beneden. Dan de aan de kant gezette planeet op de index - 1 zetten.
        {
            Planet selectedPlanet = (Planet)planetsListBox.SelectedItem;

            int index = _planets.IndexOf(selectedPlanet);

            //int indexOfPlanet = planetsListBox.SelectedIndex;

            if (index == 0)
            {
                index = _planets.Count - 1;
            }
            else
            {
                index -= 1;
            }

            planetsListBox.SelectedIndex = index;

            //DisplayPlanets();


            //    Planet selectedPlanet = (Planet)planetsListBox.SelectedItem;

            //if (selectedPlanet == null)
            //{
            //    return;
            //}

            //int index = _planets.IndexOf(selectedPlanet);
            //int newIndex;

            //if (index == 0)
            //{
            //    newIndex = (_planets.Count - 1);
            //    selectedPlanet = _planets[_planets.Count -1];
            //}
            //else
            //{
            //    newIndex = index - 1;
            //    selectedPlanet = _planets[index - 1];
            //}

            //// _planets = PlanetData.GetPlanetsInRandomOrder();
            //DisplayPlanets();

            //planetsListBox.SelectedIndex = newIndex;
        }

        private void OnMoveDownButtonClicked(object sender, RoutedEventArgs e)
        {
            Planet selectedPlanet = (Planet)planetsListBox.SelectedItem;

            if (selectedPlanet == null)
            {
                return;
            }

            int index = planetsListBox.SelectedIndex;

            if (index == (_planets.Count - 1))
            {
                index = 0;
            }
            else
            {
                index += 1;
            }

            DisplayPlanets();

        }

        private void OnPlanetButtonClicked(object sender, RoutedEventArgs e)
        {
            Planet selectedPlanet = (Planet)planetsListBox.SelectedItem;
            int days = selectedPlanet.CalculateTravelTimeFromSunToPlanetInDays(40000);

            MessageBox.Show($"Het duurt {days} dagen om met een raket van de zon naar {selectedPlanet.Name} te reizen.");
        }
    }
}