using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidGenerator
{
    public class Implementation
    {
        public static void GenerateGuid()
        {
            string guid = Guid.NewGuid().ToString();
            System.Windows.Forms.Clipboard.SetText(guid);
            Program.ProcessIcon.ShowNotification("Guid Generated");
        }
    }
}
