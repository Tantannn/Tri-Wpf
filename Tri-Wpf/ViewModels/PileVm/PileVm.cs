using CommunityToolkit.Mvvm.ComponentModel;
using Tri_Wpf.Core;

namespace Tri_Wpf.ViewModels.PileVm;

public partial class PileVm : ObservableObject
{
    [ObservableProperty] private bool _hasTopPlate = false;

    [ObservableProperty] private static List<string> _topPlateOptions = new()
    {
        "PL-400×16×400",
        "PL-400×16×40"
    };

    [ObservableProperty] private static List<string> _angle = ["0", "90"];

    [ObservableProperty] private string? _selectedTopPlate = _topPlateOptions[0];

    public PileVm()
    {
    }
}