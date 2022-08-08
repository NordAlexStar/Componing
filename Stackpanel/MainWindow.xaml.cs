using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using MyFirstWpfApp;

namespace Stackpanel
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new StackpanelViewModel()
            {
                FirstPeople = new People() { Family = "Pupkin", Name = "Vasja" },
                SecondPeople = new People() { Name = "Aleksejs", Family = "Semjonovs" }
            };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
