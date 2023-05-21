using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedApp.ViewModels.Base
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Called by the Set accessor of a property to invoke event
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Set accessor for proprties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">Property</param>
        /// <param name="value">New property value</param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if(Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
