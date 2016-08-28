using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManager.BusinessLayer.Common
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool OnPropertyChanged<T>(
            ref T valueRef, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(valueRef, newValue)) return false;
            valueRef = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
