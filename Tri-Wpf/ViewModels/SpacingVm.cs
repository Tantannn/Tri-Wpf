using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tri_Wpf.Core;
using Tri_Wpf.Models;

namespace Tri_Wpf.ViewModels;

public partial class SpacingVm : ObservableObject
{
    [ObservableProperty]
    private string _displayTotal;
    
    [ObservableProperty]
    private string _interval;
    
    [ObservableProperty]
    private List<SpacingItem> _currentItem;

    public List<SpacingItem> Spacings { get; set; }

    private readonly List<SpacingItem> _spacingSetA =
    [
        new() { Cmd = "A1", Value = 100 },
        new() { Cmd = "A2", Value = 200 }
    ];
    
    private readonly List<SpacingItem> _spacingSetB =
    [
        new() { Cmd = "B1", Value = 300 },
        new() { Cmd = "B2", Value = 400 }
    ];


    // if (int.TryParse(PileCountTextBox.Text, out var count) && count > 0)
    // {
    //     var spacingEdit = new SpacingEdit(count);
    //     spacingEdit.ShowDialog();
    // }
    // else
    // {
    //     MessageBox.Show("正しい数値を入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
    // }

    public SpacingVm(int count)
    {
        Spacings = [];
        
        CurrentItem = _spacingSetA;

        // // Generate items from S1-S2 up to S(n-1)-Sn
        // for (var i = 1; i < count; i++)
        // {
        //     var pair = $"S{i}-S{i + 1}";
        //     var item = new SpacingItem
        //     {
        //         Cmd = pair.ToUpper(),
        //         Value = 2000
        //     };
        //     item.PropertyChanged += OnItemPropertyChanged;
        //     Spacings.Add(item);
        // }

        UpdateTotal();
    }
    
    [RelayCommand]
    private void SwitchData()
    {
        CurrentItem = _spacingSetB;
    }

    // [RelayCommand]
    // private void ShowSetB() => _currentItem = _spacingSetB;
    
    private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SpacingItem.Value))
        {
            UpdateTotal();
        }
    }

    private void UpdateTotal()
    {
        var total = Spacings.Sum(x => x?.Value ?? 0);
        DisplayTotal = $"{total} mm";
    }
}