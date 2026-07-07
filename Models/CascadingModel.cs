using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace First.Models
{
    public class CascadingModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _someText = string.Empty;

        public string SomeText
        {
            get { return _someText; }
            set 
            {
                _someText = value;
                //OnPropertyChanged();
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

