using System.Windows;
using Tri_Wpf.Models;

namespace Tri_Wpf.Views
{
    public partial class SpacingEdit : Window
    {
        public SpacingEdit(int count)
        {
            InitializeComponent();

            var items = new List<SpacingItem>();

            for (var i = 1; i < count; i++) // correct: from s1-s2 up to s(n-1)-sn
            {
                var pair = $"s{i}-s{i + 1}";
                items.Add(new SpacingItem { Cmd = pair, Value = "" });
            }

            SpacingGrid.ItemsSource = items; // assumes you have a DataGrid named SpacingGrid in your XAML
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle apply logic (e.g., save data)
            this.DialogResult = true;
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}