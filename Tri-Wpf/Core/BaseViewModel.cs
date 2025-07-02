using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tri_Wpf.Core;
public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    protected void OnItemPropertyChanged<T>(
        object? sender, PropertyChangedEventArgs e,
        string propertyNameToWatch,
        Action callback)
        where T : INotifyPropertyChanged
    {
        if (e.PropertyName == propertyNameToWatch)
        {
            callback();
        }
    }
}
