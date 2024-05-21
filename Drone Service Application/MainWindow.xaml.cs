using System.Collections.ObjectModel;
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

namespace Drone_Service_Application
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StatusMessage.Text = "Welcome";
        }

        // 6.2 Create list for finished items
        List<Drone> FinishedList = new List<Drone>();       
        // 6.3 Create queue for Regular service
        Queue<Drone> RegularService = new Queue<Drone>();  
        // 6.4 Create queue for Express service
        Queue<Drone> ExpressService = new Queue<Drone>();  

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

        #region DISPLAY ALL TEXT BOXES
        private void RevealTextFields() // all fields should be revealed in this case
        {
            ClientNameWatermark.Visibility = Visibility.Collapsed;
            ClientName.Visibility = Visibility.Visible;
            DroneModelWatermark.Visibility = Visibility.Collapsed;
            DroneModel.Visibility = Visibility.Visible;
            ServiceDescriptionWatermark.Visibility = Visibility.Collapsed;
            ServiceDescription.Visibility = Visibility.Visible;
            ServiceFeeWatermark.Visibility = Visibility.Collapsed;
            ServiceFee.Visibility = Visibility.Visible;
        }
        #endregion

        // 6.5  Adds new entry to express or regular list. - 6.6 covered
        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            // Check if the criteria is valid to add to queue.
            if (string.IsNullOrEmpty(ClientName.Text))
            {
                ClientNameWatermark_GotFocus(sender, e);
                StatusMessage.Text = "Client Name field must not be empty.";
                return;
            }
            else if (string.IsNullOrEmpty(DroneModel.Text))
            {
                DroneModelWatermark_GotFocus(sender, e);
                StatusMessage.Text = "Drone Model field must not be empty.";
                return;
            }
            else if (string.IsNullOrEmpty(ServiceDescription.Text))
            {
                ServiceDescriptionWatermark_GotFocus(sender, e);
                StatusMessage.Text = "Service description field must noy be empty.";
                return;
            }
            else if (DoubleValidator() <= 0)
            {
                ServiceFee.Clear();
                ServiceFeeWatermark_GotFocus(sender, e);
                StatusMessage.Text = "Service fee must not be empty or zero. Example:  '5.00'";
                return;
            }
            else if (GetServicePriority() < 0) // 6.7 <- GetServicePriorty()
            {
                StatusMessage.Text = "Please select a service type.";
                return;
            }

            Drone newDrone = new Drone
            {
                ClientName = ClientName.Text,
                DroneModel = DroneModel.Text,
                ServiceDescription = ServiceDescription.Text,
                ServiceFee = DoubleValidator(), // 6.6 <- Applies +15% to the service Fee if it's express 
                ServiceTag = NextServiceTag()
            };

            if (GetServicePriority() == 1)
            {
                ExpressService.Enqueue(newDrone);
                StatusMessage.Text = "Successfully added entry to Express queue.";
                updateDisplayExpress();
            }
            else
            {
                RegularService.Enqueue(newDrone);
                StatusMessage.Text = "Successfully added entry to Regular queue.";
                updateDisplayRegular();
            }
            ClearFields_Click(sender, e);
        }

        // 6.7 Returns the value of the priority radio group. This method must be called inside the “AddNewItem”
        private int GetServicePriority()
        {
            if (ExpressButton.IsChecked == true) // check to see if it's selected
            {
                return 1;
            }
            else if (RegularButton.IsChecked == true)
            {
                return 0;
            }
            else // No button checked
            {
                return -1;
            }
        }

        // 6.8 Update display express
        private void updateDisplayExpress()
        {
            ServiceDroneExp.Items.Clear(); // Listview gets cleared and then populated
            foreach (Drone item in ExpressService)
            {
                ServiceDroneExp.Items.Add(new // add new entry
                {
                    item.ClientName, // formerly ClientName = item.ClientName,
                    item.DroneModel,
                    item.ServiceTag,
                    item.ServiceFee,
                });
            }
        }

        // 6.9 update display regular
        private void updateDisplayRegular()
        {
            ServiceDroneReg.Items.Clear(); // Listview gets cleared and then populated
            foreach (Drone item in RegularService)
            {
                ServiceDroneReg.Items.Add(new // add new entry
                {
                    item.ClientName,
                    item.DroneModel,
                    item.ServiceTag,
                    item.ServiceFee,
                });
            }
        }

        private void UpdateDisplayFinished()
        {
            ListBoxFinished.Items.Clear(); // Listbox gets cleared and then populated
            foreach (Drone item in FinishedList)
            {
                Drone drone = new Drone
                {
                    ClientName = item.ClientName,
                    ServiceFee = item.ServiceFee,
                };
                ListBoxFinished.Items.Add(drone);
            }
        }

        // 6.10 Force service fee to only accept double values with 2 decimal points - 6.6 is also covered here. // use regex next time  <------------------------
        private double DoubleValidator()
        {
            double dubs = -1.00;

            if (!string.IsNullOrEmpty(ServiceFee.Text))
            {
                if (double.TryParse(ServiceFee.Text, out dubs))
                {
                    if (ExpressButton.IsChecked == true)
                    {
                        dubs *= 1.15;
                    }
                    string trimmed = dubs.ToString("0.00");
                    double.TryParse(trimmed, out dubs);
                    return dubs;
                }
            }
            return dubs;
        }

        // 6.11 Increments next service tag.
        private int NextServiceTag()
        {
            int sTag = int.Parse(ServiceTag.Text);

            if (ServiceTag.Value + 10 <= ServiceTag.Maximum)
            {
                ServiceTag.Value = sTag + 10;
            }
            return sTag;
        }

        // 6.12 Click method - displays express service item
        private void ServiceDroneExp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServiceDroneExp.SelectedItem != null)
            {
                RevealTextFields();
                int selectedRow = ServiceDroneExp.SelectedIndex;
                ExpressButton.IsChecked = true;
                DisplayEntryContents(selectedRow, ExpressService);
            }
            ServiceDroneExp.SelectedItem = null;
        }

        // 6.13 Click method - displays regular service item
        private void ServiceDroneReg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServiceDroneReg.SelectedItem != null)
            {
                RevealTextFields();
                int selectedRow = ServiceDroneReg.SelectedIndex;
                RegularButton.IsChecked = true;
                DisplayEntryContents(selectedRow, RegularService);
            }
            ServiceDroneReg.SelectedItem = null;
        }

        private void DisplayEntryContents(int sRow, Queue<Drone> tempQ)
        {
            int index = 0;
            foreach (Drone item in tempQ)
            {
                if (index == sRow) // Selected Row == to current index
                {
                    ClientName.Text = item.ClientName;
                    DroneModel.Text = item.DroneModel;
                    ServiceDescription.Text = item.ServiceDescription;
                    ServiceFee.Text = item.ServiceFee.ToString();
                    ServiceTag.Value = item.ServiceTag;
                    break;
                }
                index++;
            }
        }

        // 6.14 Dequeue / Remove item method - express
        private void DequeueRegular_Click(object sender, RoutedEventArgs e)
        {
            if (RegularService.Count > 0)
            {
                Drone nuDrone = RegularService.Peek();
                FinishedList.Add(nuDrone);
                RegularService.Dequeue();
                UpdateDisplayFinished();
                updateDisplayRegular();
                ClearFields_Click(sender, e);
                StatusMessage.Text = "Entry Completed. Entry removed from regular queue.";
            }
            else
            {
                StatusMessage.Text = "List is empty. Please add an entry to the list to remove.";
            }
        }

        // 6.15 Dequeue / Remove item method - regular
        private void DequeueExpress_Click(object sender, RoutedEventArgs e)
        {
            if (ExpressService.Count > 0)
            {
                Drone nuDrone = ExpressService.Peek();
                FinishedList.Add(nuDrone);
                ExpressService.Dequeue();
                UpdateDisplayFinished();
                updateDisplayExpress();
                ClearFields_Click(sender, e);
                StatusMessage.Text = "Entry Completed. Entry removed from express queue.";
            }
            else
            {
                StatusMessage.Text = "List is empty. Please add an entry to the list to remove.";
            }
        }

        // 6.16 Double click item method - deletes item 
        private void ListBoxFinished_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxFinished.Items.Count > 0)
            {
                int selected = ListBoxFinished.SelectedIndex;
                ListBoxFinished.Items.Remove(selected);
                FinishedList.RemoveAt(selected);
                UpdateDisplayFinished();
                StatusMessage.Text = $"Successfully removed selected item at index: {selected} ";
            }
            else
            {
                StatusMessage.Text = "Cannot remove items that do not exist. ";
            }
        }

        // 6.17 Clear all method - text box fields
        private void ClearFields_Click(object sender, RoutedEventArgs e)
        {
            ClientName.Clear();
            DroneModel.Clear();
            ServiceDescription.Clear();
            ServiceFee.Clear();
            ExpressButton.IsChecked = false;
            RegularButton.IsChecked = false;

            ClientName_LostFocus(sender, e);
            DroneModel_LostFocus(sender, e);
            ServiceDescription_LostFocus(sender, e);
            ServiceFee_LostFocus(sender, e);
        }
    }
}