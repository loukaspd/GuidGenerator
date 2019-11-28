using System;
using System.Threading;
using System.Windows.Forms;

namespace GuidGenerator
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}"); //single instance
        public static ProcessIcon ProcessIcon { get; private set; }
        private static HotKeyForm _form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true)) {
                MessageBox.Show("App already running");
                return;
            }

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //Form that takes monitors hotkey
            _form = new HotKeyForm();

            // Show System Tray Icon
            ProcessIcon = new ProcessIcon();
            ProcessIcon.Display();

            ProcessIcon.ShowNotification("Use Alt+g to generate guid");

            Application.Run();
        }

        public static void Exit()
        {
            ProcessIcon.Dispose();
            _form.Close();
            Environment.Exit(0);
        }
    }
}
