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
using System.IO.Ports;

namespace AudioSpectrum
{
    public partial class MainWindow : Window
    {
        private Analyzer _analyzer;

        public MainWindow()
        {
            InitializeComponent();
            _analyzer = new Analyzer(PbL, PbR, Spectrum, DeviceBox);
        }

        private void BtnEnable_Click(object sender, RoutedEventArgs e)
        {
            if (BtnEnable.IsChecked == true)
            {
                BtnEnable.Content = "OFF";
                _analyzer.Enable = true;
            }
            else
            {
                BtnEnable.Content = "ON";
                _analyzer.Enable = false;
            }
        }

        private void Comports_DropDownOpened(object sender, EventArgs e)
        {
        }

        private void CkbDisplay_Click(object sender, RoutedEventArgs e)
        {
            _analyzer.DisplayEnable = (bool)CkbDisplay.IsChecked;
        }

        private void DeviceBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
