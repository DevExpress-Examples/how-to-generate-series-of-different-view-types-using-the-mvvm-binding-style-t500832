#Region "#ChartViewCodeBehind"
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls

Namespace MvvmChart
    Partial Public Class MainWindow
        Inherits Window

        Private privateViewModel As DailyWeatherViewModel
        Public Property ViewModel() As DailyWeatherViewModel
            Get
                Return privateViewModel
            End Get
            Private Set(ByVal value As DailyWeatherViewModel)
                privateViewModel = value
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
            ViewModel = New DailyWeatherViewModel()
            DataContext = ViewModel

            AddHandler ViewModel.PropertyChanged, AddressOf OnViewModelPropertyChanged
        End Sub

        Private Sub OnViewModelPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            DataContext = Nothing
            DataContext = ViewModel
        End Sub
    End Class


    Friend Class WeatherTemplateSelector
        Inherits DataTemplateSelector

        Public Property AvgSeriesTemplate() As DataTemplate
        Public Property MinMaxSeriesTemplate() As DataTemplate

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim weatherItem As WeatherItem = TryCast(item, WeatherItem)
            If weatherItem Is Nothing Then
                Return Nothing
            End If

            Return If(weatherItem.IsSelected, MinMaxSeriesTemplate, AvgSeriesTemplate)
        End Function
    End Class
End Namespace
#End Region ' #ChartViewCodeBehind