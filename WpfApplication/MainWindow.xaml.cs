using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Line line = new Line
            {
                X1 = 10,
                Y1 = 10,
                X2 = 200,
                Y2 = 40,
                Stroke = Brushes.Red,
                StrokeThickness = 4
            };
            myGrid.Children.Add(line);
        }
        private double oldx, oldy;

        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X;
                double y = e.GetPosition(this).Y;
                double dx = x - oldx;
                double dy = y - oldy;
                this.Left += dx;
                this.Top += dy;

                oldx = x;
                oldy = y;
            }
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            oldx = e.GetPosition(this).X;
            oldy = e.GetPosition(this).Y;
        }
    }
}
