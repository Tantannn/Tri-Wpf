using System.Windows;
using Tri_Wpf.ViewModels;

namespace Tri_Wpf.Views
{
    public partial class SpacingEdit : Window
    {
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is SpacingVm vm)
            {
                var spacings = vm.Spacings;
                var spacingsEqually = spacings.All(s => Math.Abs(s.Value - spacings[0].Value) < 1e-6);
                TotalDisplayText = spacingsEqually ? spacings[0].Value.ToString() : "Vary";
            }

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