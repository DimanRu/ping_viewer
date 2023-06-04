using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Windows.Documents;

namespace PingViewer.ViewModel
{
    class MainViewModel : NotifyPropertyChanged
    {

        private string _pattern;
        public string Pattern
        {
            get => _pattern;
            set
            {
                _pattern = value;
                OnPropertyChanged("Pattern");
            }
        }

        public MainViewModel()
        {

        }

        public RelayCommand GenerateRelayCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {

                });
            }
        }
    }
}
