using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DockPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type? PanelType = ((FrameworkElement)sender).Tag as Type;

            var childrn = (this.Content as Panel).Children;
            Panel NewPanel = (Panel)Activator.CreateInstance(PanelType ?? typeof(Grid));
            foreach (var item in childrn.OfType<UIElement>().ToList())
            {
                (this.Content as Panel).Children.Remove(item as UIElement);
                NewPanel.Children.Add(item as UIElement);
            }

            this.Content = NewPanel;

        }
    }
}
