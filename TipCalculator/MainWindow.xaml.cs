using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TipCalculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tip tip;
        public MainWindow()
        {
            InitializeComponent();
            tip = new Tip();
        }

        private void AmountLostFocus(object sender, RoutedEventArgs e)
        {
            //判断输入是否有效并将TextBox的值转为标准的金钱格式
            if (!double.TryParse(amount.Text, out double bill))
            {
                bill = 0;
            }
            amount.Text = string.Format("{0:C}", bill);
            Calculate();
        }

        private void AmountGotFocus(object sender, RoutedEventArgs e)
        {
            //将TextBox的值置空
            amount.Text = string.Empty;
        }

        private void ClickRadio(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private new void MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //当鼠标离开TextBox范围时使TextBox失去焦点并计算Tip
            vb.Focus();
            Calculate();
        }

        private void Calculate()
        {
            RadioButton selectedRadio = stackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            tip.CalculateTip(amount.Text, double.Parse(selectedRadio.Tag.ToString()));
            tips.Text = tip.TipAmount;
            total.Text = tip.TotalAmount;
        }
    }
}