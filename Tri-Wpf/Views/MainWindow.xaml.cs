using System.Windows;
using Tri_Wpf.Models;
using Tri_Wpf.ViewModels;

namespace Tri_Wpf.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(PileCountTextBox.Text, out var count) && count > 0)
        {
            var editWindow = new SpacingEdit(count);
            editWindow.Closed += (s, args) =>
            {
                if (editWindow.DialogResult != true) return;
                var vm = (SpacingVm)editWindow.DataContext;
                var spacings = vm.Spacings;
                var spacingsEqually = spacings.All(s => Math.Abs(s.Value - spacings[0].Value) < 1e-6);
                var totalDisplayText = spacingsEqually ? spacings[0].Value.ToString() : "Vary";
                Interval.Text = $"間隔 (mm)：{totalDisplayText}";
            };
            editWindow.ShowDialog();
        }
        else
        {
            MessageBox.Show("正しい数値を入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
    
    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}