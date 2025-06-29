using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tri_Wpf.Core;

namespace Tri_Wpf.Models;

public abstract class GirderStepItem(string pillarMaterial) : BaseViewModel
{
    private int _step;
    private string _pillarMaterial = pillarMaterial;

    public int Step
    {
        get => _step;
        set => SetField(ref _step, value);
    }

    public string PillarMaterial
    {
        get => _pillarMaterial;
        set => SetField(ref _pillarMaterial, value);
    }
}