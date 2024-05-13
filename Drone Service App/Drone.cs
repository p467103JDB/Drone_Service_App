using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Service_App
{
    
    class Drone // 6.1
    {
        private string? clientName;
        private string? droneModel;
        private string? serviceDescription;
        private double serviceFee;
        private int serviceTag;

        // Getters and setters
        public string? GetClientName() 
        {
            return clientName;
        }

        public void SetClientName(string _ClientName)
        {
            clientName = _ClientName;
        }

        public string? GetDroneModel()
        {
            return droneModel;
        }

        public void SetDroneModel(string _DroneModel)
        {
            droneModel = _DroneModel;
        }

        public string? GetServiceDescription()
        {
            return serviceDescription;
        }

        public void SetServiceDescription(string _ServiceDescription)
        {
            serviceDescription = _ServiceDescription;
        }

        public double GetServiceFee()
        {
            return serviceFee;
        }

        public void SetServiceFee(double _ServiceFee)
        {
            serviceFee = _ServiceFee;
        }

        public int GetServiceTag()
        {
            return serviceTag;
        }

        public void SetServiceTag(int _ServiceTag)
        {
            serviceTag = _ServiceTag;
        }
    }
}
