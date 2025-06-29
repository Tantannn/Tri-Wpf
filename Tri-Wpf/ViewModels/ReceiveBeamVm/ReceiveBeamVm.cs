using System.Windows.Input;
using Tri_Wpf.Core;
using Tri_Wpf.Models;

namespace Tri_Wpf.ViewModels.ReceiveBeamVm;

public class ReceiveBeamVm: BaseViewModel
{
    
    public ICommand GirderStepCommand { set; get; }
    public ReceiveBeamVm(List<GirderStepItem> girderSteps, ICommand girderStepCommand)
    {
        GirderSteps = girderSteps;
        GirderStepCommand = girderStepCommand;
    }

    public List<GirderStepItem> GirderSteps { get; set; }
    
}