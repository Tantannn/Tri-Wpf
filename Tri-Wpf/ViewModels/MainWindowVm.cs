using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using Tri_Wpf.Commands;
using Tri_Wpf.Models;
using Tri_Wpf.Views;

namespace Tri_Wpf.ViewModels;

public class MainWindowVm : INotifyPropertyChanged
{
    private string _interval;
    private bool _hasTopPlate;
    private IList<SpacingItem> _spacingItems;
    private int _numberOfPiles;
    private bool _isComboBoxEnabled;
    private int _sf;
    private int _sl;
    private string _profile;

    public string Interval
    {
        get => _interval;
        set => SetField(ref _interval, value);
    }

    public bool HasTopPlate
    {
        get => _hasTopPlate;
        set { SetField(ref _hasTopPlate, value); }
    }


    public int NumberOfPiles
    {
        get => _numberOfPiles;
        set => SetField(ref _numberOfPiles, value);
    }

    public int SF
    {
        get => _sf;
        set => SetField(ref _sf, value);
    }

    public int SL
    {
        get => _sl;
        set => SetField(ref _sl, value);
    }

    public bool IsComboBoxEnabled
    {
        get => _isComboBoxEnabled;
        set => SetField(ref _isComboBoxEnabled, value);
    }

    public string Profile
    {
        get => _profile;
        set => SetField(ref _profile, value);
    }

    public ICommand EditSpacingCommand { set; get; }

    public ICommand SaveToJsonCommand { get; }

    public MainWindowVm()
    {
        EditSpacingCommand = new RelayCommand(_ =>
        {
            if (NumberOfPiles > 0)
            {
                var spacingEdit = new SpacingEdit(NumberOfPiles);
                spacingEdit.ShowDialog(); // Show() and ShowDialog()
                var spacingVm = (SpacingVm)spacingEdit.DataContext;
                _spacingItems = spacingVm.Spacings;

                var spacingsEqually = _spacingItems.All(s => Math.Abs(s.Value - _spacingItems[0].Value) < 1e-6);
                var totalDisplayText = spacingsEqually ? _spacingItems[0].Value.ToString() : "Vary";
                Interval = $"間隔 (mm)：{totalDisplayText}";
            }
            else
            {
                MessageBox.Show("正しい数値を入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }, _ => true);

        SaveToJsonCommand = new RelayCommand(_ => SaveToJson());
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

    private void SaveToJson()
    {
        // Save current VM data to JSON
        var saveData = new
        {
            Interval,
            HasTopPlate,
            NumberOfPiles,
            SF,
            SL,
            Profile,
            SpacingItems = _spacingItems
        };

        var json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });

        var dialog = new Microsoft.Win32.SaveFileDialog
        {
            FileName = "savedata.json",
            Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
        };

        if (dialog.ShowDialog() == true)
        {
            File.WriteAllText(dialog.FileName, json);
            MessageBox.Show($"データを保存しました: {dialog.FileName}", "完了", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}