using System;
using System.Configuration;
using System.Linq;

namespace GuidGenerator
{
    public class Implementation
    {
        private static bool UseUppercase;
        public static void Init()
        {
            UseUppercase = Properties.Settings.Default.UseUppercase;
            Program.ProcessIcon.UppcaseItem.Checked = UseUppercase;
        }

        public static void OnUppercaseItemClicked()
        {
            UseUppercase = !UseUppercase;
            Program.ProcessIcon.UppcaseItem.Checked = UseUppercase;

            Properties.Settings.Default.UseUppercase = UseUppercase;
            Properties.Settings.Default.Save();
        }

        public static void GenerateGuid()
        {
            string guid = Guid.NewGuid().ToString();
            if (UseUppercase) guid = guid.ToUpper();

            System.Windows.Forms.Clipboard.SetText(guid);

            Program.ProcessIcon.ShowNotification("Guid Generated");
        }
    }
}
