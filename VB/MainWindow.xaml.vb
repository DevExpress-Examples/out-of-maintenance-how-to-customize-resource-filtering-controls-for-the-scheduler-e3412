Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Markup
Imports System.Windows.Media
Imports DevExpress.Xpf.Scheduler
Imports DevExpress.XtraScheduler

Namespace SchedulerCustomizeResourcesControlsWpf
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()

			GenerateResources()
		End Sub

		Private Sub GenerateResources()
			scheduler.Storage.ResourceStorage.BeginUpdate()
			For i As Integer = 0 To 4
				Dim resource As Resource = scheduler.Storage.CreateResource(i)
				resource.Caption = "Resource" & i
				scheduler.Storage.ResourceStorage.Add(resource)
			Next i
			scheduler.Storage.ResourceStorage(1).SetColor(System.Windows.Media.Colors.Blue)
			scheduler.Storage.ResourceStorage.EndUpdate()
		End Sub
	End Class

	Public Class ResourceColorConverter
		Inherits MarkupExtension
		Implements IValueConverter

		Private Shared instance As New ResourceColorConverter()
		Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
			Return instance
		End Function

		#Region "IValueConverter Members"

		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim resource As Resource = DirectCast(value, Resource)
			Dim color As System.Windows.Media.Color = resource.GetColor()
			Dim emptyColor As New System.Windows.Media.Color()
			If color = emptyColor Then
				Dim scheduler As SchedulerControl = DirectCast(Application.Current.MainWindow.FindName("scheduler"), SchedulerControl)
				Dim colorSchemas As SchedulerColorSchemaCollection = scheduler.GetResourceColorSchemasCopy()
				Dim resIndex As Integer = scheduler.Storage.ResourceStorage.Items.IndexOf(resource)

				color = colorSchemas(resIndex Mod colorSchemas.Count).Cell
			End If

			Dim brush As New SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B))

			Return brush
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function

		#End Region
	End Class
End Namespace
