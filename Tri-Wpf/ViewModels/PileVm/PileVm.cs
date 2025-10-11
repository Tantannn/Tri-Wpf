using System.Globalization;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tri_Wpf.Core;
using Tri_Wpf.Models;
using Tri_Wpf.Views;

namespace Tri_Wpf.ViewModels.PileVm;

public partial class PileVm : ObservableObject
{
    [ObservableProperty] private bool _hasTopPlate = false;

    [ObservableProperty] private static List<string> _topPlateOptions = new()
    {
        "PL-400×16×400",
        "PL-400×16×40"
    };

    [ObservableProperty] private int _numberOfPiles;
    [ObservableProperty] private static List<string> _angle = ["0", "90"];
    [ObservableProperty] private string? _selectedTopPlate = _topPlateOptions[0];
    [ObservableProperty] private IList<SpacingItem> _spacingItems;
    [ObservableProperty] private string _interval;

    [RelayCommand]
    private void EditSpacing()
    {
        var spacingEdit = new SpacingEdit(1);
        spacingEdit.ShowDialog();

        // if (result == true && spacingEdit.DataContext is SpacingVm spacingVm)
        // {
        //     SpacingItems = spacingVm.Spacings;
        //
        //     bool spacingsEqually = SpacingItems.All(s =>
        //         Math.Abs(s.Value - SpacingItems[0].Value) < 1e-6);
        //
        //     string totalDisplayText = spacingsEqually
        //         ? SpacingItems[0].Value.ToString(CultureInfo.InvariantCulture)
        //         : "Vary";
        //
        //     Interval = $"間隔 (mm)：{totalDisplayText}";
        // }
    }

    public PileVm()
    {
    }
}