#region #ChartViewCodeBehind
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MvvmChart {
    public partial class MainWindow : Window {
        public DailyWeatherViewModel ViewModel { get; private set; }

        public MainWindow() {
            InitializeComponent();
            ViewModel = new DailyWeatherViewModel();
            DataContext = ViewModel;

            ViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
            DataContext = null;
            DataContext = ViewModel;
        }
    }


    class WeatherTemplateSelector : DataTemplateSelector {
        public DataTemplate AvgSeriesTemplate { get; set; }
        public DataTemplate MinMaxSeriesTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            WeatherItem weatherItem = item as WeatherItem;
            if(weatherItem == null) return null;

            return weatherItem.IsSelected ? MinMaxSeriesTemplate : AvgSeriesTemplate;
        }
    }
}
#endregion #ChartViewCodeBehind