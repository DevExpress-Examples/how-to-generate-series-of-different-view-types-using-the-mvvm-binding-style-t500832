#Region "#ViewModelAndModel"

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Media
Imports System.Xml.Linq

Namespace MvvmChart
    Public Class DailyWeatherViewModel
        Implements INotifyPropertyChanged

        Private Const vostokStationName As String = "Vostok Station"
        Private Const deathValleyName As String = "Death Valley, NV"
        Private Shared ReadOnly coldColor As Color = Color.FromArgb(255, 0, 0, 255)
        Private Shared ReadOnly hotColor As Color = Color.FromArgb(255, 255, 0, 0)


        Private ReadOnly weather_Renamed As List(Of WeatherItem)

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Public ReadOnly Property Weather() As List(Of WeatherItem)
            Get
                Return weather_Renamed
            End Get
        End Property

        Private selectedItem As WeatherItem
        Public Property SelectedWeather() As WeatherItem
            Get
                Return selectedItem
            End Get
            Set(ByVal value As WeatherItem)
                If selectedItem Is value Then
                    Return
                End If

                If selectedItem IsNot Nothing Then
                    selectedItem.IsSelected = False
                End If

                selectedItem = value

                If value IsNot Nothing Then
                    value.IsSelected = True
                End If

                RaisePropertyChangedEvent("SelectedWeather")
            End Set
        End Property

        Public Sub New()
            Dim valleyData As List(Of WeatherRecord) = LoadWeatherData("DeathValley.xml")
            Dim vostokData As List(Of WeatherRecord) = LoadWeatherData("VostokStation.xml")

            weather_Renamed = New List(Of WeatherItem)() From { _
                New WeatherItem(valleyData, hotColor, deathValleyName), _
                New WeatherItem(vostokData, coldColor, vostokStationName) _
            }
        End Sub

        Private Function LoadWeatherData(ByVal fileName As String) As List(Of WeatherRecord)
            Dim items As New List(Of WeatherRecord)()
            Dim weatherDocument As XDocument = XDocument.Load(String.Format("../../Data/{0}", fileName))
            For Each element As XElement In weatherDocument.Root.Elements("Weather")
                items.Add(WeatherRecord.Load(element))
            Next element
            Return items
        End Function

        Private Sub RaisePropertyChangedEvent(ByVal propertyName As String)
            Dim handler = PropertyChangedEvent
            If handler IsNot Nothing Then
                handler.Invoke(Me, New PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class

    Public Class WeatherItem
        Implements INotifyPropertyChanged


        Private averageLineThickness_Renamed As Integer = 2

        Private isSelected_Renamed As Boolean = False

        Public Property AverageLineThickness() As Integer
            Get
                Return averageLineThickness_Renamed
            End Get
            Set(ByVal value As Integer)
                averageLineThickness_Renamed = value
                RaisePropertyChanged("AverageLineThickness")
            End Set
        End Property

        Public Property IsSelected() As Boolean
            Get
                Return isSelected_Renamed
            End Get
            Set(ByVal value As Boolean)
                If isSelected_Renamed = value Then
                    Return
                End If
                isSelected_Renamed = value
                RaisePropertyChanged("IsSelected")
            End Set
        End Property
        Private privateData As List(Of WeatherRecord)
        Public Property Data() As List(Of WeatherRecord)
            Get
                Return privateData
            End Get
            Private Set(ByVal value As List(Of WeatherRecord))
                privateData = value
            End Set
        End Property
        Private privateColor As Color
        Public Property Color() As Color
            Get
                Return privateColor
            End Get
            Private Set(ByVal value As Color)
                privateColor = value
            End Set
        End Property
        Private privateName As String
        Public Property Name() As String
            Get
                Return privateName
            End Get
            Private Set(ByVal value As String)
                privateName = value
            End Set
        End Property


        Public Sub New(ByVal data As List(Of WeatherRecord), ByVal color As Color, ByVal name As String)
            Me.Data = data
            Me.Color = color
            Me.Name = name
        End Sub
        #Region "INotifyPropertyChanged Members"
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Private Sub RaisePropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
        #End Region
    End Class

    Public Class WeatherRecord
        Public Shared Function Load(ByVal element As XElement) As WeatherRecord
            Dim culture As CultureInfo = CultureInfo.InvariantCulture

            Dim date_Renamed As Date = Date.Parse(element.Attribute("Date").Value, culture)
            Dim min As Double = Double.Parse(element.Attribute("Min").Value, culture)
            Dim max As Double = Double.Parse(element.Attribute("Max").Value, culture)
            Dim avg As Double = Double.Parse(element.Attribute("Avg").Value, culture)
            Return New WeatherRecord(date_Renamed, max, avg, min)
        End Function

        Private privateMinValue As Double
        Public Property MinValue() As Double
            Get
                Return privateMinValue
            End Get
            Private Set(ByVal value As Double)
                privateMinValue = value
            End Set
        End Property
        Private privateMaxValue As Double
        Public Property MaxValue() As Double
            Get
                Return privateMaxValue
            End Get
            Private Set(ByVal value As Double)
                privateMaxValue = value
            End Set
        End Property
        Private privateAvgValue As Double
        Public Property AvgValue() As Double
            Get
                Return privateAvgValue
            End Get
            Private Set(ByVal value As Double)
                privateAvgValue = value
            End Set
        End Property

        Private privateDate As Date
        Public Property [Date]() As Date
            Get
                Return privateDate
            End Get
            Private Set(ByVal value As Date)
                privateDate = value
            End Set
        End Property

        Private Sub New(ByVal [date] As Date, ByVal maxValue As Double, ByVal avgValue As Double, ByVal minValue As Double)
            Me.Date = [date]
            Me.MaxValue = maxValue
            Me.AvgValue = avgValue
            Me.MinValue = minValue
        End Sub
    End Class
End Namespace
#End Region ' #ViewModelAndModel
