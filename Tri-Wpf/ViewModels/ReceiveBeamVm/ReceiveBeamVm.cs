using System.ComponentModel;
using System.Windows.Input;
using Tri_Wpf.Commands;
using Tri_Wpf.Core;
using Tri_Wpf.Models;

namespace Tri_Wpf.ViewModels.ReceiveBeamVm;

public class ReceiveBeamVm : BaseViewModel
{
    public ICommand GirderStepCommand { set; get; }
    public ICommand AddCommand { get; }

    public ReceiveBeamVm()
    {
        GirderSteps = new List<GirderStepItem>();

        // Initialize commands
        AddCommand = new RelayCommand(_ => AddItem());

        // Add sample data
        for (int i = 1; i <= 4; i++)
        {
            var item = new GirderStepItem
            {
                Step = i,
                PillarMaterial = $"Material-{i}",
                IsLastRow = (i == 4)
            };
            GirderSteps.Add(item);
        }
    }

    private void AddItem()
    {
        var newItem = new GirderStepItem
        {
            Step = GirderSteps.Count + 1,
            PillarMaterial = "New Material"
        };
        GirderSteps.Add(newItem);
        UpdateStepNumbers();
    }

    private void UpdateStepNumbers()
    {
        for (int i = 0; i < GirderSteps.Count; i++)
        {
            GirderSteps[i].Step = i + 1;
            GirderSteps[i].IsLastRow = (i == GirderSteps.Count - 1);
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