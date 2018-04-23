using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using DevExpress.Xpf.Scheduler;
using DevExpress.XtraScheduler;

namespace SchedulerCustomizeResourcesControlsWpf {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
  
            GenerateResources();
        }

        private void GenerateResources() {
            scheduler.Storage.ResourceStorage.BeginUpdate();
            for (int i = 0; i < 5; i++)
            {
                Resource resource = scheduler.Storage.CreateResource(i);
                resource.Caption = "Resource" + i;
                scheduler.Storage.ResourceStorage.Add(resource);
            }
            scheduler.Storage.ResourceStorage[1].SetColor(System.Windows.Media.Colors.Blue);
            scheduler.Storage.ResourceStorage.EndUpdate();
        }
    }

    public class ResourceColorConverter : MarkupExtension, IValueConverter {
        static ResourceColorConverter instance = new ResourceColorConverter();
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return instance;
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            Resource resource = (Resource)value;
            System.Windows.Media.Color color = resource.GetColor();
            System.Windows.Media.Color emptyColor = new System.Windows.Media.Color();
            if (color == emptyColor)
            {
                SchedulerControl scheduler = (SchedulerControl)Application.Current.MainWindow.FindName("scheduler");
                SchedulerColorSchemaCollection colorSchemas = scheduler.GetResourceColorSchemasCopy();
                int resIndex = scheduler.Storage.ResourceStorage.Items.IndexOf(resource);

                color = colorSchemas[resIndex % colorSchemas.Count].Cell;
            }

            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
