using System.Windows;
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

        private void TheButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBlock != null)
                textBlock.Text = ((ToggleButton)sender).IsChecked.ToString();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not null)
            { 
                textBlock1.Text = "Clicked";
               
            }
        }

        private void RepeatButton_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is not null)
            {
                textBlock1.Text = "";

            }
        }
    }
}
