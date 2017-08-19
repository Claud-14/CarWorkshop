using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CarWorkshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarManager CM = new CarManager();
        
        public MainWindow()
        {
            InitializeComponent();
            StartoActivate();
            //Initialized += StartoActivate;
        }
        /*public delegate void StartoHandler(object sender, EventArgs e);
        public event StartoHandler Starto;*/
        public void StartoActivate()//object sender, EventArgs e) <This was an event handler
        {
            CM.AddCar("Toyota", "Corolla", 1995);
            LB_CarBox.Items.Add(String.Format("Car {0}", CM.Cars.Count));
            LB_CarBox.SelectedIndex = 0;
        }

        private void BT_AddCar_Click(object sender, RoutedEventArgs e)
        {
            if (CM.CheckYear(TB_CarYear.Text))
            {
                MessageBox.Show("Enter only numeric characters on the \"Year\" field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                CM.AddCar(TB_CarMake.Text, TB_CarModel.Text, int.Parse(TB_CarYear.Text));
                LB_CarBox.Items.Add(String.Format("Car {0}", CM.Cars.Count));
            }
        }

        private void LB_CarBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = LB_CarBox.SelectedIndex;
            var item = CM.Cars[index];
            TBk_CarInfo.Text = String.Format("Car {0}\n{1} {2} {3}\n\nProblem:", index + 1, item.Year, item.Make, item.Model);
        }
    }

    public class CarManager
    {
        public List<Car> Cars { get; private set; }

        public CarManager()
        {
            Cars = new List<Car>();
        }

        public List<Car> AddCar(string make, string model, int year)
        {
            Cars.Add(new Car() { Make = make,  Model = model, Year = year });
            return Cars;
        }

        public bool CheckYear(string year)
        {
            string example = "0123456789";
            bool pass = false;
            foreach (char c in year)
            {
                foreach (char cs in example)
                {
                    if (cs == c)
                        pass = true;
                }

                if (pass == false)
                    return true;
            }

            return false;
        }
    }

    public class Car
    {
        public int VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
