using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RxWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var textChangeObserver = Observable
                .FromEventPattern<KeyEventHandler, KeyEventArgs>
                (k =>
                {
                    textBox1.KeyUp += k;
                    textBox2.KeyUp += k;
                },
                k =>
                {
                    textBox1.KeyUp -= k;
                    textBox2.KeyUp += k;
                });

            var keyPress = from e1 in textChangeObserver select e1;

            keyPress.Subscribe((key) =>
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Text = 0.ToString();
                }

                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox2.Text = 0.ToString();
                }

                label3.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text)).ToString();
            });
        }
    }
}
