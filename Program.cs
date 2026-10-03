using System;
using System.Windows.Forms;

namespace StudentTaskPlanner
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Presentation.MainForm());
        }
    }
}