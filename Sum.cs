using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WhoWantsToBeAMillionaire
{
    public partial class Sum : Form
    {
        public Sum()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.fireproofAmountLevel = comboBox1.SelectedIndex;
            this.Hide();
            StartGame chooseFriends = new StartGame();
            chooseFriends.ShowDialog();
            this.Close();
        }
    }
}
