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

        GirderSteps = new List<GirderStepItem>();

        // Add 4 sample items (last one will be disabled)
        for (int i = 1; i <= 4; i++)
        {
            var item = new GirderStepItem
            {
                Step = i,
                PillarMaterial = $"Material-{i}",
                IsLastRow = (i == 4) // Mark last item
            };
            GirderSteps.Add(item);
        }
    }

    private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SpacingItem.Value))
        {
        }
    }

    public List<GirderStepItem> GirderSteps { get; set; }
}