using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Service_Application
{
    
    class Drone : INotifyPropertyChanged// 6.1
    {
        // Getters and setters
        private string? clientName;
        public string? ClientName
        {
            get { return clientName; }
            set
            {
                if (clientName!= value)
                {
                    clientName = value;
                    OnPropertyChanged(nameof(ClientName));
                }
            }
        }

        private string? droneModel;
        public string? DroneModel
        {
            get { return droneModel; }
            set
            {
                if (droneModel!= value)
                {
                    droneModel = value;
                    OnPropertyChanged(nameof(DroneModel));
                }
            }
        }

        private string? serviceDescription;
        public string? ServiceDescription
        {
            get { return serviceDescription; }
            set
            {
                if (serviceDescription!= value)
                {
                    serviceDescription = value;
                    OnPropertyChanged(nameof(ServiceDescription));
                }
            }
        }

        private double serviceFee;
        public double ServiceFee
        {
            get { return serviceFee; }
            set
            {
                if (serviceFee!= value)
                {
                    serviceFee = value;
                    OnPropertyChanged(nameof(ServiceFee));
                }
            }
        }

        private int serviceTag;
        public int ServiceTag
        {
            get { return serviceTag; }
            set
            {
                if (serviceTag!= value)
                {
                    serviceTag = value;
                    OnPropertyChanged(nameof(ServiceTag));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
