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


        public ToolStripMenuItem UppcaseItem;

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

            // Generate Guid
            var generateItem = new ToolStripMenuItem();
            generateItem.Text = "New Guid (Alt+g)";
            generateItem.Click += (sender, args) => Implementation.GenerateGuid();
            //item.Image = Resources.Explorer;
            menu.Items.Add(generateItem);

            //Uppcase
            UppcaseItem = new ToolStripMenuItem();
            UppcaseItem.Text = "Uppercase";
            UppcaseItem.Click += (sender, args) => Implementation.OnUppercaseItemClicked();
            UppcaseItem.Checked = false;
            menu.Items.Add(UppcaseItem);

            // Separator.
            menu.Items.Add(new ToolStripSeparator());

            // Exit.
            var exitItem = new ToolStripMenuItem();
            exitItem.Text = "Exit";
            exitItem.Click += (sender, args) => Program.Exit();
            menu.Items.Add(exitItem);

            return menu;
        }
    }
}