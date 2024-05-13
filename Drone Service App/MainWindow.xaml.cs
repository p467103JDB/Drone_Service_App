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

namespace Drone_Service_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Drone> FinishedList = new List<Drone>();       // 6.2 
        Queue<Drone> RegularService = new Queue<Drone>();   // 6.3
        Queue<Drone> ExpressService = new Queue<Drone>();   // 6.4

       

        // GUI features
        #region WATERMARK FEATURES - not important just for User Experience
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

        private void ServiceProblem_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ServiceProblem.Text))
            {
                ServiceProblem.Visibility = Visibility.Collapsed;
                ServiceProblemWatermark.Visibility = Visibility.Visible;
            }
        }

        private void ServiceProblemWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ServiceProblemWatermark.Visibility = Visibility.Collapsed;
            ServiceProblem.Visibility = Visibility.Visible;
            ServiceProblem.Focus();
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
            // 6.6 +15% express cost
            // 6.7 GetServicePriorty(); called inside this method
            // 6.11 Increment service tag - before it is added to a queue

        }

        private void UpdateDisplay()
        {
            // 6.8 Display method - express
            // 6.9 Display method - regular
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