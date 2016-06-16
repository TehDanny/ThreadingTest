using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int testInt;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void WindowKeyDown(object sender, KeyEventArgs e)
        {
            TestMethod();
        }

        private void TestMethod()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                testInt++;
                TestLabel.Content = testInt;
                Thread.Sleep(1000);
            }
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            TestMethod();
        }
    }
}
