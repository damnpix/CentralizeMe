using System;
using WinAPI;

namespace CentralizeMe.data
{
    internal class formSettings
    {
        public static void HideFromAltTab(IntPtr windowHandle)
        {
            user32.SetWindowLong(windowHandle, user32.GWL_EXSTYLE,
                user32.GetWindowLong(windowHandle, user32.GWL_EXSTYLE) |
                user32.WS_EX_TOOLWINDOW);
        }
    }
}
