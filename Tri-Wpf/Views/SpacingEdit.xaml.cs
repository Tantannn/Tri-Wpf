using System.Windows;
using Tri_Wpf.ViewModels;

namespace Tri_Wpf.Views
{
    public partial class SpacingEdit : Window
    {
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = true;
            this.Close();
        }


        public SpacingEdit(int count)
        {
            InitializeComponent();
            DataContext = new SpacingVm(count);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}