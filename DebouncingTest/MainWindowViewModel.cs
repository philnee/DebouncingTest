using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DebouncingTest
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int _commandsSent;

        public int CommandsSent
        {
            get { return _commandsSent; }
            set
            {
                _commandsSent = value;
                OnPropertyChanged();
            }
        }

        public ICommand Button1Command { get; set; }
        public ICommand Button2Command { get; set; }

        public MainWindowViewModel()
        {
            Button1Command = new CustomCommand(SendCommand);
            Button2Command = new CustomCommand(SendCommand);
        }

        private void SendCommand()
        {
            CommandsSent++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}