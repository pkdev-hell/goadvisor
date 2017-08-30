using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoAdvisor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                InputProcessor ip = new InputProcessor();

                string outputMessage = string.Empty;
                string commands = txbCommands.Text;

                outputMessage = ip.ProcessCommands(commands);

                MessageBox.Show(outputMessage);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
