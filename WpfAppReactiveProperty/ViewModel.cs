using System;
using System.ComponentModel;

namespace WpfAppReactiveProperty
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string parameter)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter));
    }
    class ViewModel : ViewModelBase
    {
        private int selectedMode;
        public int SelectedMode
        {
            get { return selectedMode; }
            set
            {
                if (value == selectedMode)
                    return;
                selectedMode = value;
                DoFunc(selectedMode);
                NotifyPropertyChanged(nameof(SelectedMode));
            }
        }

        private void DoFunc(int selectedMode)
        {
        }
    }
}
