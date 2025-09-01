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


    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}