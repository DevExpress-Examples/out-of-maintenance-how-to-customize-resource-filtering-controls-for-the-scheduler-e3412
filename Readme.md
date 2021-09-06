<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128656974/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3412)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
<!-- default file list end -->
# How to customize resource filtering controls for the scheduler


<p>This example illustrates how to customize presentation of items in the all resource filtering controls:</p><p><a href="http://documentation.devexpress.com/#WPF/clsDevExpressXpfSchedulerUIResourcesComboBoxControltopic"><u>ResourcesComboBoxControl</u></a><br />
<a href="http://documentation.devexpress.com/#WPF/clsDevExpressXpfSchedulerUIResourcesPopupCheckedListBoxControltopic"><u>ResourcesPopupCheckedListBoxControl</u></a><br />
<a href="http://documentation.devexpress.com/#WPF/clsDevExpressXpfSchedulerUIResourcesCheckedListBoxControltopic"><u>ResourcesCheckedListBoxControl</u></a></p><p>To accomplish this task you can define a single <strong>ItemTemplate</strong> for all these controls. Note how the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfSchedulerSchedulerControl_GetResourceColorSchemasCopytopic"><u>SchedulerControl.GetResourceColorSchemasCopy Method</u></a> (in the ResourceColorConverter.Convert() method) is used to obtain copies of color schemas that are currently used to paint visible resources.</p>

<br/>


