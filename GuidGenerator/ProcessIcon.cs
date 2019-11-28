using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GuidGenerator
{
	class ProcessIcon : IDisposable
	{
		private readonly NotifyIcon _notifyIcon;

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessIcon"/> class.
		/// </summary>
		public ProcessIcon()
		{
			_notifyIcon = new NotifyIcon();
		}

		/// <summary>
		/// Displays the icon in the system tray.
		/// </summary>
		public void Display()
		{
			// Put the icon in the system tray and allow it react to mouse clicks.			
		     _notifyIcon.Icon = Properties.Resources.AppIcon;
            _notifyIcon.Text = "Guid Generator";
			_notifyIcon.Visible = true;

			// Attach a context menu.
		    _notifyIcon.ContextMenuStrip = CreateContextMenu();

            // Handle double click
            _notifyIcon.DoubleClick += (sender, args) => Implementation.GenerateGuid();
        }


        public void ShowNotification(string body)
        {
            if (body != null)
            {
                _notifyIcon.BalloonTipText = body;
            }

            _notifyIcon.ShowBalloonTip(1000);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
		{
            // When the application closes, this will remove the icon from the system tray immediately.
            _notifyIcon.Icon.Dispose();
			_notifyIcon.Dispose();
		}


	    private ContextMenuStrip CreateContextMenu()
	    {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;

            // Open.
            item = new ToolStripMenuItem();
            item.Text = "New Guid (Alt+g)";
            item.Click += (sender, args) => Implementation.GenerateGuid();
            //item.Image = Resources.Explorer;
            menu.Items.Add(item);

            // Separator.
            menu.Items.Add(new ToolStripSeparator());

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
	        item.Click += (sender, args) => Program.Exit();
            menu.Items.Add(item);

            return menu;
        }
    }
}