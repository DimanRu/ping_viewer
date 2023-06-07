using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingViewer
{
    internal class Resource : NotifyPropertyChanged
    {
        private string _address;
        private IPStatus _status;
        public string Address => _address;
        public IPStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public Resource(string address)
        {
            _address = address;
            Status = IPStatus.Unknown;
        }
    }
}
