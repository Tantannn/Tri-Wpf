using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Tri_Wpf.Commands;
using Tri_Wpf.Core;
using Tri_Wpf.Extentions;
using Tri_Wpf.Models;

namespace Tri_Wpf.ViewModels.ReceiveBeamVm;

public class ReceiveBeamVm : BaseViewModel
{
    public ICommand GirderStepCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand MoveUpCommand { get; }
    public ICommand MoveDownCommand { get; }

    private GirderStepItem _selectedItem;

    public GirderStepItem SelectedItem
    {
        get => _selectedItem;
        set => SetField(ref _selectedItem, value);
    }

    public ReceiveBeamVm()
    {
        GirderSteps = [];

        // Initialize commands
        AddCommand = new RelayCommand(_ => AddItem());
        DeleteCommand = new RelayCommand(_ => DeleteItem());
        GirderStepCommand = new RelayCommand(ExecuteGirderStep);
        MoveUpCommand = new RelayCommand(_ => MoveUp());
        MoveDownCommand = new RelayCommand(_ => MoveDown());
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

    private static void ExecuteGirderStep(object parameter)
    {
        if (parameter is not GirderStepItem item) return;
        Debug.WriteLine($"Executing command for step {item.Step}");
        var statusMessage = $"Executed Step {item.Step} (Material: {item.PillarMaterial})";
        MessageBoxExtension.ShowOk(statusMessage, item.PillarMaterial);
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
        if (SelectedItem.IsLastRow) return;
        GirderSteps.Remove(SelectedItem);
        UpdateStepNumbers();
    }
    
    private void MoveUp()
    {
        var index = GirderSteps.IndexOf(SelectedItem);
        if (index <= 0 && index != GirderSteps.Count - 1) return;
        GirderSteps.Move(index, index - 1);
        UpdateStepNumbers();
    }

    private void MoveDown()
    {
        var index = GirderSteps.IndexOf(SelectedItem);
        if (index > GirderSteps.Count - 3) return;
        GirderSteps.Move(index, index + 1);
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

    public ObservableCollection<GirderStepItem> GirderSteps { get; }
}