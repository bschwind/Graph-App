using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphApp.src
{
    public static class Output
    {
        private static TextBox textBox;

        public static void Initialize(TextBox tb)
        {
            textBox = tb;
        }

        public static void Write(string s)
        {
            textBox.AppendText(s);
        }

        public static void WriteLine(string s)
        {
            textBox.AppendText(s + "\r\n");
        }

        public static void WriteLine()
        {
            textBox.AppendText("\r\n");
        }
    }
}
