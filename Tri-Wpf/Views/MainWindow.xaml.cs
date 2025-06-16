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
        DataContext = new MainWindowVm();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(PileCountTextBox.Text, out var count) && count > 0)
        {
            var spacingEdit = new SpacingEdit(count);
            spacingEdit.ShowDialog();
            
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