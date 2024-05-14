using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Drone_Service_App
{
    // this came directly from - https://stackoverflow.com/questions/53503794/c-sharp-wpf-update-status-bar-text-and-progress-from-another-window
    public class StatusUpdate : INotifyPropertyChanged
    {
        private string message;
        public event PropertyChangedEventHandler PropertyChanged;

        public StatusUpdate()
        {
        }

        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
                this.OnPropertyChanged("");
            }
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
