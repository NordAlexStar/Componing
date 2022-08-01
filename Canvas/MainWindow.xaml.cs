using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Canvas
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


        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not null)
            {

                ((FrameworkElement)((ContentControl)sender).Content).Visibility = Visibility.Visible;

            }
        }

        private void RepeatButton_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is not null)
            {
                ((FrameworkElement)((ContentControl)sender).Content).Visibility = Visibility.Collapsed;

            }
        }
    }
}
