<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128569950/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T500832)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
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


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-generate-series-of-different-view-types-using-the-mvvm-binding-style-t500832&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-generate-series-of-different-view-types-using-the-mvvm-binding-style-t500832&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
