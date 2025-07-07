using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Schroedinger.MauiCommands.Infrastructure
{
    public class BaseModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Methods

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName="" ) 
        {
            if( property == null)
                return false;

            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
