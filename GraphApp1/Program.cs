using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraphApp.src.Testing;

namespace GraphApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //bool success = Tester.RunTests();
            //Console.WriteLine(success? "Tests were successful" : "Tests were not successful");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
