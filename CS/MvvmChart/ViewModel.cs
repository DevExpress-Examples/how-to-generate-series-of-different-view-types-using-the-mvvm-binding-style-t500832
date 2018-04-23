#region #ViewModelAndModel

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Media;
using System.Xml.Linq;

namespace MvvmChart {
    public class DailyWeatherViewModel : INotifyPropertyChanged {
        const string vostokStationName = "Vostok Station";
        const string deathValleyName = "Death Valley, NV";
        static readonly Color coldColor = Color.FromArgb(255, 0, 0, 255);
        static readonly Color hotColor = Color.FromArgb(255, 255, 0, 0);

        readonly List<WeatherItem> weather;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<WeatherItem> Weather { get { return weather; } }

        WeatherItem selectedItem;
        public WeatherItem SelectedWeather {
            get { return selectedItem; }
            set {
                if(selectedItem == value) return;

                if(selectedItem != null)
                    selectedItem.IsSelected = false;

                selectedItem = value;

                if (value != null)
                    value.IsSelected = true;

                RaisePropertyChangedEvent("SelectedWeather");
            } }

        public DailyWeatherViewModel() {
            List<WeatherRecord> valleyData = LoadWeatherData("DeathValley.xml");
            List<WeatherRecord> vostokData = LoadWeatherData("VostokStation.xml");

            weather = new List<WeatherItem>() {
                new WeatherItem(valleyData, hotColor, deathValleyName),
                new WeatherItem(vostokData, coldColor, vostokStationName),
            };
        }

        List<WeatherRecord> LoadWeatherData(string fileName) {
            List<WeatherRecord> items = new List<WeatherRecord>();
            XDocument weatherDocument = XDocument.Load(String.Format("../../Data/{0}", fileName));
            foreach(XElement element in weatherDocument.Root.Elements("Weather")) {
                items.Add(WeatherRecord.Load(element));
            }
            return items;
        }

        void RaisePropertyChangedEvent(string propertyName) {
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class WeatherItem : INotifyPropertyChanged {
        int averageLineThickness = 2;
        bool isSelected = false;

        public int AverageLineThickness {
            get { return averageLineThickness; }
            set {
                averageLineThickness = value;
                RaisePropertyChanged("AverageLineThickness");
            }
        }

        public bool IsSelected {
            get { return isSelected; }
            set {
                if(isSelected == value) return;
                isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
        public List<WeatherRecord> Data { get; private set; }
        public Color Color { get; private set; }
        public string Name { get; private set; }


        public WeatherItem(List<WeatherRecord> data, Color color, string name) {
            this.Data = data;
            this.Color = color;
            this.Name = name;
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string propertyName) {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class WeatherRecord {
        public static WeatherRecord Load(XElement element) {
            CultureInfo culture = CultureInfo.InvariantCulture;
            DateTime date = DateTime.Parse(element.Attribute("Date").Value, culture);
            double min = Double.Parse(element.Attribute("Min").Value, culture);
            double max = Double.Parse(element.Attribute("Max").Value, culture);
            double avg = Double.Parse(element.Attribute("Avg").Value, culture);
            return new WeatherRecord(date, max, avg, min);
        }

        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }
        public double AvgValue { get; private set; }
        public DateTime Date { get; private set; }

        WeatherRecord(DateTime date, double maxValue, double avgValue, double minValue) {
            this.Date = date;
            this.MaxValue = maxValue;
            this.AvgValue = avgValue;
            this.MinValue = minValue;
        }
    }
}
#endregion #ViewModelAndModel
