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
            TestMethod1();
        }

        private void TestButton1_Click(object sender, RoutedEventArgs e)
        {
            TestMethod1();
        }

        private void TestButton2_Click(object sender, RoutedEventArgs e)
        {
            TestMethod2();
        }

        private void TestButton3_Click(object sender, RoutedEventArgs e)
        {
            ThreadStart test3 = new ThreadStart(TestMethod3);
            Thread thread1 = new Thread(test3);
            thread1.Start();
        }

        private void TestMethod1()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                testInt++;
                TestLabel.Content = testInt;
                Thread.Sleep(1000);
            }
        }

        private void TestMethod2()
        {
            for (int i = 0; i < 3; i++)
            {
                testInt++;
                TestLabel.Content = testInt;
                Thread.Sleep(1000);
            }
        }

        private void TestMethod3()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                testInt++;
                this.Dispatcher.Invoke((Action)(() =>
                {
                    TestLabel.Content = testInt;
                }));
                Thread.Sleep(1000);
            }
        }
    }
}
