﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Security.Policy;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;

namespace PingViewer.ViewModel
{
    class MainViewModel : NotifyPropertyChanged
    {

        private DispatcherTimer dispatcherTimer;
        private ObservableCollection<Resource> _resources;
        public ObservableCollection<Resource> Resources
        {
            get => _resources;
            set
            {
                _resources = value;
                OnPropertyChanged("Resources");
            }
        }

        public MainViewModel()
        {
            Resources = new ObservableCollection<Resource>();
            dispatcherTimer = new DispatcherTimer(); 
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        public RelayCommand NewResourceRelayCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var addWindow = new AddWindow();
                    if (addWindow.ShowDialog() ?? false)
                        Resources.Add(new Resource(addWindow.Address));
                });
            }
        }
        public RelayCommand RemoveResource
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var res = (Resource)obj;
                    Resources.Remove(res);
                });
            }
        }
        public RelayCommand CloseApp
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (obj != null)
                        ((Window)obj).Close();
                });
            }
        }

        async private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Ping pingSender = new Ping();
            foreach (var res in Resources)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        res.Status = pingSender.SendPingAsync(res.Address).Result.Status;
                    });
                }
                catch
                {
                    res.Status = IPStatus.BadRoute;
                }
            }
        }
    }
}
