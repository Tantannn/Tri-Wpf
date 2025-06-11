using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tri_Wpf.Models;

public class SpacingItem : INotifyPropertyChanged
{
    private string _cmd;
    private double _value;

    public string Cmd
    {
        get => _cmd;
        set
        {
            _cmd = value;
            OnPropertyChanged();
        }
    }

    public double Value
    {
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}