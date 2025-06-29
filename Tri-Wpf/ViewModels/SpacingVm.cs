using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tri_Wpf.Core;
using Tri_Wpf.Models;

namespace Tri_Wpf.ViewModels;

public sealed class SpacingVm : BaseViewModel
{
    private string _displayTotal;

    private string _interval;

    public string Interval
    {
        get => _interval;
        set => SetField(ref _interval, value);
    }

    public List<SpacingItem> Spacings { get; set; }

    public string DisplayTotal
    {
        get => _displayTotal;
        private set => SetField(ref _displayTotal, value);
    }


    // if (int.TryParse(PileCountTextBox.Text, out var count) && count > 0)
    // {
    //     var spacingEdit = new SpacingEdit(count);
    //     spacingEdit.ShowDialog();
    // }
    // else
    // {
    //     MessageBox.Show("正しい数値を入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
    // }

    public SpacingVm(int count)
    {
        Spacings = [];

        // Generate items from S1-S2 up to S(n-1)-Sn
        for (var i = 1; i < count; i++)
        {
            var pair = $"S{i}-S{i + 1}";
            var item = new SpacingItem
            {
                Cmd = pair.ToUpper(),
                Value = 2000
            };
            item.PropertyChanged += OnItemPropertyChanged;
            Spacings.Add(item);
        }

        UpdateTotal();
    }

    private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SpacingItem.Value))
        {
            UpdateTotal();
        }
    }

    private void UpdateTotal()
    {
        var total = Spacings.Sum(x => x?.Value ?? 0);
        DisplayTotal = $"{total} mm";
    }
}