using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.Threading.Tasks;
using System.Windows.Media;

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
        

        private async void TheButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            int max = (int)pb.Maximum;

            await Task.Run(() =>
             {
                 for (int i = 0; i < max; i++)
                 {
                     Dispatcher.Invoke(() => pb.Value = i);
                     Thread.Sleep(10);
                 }
             });
        }

        private void TheButton_Copy1_Click(object sender, RoutedEventArgs e)
        {
            theCanvas.Background = (Brush)this.TryFindResource("OtherBrush");

            string str = "Ценный текст";
            if (!Resources.Contains("ValuableString"))
            {
                Resources.Add("ValuableString", str);
            }
        }
    }
}
