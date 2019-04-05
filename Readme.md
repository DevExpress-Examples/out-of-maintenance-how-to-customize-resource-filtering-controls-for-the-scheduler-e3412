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


