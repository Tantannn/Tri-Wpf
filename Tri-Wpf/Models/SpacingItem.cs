using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tri_Wpf.Core;

namespace Tri_Wpf.Models;

public class SpacingItem : BaseViewModel
{
    private string _cmd;
    private double _value;

    public string Cmd
    {
        get => _cmd;
        set => SetField(ref _cmd, value);
    }

    public double Value
    {
        get => _value;
        set => SetField(ref _value, value);
    }
}