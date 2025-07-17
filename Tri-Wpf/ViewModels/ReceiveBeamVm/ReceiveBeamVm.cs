using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Tri_Wpf.Commands;
using Tri_Wpf.Core;
using Tri_Wpf.Models;

namespace Tri_Wpf.ViewModels.ReceiveBeamVm;

public class ReceiveBeamVm : BaseViewModel
{
    public ICommand GirderStepCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }

    private GirderStepItem _selectedItem;

    public GirderStepItem SelectedItem
    {
        get => _selectedItem;
        set => SetField(ref _selectedItem, value);
    }

    public ReceiveBeamVm()
    {
        GirderSteps = new ObservableCollection<GirderStepItem>();

        // Initialize commands
        AddCommand = new RelayCommand(_ => AddItem());
        DeleteCommand = new RelayCommand(_ => DeleteItem());
        GirderStepCommand = new RelayCommand(ExecuteGirderStep);

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

    private void ExecuteGirderStep(object parameter)
    {
        // Implement your command logic here
        if (parameter is GirderStepItem item)
        {
            Debug.WriteLine($"Executing command for step {item.Step}");
        }
    }

    private void AddItem()
    {
        Debug.WriteLine("AddItem executed");
        var newItem = new GirderStepItem
        {
            Step = GirderSteps.Count + 1,
            // IsLastRow = GirderSteps.Count + 1,
            PillarMaterial = "New Material"
        };
        GirderSteps.Add(newItem);
        UpdateStepNumbers();
    }

    private void DeleteItem()
    {
        if (SelectedItem != null && SelectedItem.IsLastRow == false)
        {
            GirderSteps.Remove(SelectedItem);
            UpdateStepNumbers();
        }
    }

    private void UpdateStepNumbers()
    {
        for (int i = 0; i < GirderSteps.Count; i++)
        {
            GirderSteps[i].Step = i + 1;
            GirderSteps[i].IsLastRow = (i == GirderSteps.Count - 1);
        }
    }

    public ObservableCollection<GirderStepItem> GirderSteps { get; }
}