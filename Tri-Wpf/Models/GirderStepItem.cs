using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tri_Wpf.Core;

namespace Tri_Wpf.Models;

public  class GirderStepItem() : BaseViewModel
{
    private int _step;
    private string _pillarMaterial = "black";

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

    public bool IsLastRow { get; set; }
}