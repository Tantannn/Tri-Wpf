using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows ;
using System.Windows.Input ;
using Tri_Wpf.Commands;
using Tri_Wpf.Models ;
using Tri_Wpf.Views;

namespace Tri_Wpf.ViewModels;

public class MainWindowVm : INotifyPropertyChanged
{
    private string _interval;
    private bool _hasTopPlate ;
    private IList<SpacingItem> _spacingItems ;

    private bool _isComboBoxEnabled;

    public string Interval
    {
        get => _interval;
        set => SetField(ref _interval, value);
    }

    public bool HasTopPlate
    {
        get => _hasTopPlate;
        set
        {
            SetField(ref _hasTopPlate, value);
        }
    }

    private int _numberOfPiles ;

    public int NumberOfPiles
    {
        get => _numberOfPiles ;
        set => SetField( ref _numberOfPiles, value ) ;
    }

    public bool IsComboBoxEnabled
    {
        get => _isComboBoxEnabled;
        set => SetField( ref _isComboBoxEnabled, value ) ;
    }

    public ICommand EditSpacingCommand { set ; get ; }
    
    public MainWindowVm()
    {
        EditSpacingCommand = new RelayCommand( _ =>
        {
            if ( NumberOfPiles > 0 ) {
                var spacingEdit = new SpacingEdit( NumberOfPiles ) ;
                spacingEdit.ShowDialog() ; // Show() and ShowDialog()
                var spacingVm = (SpacingVm) spacingEdit.DataContext ;
                _spacingItems = spacingVm.Spacings ;
                
                var spacingsEqually = _spacingItems.All( s => Math.Abs( s.Value - _spacingItems[ 0 ].Value ) < 1e-6 ) ;
                var totalDisplayText = spacingsEqually ? _spacingItems[ 0 ].Value.ToString() : "Vary" ;
                Interval = $"間隔 (mm)：{totalDisplayText}" ;
            }
            else {
                MessageBox.Show( "正しい数値を入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning ) ;
            }
        }, _ => true ) ;
    }
    
    // public void OpenSpacingVn

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}

