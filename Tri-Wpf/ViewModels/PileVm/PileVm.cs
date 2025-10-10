using CommunityToolkit.Mvvm.ComponentModel;
using Tri_Wpf.Core;

namespace Tri_Wpf.ViewModels.PileVm;

public partial class PileVm : ObservableObject
{
    [ObservableProperty] private bool _hasTopPlate = false;

    [ObservableProperty] private List<string> _topPlateOptions = new()
    {
        "PL-400×16×400",
        "PL-400×16×40"
    };

    [ObservableProperty] private string? _selectedTopPlate;

    public PileVm()
    {
    }
}