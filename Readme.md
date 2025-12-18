<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128569950/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T500832)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Chart for WPF - Use the MVVM Binding Style to Generate Series of Different View Types 

This example generates different Series from a view model. Clicking on a series changes its type from Line to Range Area.

![Chart](./images/chart.png)

## Implementation Details

The `XYDiagram2D.SeriesItemsSource` property defines a collection of objects used to generate Series. To bind series view models to a chart, use the `SeriesItemsSource` property of a diagram. To configure how the series view model converts to a series on a chart, use `SeriesItemTemplate` or `SeriesItemTemplateSelector`. In this example, the Template Selector converts the selected series type from Line to Range Area.

Note that you can bind secondary axes and custom labels using the same approach. 

## Files to Review

<!-- default file list -->

* **[MainWindow.xaml](./CS/MvvmChart/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MvvmChart/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/MvvmChart/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MvvmChart/MainWindow.xaml.vb))
* [ViewModel.cs](./CS/MvvmChart/ViewModel.cs) (VB: [ViewModel.vb](./VB/MvvmChart/ViewModel.vb))
<!-- default file list end -->
## More Examples

[Chart for WPF - Use the MVVM Binding Style to Generate Series of an Identical View Type](https://github.com/DevExpress-Examples/wpf-charts-create-multiple-series-of-identical-view-mvvm)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-chart-generate-different-series-view-types-using-mvvm&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-chart-generate-different-series-view-types-using-mvvm&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
