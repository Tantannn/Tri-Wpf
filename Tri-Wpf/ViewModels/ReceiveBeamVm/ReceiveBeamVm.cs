using System.ComponentModel;
using System.Windows.Input;
using Tri_Wpf.Core;
using Tri_Wpf.Models;

namespace Tri_Wpf.ViewModels.ReceiveBeamVm;

public class ReceiveBeamVm : BaseViewModel
{
    public ICommand GirderStepCommand { set; get; }

    public ReceiveBeamVm()
    {
        // GirderSteps = girderSteps;
        // GirderStepCommand = girderStepCommand;

        GirderSteps = [];


        var item = new GirderStepItem
            {
                Step = 1, 
                PillarMaterial= "asb"
            };

        item.PropertyChanged += OnItemPropertyChanged;
        GirderSteps.Add(item);
        GirderSteps.Add(item);
        GirderSteps.Add(item);
        GirderSteps.Add(item);
    }
    
    private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SpacingItem.Value))
        {
        }
    }

    public List<GirderStepItem> GirderSteps { get; set; }
}