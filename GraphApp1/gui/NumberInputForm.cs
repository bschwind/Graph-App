using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphApp.src.gui
{
    public partial class NumberInputForm : Form
    {
        public int NumValue
        {
            get
            {
                try
                {
                    return int.Parse(textBox1.Text);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public NumberInputForm()
        {
            InitializeComponent();
            AcceptButton = OkButton;
            AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            CancelButton = cancelButton;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
