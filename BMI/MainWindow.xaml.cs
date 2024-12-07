using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BMI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            rect1.Fill = Brushes.LightYellow;
            rect2.Fill = Brushes.LightGreen;
            rect3.Fill = Brushes.Orange;
            rect4.Fill = Brushes.OrangeRed;
            rect5.Fill = new SolidColorBrush(Color.FromRgb(243, 25, 25));

        }
        private void btnCal_Click(object sender, RoutedEventArgs e)
        {
            if (txtHeight.Text.Trim().Length == 0 && txtWeight.Text.Trim().Length == 0)
            {
                MessageBox.Show("กรุณากรอกส่วนสุง และน้ำหนัก");
                return;
            }
            else if (txtHeight.Text.Trim().Length == 0)
            {
                MessageBox.Show("กรุณากรอกส่วนสุง");
                return;
            }
            else if (txtWeight.Text.Trim().Length == 0)
            {
                MessageBox.Show("กรุณากรอกน้ำหนัก");
                return;
            }
            
            Body();
        }

        private void Body()
        {
            double h = double.Parse(txtHeight.Text);
            double w = double.Parse(txtWeight.Text);
            double y = Math.Pow(h/100,2);
            double b = w / y;
            lblBmi.Content = b.ToString("N2");

            if (b<18.5)
            {
                lblStatus.Content = ("ผอม");
                rect.Fill = Brushes.LightYellow;
            }
            else if (b>18.5 && b <=22.9)
            {
                lblStatus.Content = ("ปกติ");
                rect.Fill = Brushes.LightGreen;
            }
            else if(b>23 && b<=24.9)
            {
                lblStatus.Content = ("น้ำหนักเกิน");
                rect.Fill = Brushes.Orange;
            }
            else if (b > 25 && b <= 29.9)
            {
                lblStatus.Content = ("โรคอ้วน");
                rect.Fill = Brushes.OrangeRed;
            }
            else 
            {
                lblStatus.Content = ("อ้วนอันตราย");
                rect.Fill = new SolidColorBrush(Color.FromRgb(243, 25, 25));
            }


        }

        private void txtHeight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtWeight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtHeight.Text = "";
            txtWeight.Text = "";
            rect.Fill = Brushes.White;
            lblBmi.Content = "";
            lblStatus.Content = "";
        }
    }
}
