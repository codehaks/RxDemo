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
            var movingEvents = Observable
                .FromEventPattern<MouseEventHandler, MouseEventArgs>
                (   h => this.MouseMove += h,
                    h => this.MouseMove -= h);

            var mouseMove = from e1 in movingEvents
                             select e1;

            mouseMove.Subscribe((d) => {

                textBox1.Text = d.EventArgs.X.ToString();
                textBox2.Text = d.EventArgs.Y.ToString();
            });

           
        }

    }
}
