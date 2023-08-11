using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQWInterceptor
{
    public partial class GameAddress : Form
    {
        public static GameAddress Instance = new GameAddress();

        DialogResult result = DialogResult.Cancel;

        public GameAddress()
        {
            InitializeComponent();
            AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
                result = DialogResult.OK;
        }

        public string ShowAddressForm()
        {
            ShowDialog();
            return result == DialogResult.OK ? textBox1.Text : null;
        }
    }
}
