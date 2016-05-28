using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Squirrel;

namespace MyApp
{
	public partial class Form1 : Form
	{
        public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

            Assembly assembly = Assembly.GetExecutingAssembly();

			locationTextBox.Text = assembly.Location;
            versionTextBox.Text = assembly.GetName().Version.ToString(3);

            CheckForUpdates();
        }

        async Task CheckForUpdates()
        {
            status.Text = "Checking for Updates";
            using (var mgr = new UpdateManager("http://www.onemoreblock.com/Atmosphir/standalone/windows-squirrel"))
            {
                await mgr.UpdateApp();
            }

            status.Text = "Updates Checked";
            button1.Enabled = true;
        }


        void StartGame()
        {
            status.Text = "Starting Game";
            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = "";
            // Enter the executable to run, including the complete path
            start.FileName = AssemblyDirectory + "\\Atmosphir\\Atmosphir.exe";
            // Do you want to show a console window?
            // start.WindowStyle = ProcessWindowStyle.Hidden;
            // start.CreateNoWindow = true;
            int exitCode;


            // Run the external process & wait for it to finish
            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }

            // terminate launcher process
            Application.Exit();
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
