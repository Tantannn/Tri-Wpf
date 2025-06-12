using System.Windows;

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
            if (editWindow.ShowDialog() == true)
            {
                // Access the total after dialog closes
                var total = editWindow.TotalValue;
                Interval.Text = $"間隔 (mm)：{total} mm";
            }

            editWindow.ShowDialog();
        }
        else
        {
            MessageBox.Show("正しい数値を入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}