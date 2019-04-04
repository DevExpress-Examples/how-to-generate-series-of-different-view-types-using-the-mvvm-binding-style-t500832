<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml](./CS/MvvmChart/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MvvmChart/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/MvvmChart/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MvvmChart/MainWindow.xaml.vb))
* [ViewModel.cs](./CS/MvvmChart/ViewModel.cs) (VB: [ViewModel.vb](./VB/MvvmChart/ViewModel.vb))
<!-- default file list end -->
# How to generate Series of different view types using the MVVM binding style


<p>This example demonstrates how to generate different Series from a view model. Note that you can bind secondary axes and custom labels using the same approach. The XYDiagram2D.<strong>SeriesItemsSource </strong>property defines a collection of objects used to generate Series. To configure how the series view model is converted to a series on a chart, use the XYDiagram2D.<strong>SeriesItemTemplateSelector</strong> property.<br><br>See also: <a href="https://www.devexpress.com/Support/Center/p/T513360">How to generate Series of identical view types using the MVVM binding style</a>.</p>


<h3>Description</h3>

<p>To bind series view models to a chart, use the SeriesItemsSource property of a diagram. To configure how the series view model converts to a series on a chart, use SeriesItemTemplate or SeriesItemTemplateSelector. In this example, the Template Selector is used to convert the selected series type from Line to Range Area.</p>

<br/>


