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
using CalculateLibrary;
using OxyPlot;

namespace IntegralSolution
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

        private void btOtrisovat_Click(object sender, RoutedEventArgs e) //обработчик события нажатия на кнопку
        {
            List<(double, int)> time = Calculate();
            DrawGraph(time);
        }

        private List<(double, int)> Calculate () // реализация обработчика
        {
            this.Cursor = Cursors.Wait;
            List<(double, int)> time = new List<(double, int)>();

            double a = Convert.ToDouble(tbLowerBound.Text);
            double b = Convert.ToDouble(tbUpperBound.Text);

            if (a > b)
            {
                throw new Exception("Нижнее значение больше, чем верхнее!");
            }
            long n = Convert.ToInt64(tbN.Text);
            if (n <= 0)
            {
                throw new Exception("Значение N меньше или равно 0");
            }

            ICalculator calculator = GetCalculator();

            for (int i = 0; i < n; i += 1000)
            {
                DateTime timeStart = DateTime.Now;
                calculator.Calculate(a, b, i, x => 11 * x - Math.Log(11 * x) - 2);
                DateTime timeStop = DateTime.Now;
                time.Add(((timeStop - timeStart).TotalMilliseconds, i));
            }

            this.Cursor = Cursors.Arrow;

            return time;
        }

        private ICalculator GetCalculator()
        {
            switch (cbmMethod.SelectedIndex)
            {
                case 0:
                    return new RectangleCalculator();
                case 1:
                    return new RectangleCalculatorParallel();
                case 2:
                    return new TrapCalculator();
                case 3:
                    return new TrapCalculatorParallel();
                default: 
                    return new RectangleCalculator();
            }
        }

        private void DrawGraph(List<(double, int)> times)
        {
            ClearGraph();
            MainViewModel model = DataContext as MainViewModel;
            model.Points.Clear();

            foreach (var (time, count) in times)
            {
                model.Points.Add(new DataPoint(count, time));
            }

            graph.InvalidatePlot(true);
            this.Cursor = Cursors.Arrow;
        }

        private void ClearGraph()
        {
            var model = DataContext as MainViewModel;
            model.Points.Clear();
            graph.InvalidatePlot(true);
        }

        private void btClean_Click(object sender, RoutedEventArgs e)
        {
            ClearGraph();
        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            double a = Convert.ToDouble(tbLowerBound.Text);
            double b = Convert.ToDouble(tbUpperBound.Text);

            if (a > b)
            {
                throw new Exception("Нижнее значение больше, чем верхнее!");
            }
            long n = Convert.ToInt64(tbN.Text);
            if (n <= 0)
            {
                throw new Exception("Значение N меньше или равно 0");
            }

            ICalculator calculator = GetCalculator();

            double result = 0.0;

            DateTime tn = DateTime.Now;
            result = calculator.Calculate(a, b, n, x => 11 * x - Math.Log(11 * x) - 2);
            DateTime tk = DateTime.Now;

            tbTime.Text = Convert.ToString((tk - tn).TotalSeconds);
            tbResult.Text = Convert.ToString(result);

            this.Cursor = Cursors.Arrow;
        }
    }
}
