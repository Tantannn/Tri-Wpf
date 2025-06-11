using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Tri_Wpf.Models;

namespace Tri_Wpf.Views
{
    public partial class SpacingEdit : Window
    {
        private readonly ObservableCollection<SpacingItem> _items;


        private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SpacingItem.Value))
            {
                UpdateTotal();
            }
        }

        private void UpdateTotal()
        {
            var total = _items?.Sum(x => x?.Value ?? 0) ?? 0;
            TotalText.Text = $"合計: {total} mm";
        }


        public SpacingEdit(int count)
        {
            InitializeComponent();
            _items = [];

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
                _items.Add(item);
            }

            SpacingGrid.ItemsSource = _items;
            UpdateTotal();
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