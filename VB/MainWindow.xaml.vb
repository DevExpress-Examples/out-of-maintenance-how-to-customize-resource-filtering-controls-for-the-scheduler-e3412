Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Markup
Imports System.Windows.Media
Imports DevExpress.Xpf.Scheduler
Imports DevExpress.XtraScheduler

Namespace SchedulerCustomizeResourcesControlsWpf

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            GenerateResources()
        End Sub

        Private Sub GenerateResources()
            Me.scheduler.Storage.ResourceStorage.BeginUpdate()
            For i As Integer = 0 To 5 - 1
                Dim resource As Resource = Me.scheduler.Storage.CreateResource(i)
                resource.Caption = "Resource" & i
                Me.scheduler.Storage.ResourceStorage.Add(resource)
            Next

            Me.scheduler.Storage.ResourceStorage(1).SetColor(Colors.Blue)
            Me.scheduler.Storage.ResourceStorage.EndUpdate()
        End Sub
    End Class

    Public Class ResourceColorConverter
        Inherits MarkupExtension
        Implements IValueConverter

        Private Shared instance As ResourceColorConverter = New ResourceColorConverter()

        Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return instance
        End Function

'#Region "IValueConverter Members"
        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim resource As Resource = CType(value, Resource)
            Dim color As Color = resource.GetColor()
            Dim emptyColor As Color = New Color()
            If color = emptyColor Then
                Dim scheduler As SchedulerControl = CType(Application.Current.MainWindow.FindName("scheduler"), SchedulerControl)
                Dim colorSchemas As SchedulerColorSchemaCollection = scheduler.GetResourceColorSchemasCopy()
                Dim resIndex As Integer = scheduler.Storage.ResourceStorage.Items.IndexOf(resource)
                color = colorSchemas(resIndex Mod colorSchemas.Count).Cell
            End If

            Dim brush As SolidColorBrush = New SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B))
            Return brush
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
'#End Region
    End Class
End Namespace
