using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackoverflow
{
    class SystemTrayProgressIndicator
    {
        static int counter = 0;

        public static void Show()
        {
            counter++;
            SystemTray.ProgressIndicator.IsVisible = true;
        }

        public static void Hide()
        {
            counter--;
            if (counter <= 0)
            {
                SystemTray.ProgressIndicator.IsVisible = false;
            }
        }
    }
}
