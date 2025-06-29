using System.Windows;

namespace Tri_Wpf.Extentions;

public abstract class MessageBoxExtension
{
    public static void ShowOk(string mes, string cap)
    {
        MessageBox.Show(mes, cap, MessageBoxButton.OK, MessageBoxImage.Information);
    }
}