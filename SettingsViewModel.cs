using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp
{
    public class SettingsViewModel : INotifyPropertyChanged
    {

        public SettingsViewModel()
        {
            background = "roi_pattern_3.png";
        }

        private string _Background { get; set; }
        public string background
        {
            get => _Background;
            set
            {
                if (_Background == value)
                {
                    return;
                }
                _Background = value;
                OnPropertyChanged("background");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
            =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
