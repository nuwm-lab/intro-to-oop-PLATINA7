using System.Security.Cryptography;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Polynomial
        {
            private double a0, a1, a2, a3, e, a, b;

            public Polynomial(double _a0, double _a1, double _a2, double _a3, double _e, double _a, double _b)
            {
                a0 = _a0;
                a1 = _a1;
                a2 = _a2;
                a3 = _a3;
                e = _e;
                a = _a;
                b = _b;
            }

            public double Calculate()
            {
                double temp = a3 * a * a * a + a2 * a * a + a1 * a + a0;

                while (a <= b)
                {
                    a += e;
                    if (temp > a3 * a * a * a + a2 * a * a + a1 * a + a0)
                    {
                        temp = a3 * a * a * a + a2 * a * a + a1 * a + a0;
                    }
                }
                return temp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a0, a1, a2, a3, E, a, b;
            double.TryParse(textBox1.Text, out a3);
            double.TryParse(textBox2.Text, out a2);
            double.TryParse(textBox3.Text, out a1);
            double.TryParse(textBox4.Text, out a0);
            double.TryParse(textBox6.Text, out E);
            double.TryParse(textBox7.Text, out a);
            double.TryParse(textBox8.Text, out b);

            Polynomial first = new Polynomial(a0, a1, a2, a3, E, a, b);

            double asff = first.calculate();
            String ff = Convert.ToString(asff);
            label8.Text = ff;
        }
    }
}
