using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tri_Wpf.Views;

namespace Tri_Wpf.ViewModels;

public class MainWindowVm : INotifyPropertyChanged
{
    private string _interval;

    public string Interval
    {
        get => _interval;
        set => SetField(ref _interval, value);
    }
    public MainWindowVm(int count)
    {
        var editWindow = new SpacingEdit(count);
        // MainWindowVm
        editWindow.Closed += (s, args) =>
        {
            if (editWindow.DialogResult != true) return;
            var vm = (SpacingVm)editWindow.DataContext;
            var spacings = vm.Spacings;
            var spacingsEqually = spacings.All(s => Math.Abs(s.Value - spacings[0].Value) < 1e-6);
            var totalDisplayText = spacingsEqually ? spacings[0].Value.ToString() : "Vary";
            // Interval.Text = $"間隔 (mm)：{totalDisplayText}";
            Interval = $"間隔 (mm)：{totalDisplayText}";
        };
        editWindow.ShowDialog();
    }

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
}