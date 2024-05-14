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
using System.ComponentModel; // Why is this so tedious seriously, just for a fkn status strip.
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel; // also this is needed????

namespace Drone_Service_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



public partial class MainWindow : Window
    {

        private ObservableCollection<Drone> ExpressServiceItems = new ObservableCollection<Drone>();
        private ObservableCollection<Drone> RegularServiceItems = new ObservableCollection<Drone>();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this; // necessary for a few components to work.

            ServiceDroneExp.ItemsSource = null;  // JUST FUCKING WHY!??!?!?!? This fixes my issue of being unable to refresh the listview - https://stackoverflow.com/questions/20996288/wpf-listview-changing-itemssource-does-not-change-listview
            ServiceDroneExp.ItemsSource = ExpressServiceItems;
            ServiceDroneReg.ItemsSource = null;
            ServiceDroneReg.ItemsSource= RegularServiceItems;
        }
        public StatusUpdate Status { get; set; } = new StatusUpdate(); // Status bar message used directly from - https://stackoverflow.com/questions/53503794/c-sharp-wpf-update-status-bar-text-and-progress-from-another-window

        List<Drone> FinishedList = new List<Drone>();       // 6.2 
        Queue<Drone> RegularService = new Queue<Drone>();   // 6.3
        Queue<Drone> ExpressService = new Queue<Drone>();   // 6.4

        // GUI features
        #region WATERMARK FEATURE
        // Watermark features came from this video: https://www.youtube.com/watch?v=YPwnBJod5a8
        private void ClientName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ClientName.Text))
            {
                ClientName.Visibility = Visibility.Collapsed;
                ClientNameWatermark.Visibility = Visibility.Visible;
            }
        }

        private void ClientNameWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ClientNameWatermark.Visibility = Visibility.Collapsed;
            ClientName.Visibility = Visibility.Visible;
            ClientName.Focus();
        }

        private void DroneModel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DroneModel.Text))
            {
                DroneModel.Visibility = Visibility.Collapsed;
                DroneModelWatermark.Visibility = Visibility.Visible;
            }
        }

        private void DroneModelWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            DroneModelWatermark.Visibility = Visibility.Collapsed;
            DroneModel.Visibility = Visibility.Visible;
            DroneModel.Focus();
        }

        private void ServiceDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ServiceDescription.Text))
            {
                ServiceDescription.Visibility = Visibility.Collapsed;
                ServiceDescriptionWatermark.Visibility = Visibility.Visible;
            }
        }

        private void ServiceDescriptionWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ServiceDescriptionWatermark.Visibility = Visibility.Collapsed;
            ServiceDescription.Visibility = Visibility.Visible;
            ServiceDescription.Focus();
        }

        private void ServiceFee_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ServiceFee.Text))
            {
                ServiceFee.Visibility = Visibility.Collapsed;
                ServiceFeeWatermark.Visibility = Visibility.Visible;
            }
        }

        private void ServiceFeeWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ServiceFeeWatermark.Visibility = Visibility.Collapsed;
            ServiceFee.Visibility = Visibility.Visible;
            ServiceFee.Focus();
        }
        #endregion

        private void AddNewItem_Click(object sender, RoutedEventArgs e) // 6.5
        {
            // Check if the criteria is valid to add.
            if (string.IsNullOrEmpty(ClientName.Text))
            {
                ClientNameWatermark_GotFocus(sender, e);
                this.Status.Message = "Client Name field must not be empty.";
                return;
            }
            else if (string.IsNullOrEmpty(DroneModel.Text))
            {
                DroneModelWatermark_GotFocus(sender, e);
                this.Status.Message = "Drone Model field must not be empty.";
                return;     
            }
            else if (string.IsNullOrEmpty(ServiceDescription.Text))
            {
                ServiceDescriptionWatermark_GotFocus(sender, e);
                this.Status.Message = "Service description field must noy be empty.";
                return;
            }
            else if(DoubleValidator() <= 0)
            {
                ServiceFee.Clear();
                ServiceFeeWatermark_GotFocus(sender, e);
                this.Status.Message = "Service fee must not be empty or zero. Example:  '5.00'";
                return;
            }
            else if(GetServicePriority() < 0) // 6.7 <- GetServicePriorty()
            {
                this.Status.Message = "Please select a service type.";
                return;
            }

            // Need to do the Tag comparision so i dont get duplicates

            Drone newDrone = new Drone();
            newDrone.ClientName = ClientName.Text;
            newDrone.DroneModel = DroneModel.Text;
            newDrone.ServiceDescription = ServiceDescription.Text;
            newDrone.ServiceFee = DoubleValidator();
            newDrone.ServiceTag = int.Parse(ServiceTag.Text);

            if (GetServicePriority() == 1) 
            {
                ExpressService.Enqueue(newDrone);
                this.Status.Message = "Successfully added Entry to express queue.";
            }
            else
            {
                RegularService.Enqueue(newDrone);
                this.Status.Message = "Successfully added Entry to regular queue.";
            }

            // 6.11 Increment service tag - before it is added to a queue
            UpdateDisplay();
        }

        private double DoubleValidator()
        {
            double dubs = -1.00;

            if (!string.IsNullOrEmpty(ServiceFee.Text))
            {
                if (double.TryParse(ServiceFee.Text, out dubs)) // if it aint a double it's no bueno
                {
                    return dubs;
                }
            }
            return dubs;
        }

        private int GetServicePriority() // 6.7 
        {
            if (ExpressButton.IsChecked == true) // check to see if it's selected
            {
                return 1;
            }
            else if (RegularButton.IsChecked == true)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        private void UpdateDisplay()
        {
            // "Why did you refresh both listviews in one method" - idgaf
            ExpressServiceItems.Clear(); // Listview Express gets cleared and then populated
            foreach (Drone item in ExpressService) 
            {
                Drone drone = new Drone
                {
                    ClientName = item.ClientName,
                    DroneModel = item.DroneModel,
                    ServiceTag = item.ServiceTag,
                    ServiceFee = item.ServiceFee,
                };
                ExpressServiceItems.Add(drone);
            }

            RegularServiceItems.Clear(); // Listview regular gets cleared and then populated
            foreach (Drone item in RegularService) 
            {
                Drone drone = new Drone
                {
                    ClientName = item.ClientName,
                    DroneModel = item.DroneModel,
                    ServiceTag = item.ServiceTag,
                    ServiceFee = item.ServiceFee,
                };
                RegularServiceItems.Add(drone);
            }
        }

        private void RemoveSelectedItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearFields_Click(object sender, RoutedEventArgs e)
        {

        }

        // 6.10 Force service fee to only accep double values with 2 decimal points
        // 6.12 Click method - displays express service item
        // 6.13 Click method - displays regular service item
        // 6.14 Remove item method - express
        // 6.15 Remove item method - regular
        // 6.16 Double click item method - deletes item 
        // 6.17 Clear all method - text box fields
        // 6.18 Make sure code good.
    }
}