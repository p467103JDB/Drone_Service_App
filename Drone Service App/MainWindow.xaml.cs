﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /*  GUI FEATURES:
        - The input for the Service Tag must be a numeric control. The minimum value is 100, maximum is 900 with increments of 10.  
        - The input for the Service Priority must be two radio buttons inside the same GroupName. The two values are Regular and Express. This data is not part of the Drone class. 
        - The input for the Service Problem must be a multi-lined textbox. 
        - The service items must be displayed in a ListView which displays all the class attributes. 
        - The finished service items must be displayed in a ListBox which displays the Client Name and Service Cost. 
    */
    /* Programming Criteria
        - 6.1 Create a separate class file to hold the data items of the Drone. Use separate getter and setter methods, 
          ensure the attributes are private and the accessor methods are public. Add a display method that returns a string for Client Name and Service Cost. Add suitable code to the 
          Client Name and Service Problem accessor methods so the data is formatted as Title case or Sentence case. Save the class as “Drone.cs”.
        - 6.2 Create a global List<T> of type Drone called “FinishedList”.  
        - 6.3 Create a global Queue<T> of type Drone called “RegularService”. 
        - 6.4 Create a global Queue<T> of type Drone called “ExpressService”. 
        - 6.5 Create a button method called “AddNewItem” that will add a new service item to a Queue<> based on the priority. Use TextBoxes for the Client Name, Drone Model, Service Problem
          and Service Cost. Use a numeric control for the Service Tag. The new service item will be added to the appropriate Queue based on the Priority radio button. 
        - 6.6 Before a new service item is added to the Express Queue the service cost must be increased by 15%. 
        - 6.7 Create a custom method called “GetServicePriority” which returns the value of the priority radio group. This method must be called inside the “AddNewItem” method before the new service item is added to a queue. 
        - 6.8 Create a custom method that will display all the elements in the RegularService queue. The display must use a List View and with appropriate column headers. 
        - 6.9 Create a custom method that will display all the elements in the ExpressService queue. The display must use a List View and with appropriate column headers. 
        - 6.10 Create a custom method to ensure the Service Cost textbox can only accept a double value with two decimal point. 
        - 6.11 Create a custom method to increment the service tag control, this method must be called inside the “AddNewItem” method before the new service item is added to a queue. 
        - 6.12 Create a mouse click method for the regular service ListView that will display the Client Name and Service Problem in the related textboxes. 
        - 6.13 Create a mouse click method for the express service ListView that will display the Client Name and Service Problem in the related textboxes. 
        - 6.14 Create a button click method that will remove a service item from the regular ListView and dequeue the regular service Queue<T> data structure. The dequeued item must be added to the List<T> and displayed in the ListBox for finished service items. 
        - 6.15 Create a button click method that will remove a service item from the express ListView and dequeue the express service Queue<T> data structure. The dequeued item must be added to the List<T> and displayed in the ListBox for finished service items. 
        - 6.16 Create a double mouse click method that will delete a service item from the finished listbox and remove the same item from the List<T>. 
        - 6.17 Create a custom method that will clear all the textboxes after each service item has been added. 
        - 6.18 All code is required to be adequately commented. Map the programming criteria and features to your code/methods by adding comments above the method signatures. Ensure your code is compliant with the CITEMS coding standards (refer http://www.citems.com.au/). 
     */

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // GUI features

        #region WATERMARK FEATURES - not important just for User Ex
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

    }
}
