using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox Block = new TextBox();
            Block.Text = "Tie ir dati";
            this.DataContext = Block;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            btnTarget.Content = txtTextBox.Text;
            txtTextBox.Text = null;
        }

        private void txtTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        string? LastText = null;

        private void txtTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Key[] Allowed = new Key[] 
                { Key.D0, Key.D1, Key.Delete, Key.Back, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9 };

            int CursorPosition = ((TextBox)sender).SelectionStart;

            if (!Allowed.Any(x => x.Equals(e.Key))){
                ((TextBox)sender).Text = LastText;
                ((TextBox)sender).SelectionStart = CursorPosition-1;
            }

            LastText = ((TextBox)sender).Text;

        }

        private void txtTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            LastText = ((TextBox)sender).Text;
        }
    }
}
