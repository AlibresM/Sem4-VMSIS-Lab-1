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

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Number a = new Number();
        Number b = new Number();
        Number d = new Number();
        public class Number
        {
            public string num;
            public int cc;

            char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

            
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        public int Tonum(string num, int cc, int el)
        {
            switch (num[el])
            {
                case '0':
                    return 0;
                    break;
                case '1':
                    return 1;
                    break;
                case '2':
                    return 2;
                    break;
                case '3':
                    return 3;
                    break;
                case '4':
                    return 4;
                    break;
                case '5':
                    return 5;
                    break;
                case '6':
                    return 6;
                    break;
                case '7':
                    return 7;
                    break;
                case '8':
                    return 8;
                    break;
                case '9':
                    return 9;
                    break;
                case 'A':
                    return 10;
                    break;
                case 'B':
                    return 11;
                    break;
                case 'C':
                    return 12;
                    break;
                case 'D':
                    return 13;
                    break;
                case 'E':
                    return 14;
                    break;
                case 'F':
                    return 15;
                    break;
                default:
                    return 10001;
                    break;
            }
            
        }
        public char Tochar(int s)
        {
            switch (s)
            {
                case 0:
                    return '0';
                    break;
                case 1:
                    return '1';
                    break;
                case 2:
                    return '2';
                    break;
                case 3:
                    return '3';
                    break;
                case 4:
                    return '4';
                    break;
                case 5:
                    return '5';
                    break;
                case 6:
                    return '6';
                    break;
                case 7:
                    return '7';
                    break;
                case 8:
                    return '8';
                    break;
                case 9:
                    return '9';
                    break;
                case 10:
                    return 'A';
                    break;
                case 11:
                    return 'B';
                    break;
                case 12:
                    return 'C';
                    break;
                case 13:
                    return 'D';
                    break;
                case 14:
                    return 'E';
                    break;
                case 15:
                    return 'F';
                    break;
                default:
                    return 'X';
                    break;
            }
        }
        public void Contoten(Number f)
        {
            int ccin = f.cc;
            string numin = f.num;
            int ccout = 10;
            string numout;
            int len = numin.Length;          
            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                sum = sum + Tonum(numin, ccin, i)*(int)Math.Pow((double)ccin, (double)(len - i - 1));
            }
                       
            d.cc = 10;
            d.num = sum.ToString();
            sum = 0;

            label2.Content = d.cc.ToString();
            label3.Content = d.num;
        }

        public void Confromten(Number f)
        {
            int ccin = f.cc;
            string numin = f.num;
            int ccout = int.Parse(ns2.Text);
            string numout;
            int len = numin.Length;

            int[] mas = new int[100];

            int num = int.Parse(numin);
            int s = 0;
            if (int.Parse(f.num) > ccout)
            {
                do
                {
                    mas[s] = num % ccout;
                    num = num / ccout;
                    s++;
                } while (num >= ccout);
            }
            mas[s] = num;
            

            string ans = "                         ";

            StringBuilder sb = new StringBuilder(ans);

            for (int i = 0; i <= s; i++)
            {
                sb[i] = Tochar(mas[s - i]);
            }

            ans = sb.ToString();

            b.cc = ccout;
            b.num = ans;
        }
      
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Number number = new Number();
                number.cc = int.Parse(ns1.Text);
                if (number.cc < 2 || number.cc > 16) throw new Exception();                            
                number.num = n1.Text;
                if (int.Parse(number.num) < 0) throw new Exception();
                for (int i = 0; i < number.num.Length; i++)
                {                   
                    if (Tonum(number.num, 0, i) >= number.cc) throw new Exception();
                }

                Contoten(number);
                Confromten(d);
                n2.Text = b.num;
                ns2.Text = b.cc.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong data!");
            }
        }
    }
}
